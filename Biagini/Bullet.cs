using System;
using System.Threading;

using util.Vector2D;
using util.direction.DirectionHorizontal;
using util.direction.DirectionVertical;

using System.Random;
using System.Math;

using model.Entity;
using model.character.Character;
using model.character.tools.Aim;

public class Bullet : Entity {

    private static readonly double DefaultSpeed = 0.3;
    private static readonly double DefaultHitboxSize = 0.1;
    private static readonly int AngleRight = 0;
    private static readonly int AngleUp = 90;
    private static readonly int AngleLeft = 180;
    private static readonly int AngleDown = 270;
    private static readonly double AccuracyAmplifier = 8.0;

    public Character Owner { get; }
    public Aim AimOBJ { get; }
    public double Speed { get; }
    public int Damage { get; }
    public bool Hit;
    public double Cos { get; }
    public double Sin { get; }

    public Bullet(readonly Character Owner)
	{
        base(new Vector2D(Owner.GetPosition().GetX() + Owner.GetHitbox().GetX() / 2,
                Owner.GetPosition().GetY() + Owner.GetHitbox().GetY() / 2),
                new Vector2D(DefaultHitboxSize, DefaultHitboxSize));
        this.Owner = Owner;
        this.AimOBJ = Owner.GetAim();
        this.Speed = DefaultSpeed;
        this.Hit = false;
        this.Damage = Owner.getWeapon().GetDamagePerBullet();

        readonly var r = new Random();
        readonly double angleInterval = 1 / ((Owner.getWeapon().getAccuracy()));
        double angle = AccuracyAmplifier * angleInterval * (r.nextDouble() - 0.5);

        if (this.AimOBJ.getDirection().getY().equals(DirectionVertical.UP)) {
            angle += AngleUp;
        } else if (this.AimOBJ.getDirection().getY().equals(DirectionVertical.DOWN)) {
            angle += AngleDown;
        } else if (this.AimOBJ.getDirection().getX().equals(DirectionHorizontal.LEFT)) {
            angle += AngleLeft;
        } else if (this.AimOBJ.getDirection().getX().equals(DirectionHorizontal.RIGHT)) {
            angle += AngleRight;
        }

        this.Sin = Math.Sin(DegreesToRadians(angle));
        this.Cos = Math.Cos(DegreesToRadians(angle));
    }
	
    public void Tick()
	{
        base.SetPosition(base.GetPosition().GetX() + this.Speed * this.Cos,
                base.GetPosition().GetY() - this.Speed * this.Sin);
    }
	
    public bool HasHit() => Hit;

    public void HitSomething()
	{
        this.Hit = true;
    }
	
	private double DegreesToRadians(readonly double val) => (Math.PI / 180) * val;

    public override string ToString()
	{
        return "Bullet [position=" + base.GetPosition() + ", AimOBJ=" + AimOBJ + ", Speed=" + Speed + ", Damage=" + Damage
                + "]";
    }

    public override bool IsColliding(readonly Entity entity)
	{
        if (entity.equals(this.Owner)) {
            return false;
        }
        return super.isColliding(entity);
    }

}
