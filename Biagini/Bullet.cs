using OOP21MtlShot.Dummy;
using System;

namespace OOP21MtlShot.Model.Weapons
{
    public class Bullet : Entity
    {
        private const double DefaultSpeed = 0.3;
        private const double DefaultHitboxSize = 0.1;
        private const int AngleRight = 0;
        private const int AngleUp = 90;
        private const int AngleLeft = 180;
        private const int AngleDown = 270;
        private const double AccuracyAmplifier = 8.0;

        private bool _hit;
        private readonly double _cos;
        private readonly double _sin;

        public Character Owner { get; }
        public Aim Aim { get; }
        public double Speed { get; }
        public int Damage { get; }

        public Bullet(Character Owner) :
            base(new Vector2D(Owner.Position.X + Owner.Hitbox.Y / 2, Owner.Position.Y + Owner.Hitbox.Y / 2),
                new Vector2D(DefaultHitboxSize, DefaultHitboxSize))
        {
            this.Owner = this.Owner;
            this.Aim = this.Owner.Aim;
            this.Speed = Bullet.DefaultSpeed;
            this._hit = false;
            this.Damage = this.Owner.Weapon.DamagePerBullet;

            Random r = new Random();
            double angleInterval = 1 / Owner.Weapon.Accuracy;
            double angle = AccuracyAmplifier * angleInterval * (r.NextDouble() - 0.5);

            (DirectionHorizontal X, DirectionVertical Y) = this.Aim.Direction;
            if (Y is DirectionVertical.Up)
            {
                angle += AngleUp;
            }
            else if (Y is DirectionVertical.Down)
            {
                angle += AngleDown;
            }
            else if (X is DirectionHorizontal.Left)
            {
                angle += AngleLeft;
            }
            else if (X is DirectionHorizontal.Right)
            {
                angle += AngleRight;
            }

            this._sin = Math.Sin(this.DegreesToRadians(angle));
            this._cos = Math.Cos(this.DegreesToRadians(angle));
        }

        public void Tick()
        {
            base.SetPosition(base.GetPosition().X + this.Speed * this._cos,
                    base.GetPosition().Y - this.Speed * this._sin);
        }

        public bool HasHit()
        {
            return this._hit;
        }

        public void HitSomething()
        {
            this._hit = true;
        }

        private double DegreesToRadians(double val)
        {
            return (Math.PI / 180) * val;
        }

        public override string ToString()
        {
            return "Bullet [position=" + base.GetPosition() + ", AimOBJ=" + this.Aim + ", Speed=" + this.Speed + ", Damage=" + this.Damage + "]";
        }

        public override bool IsColliding(Entity entity)
        {
            if (entity.Equals(this.Owner))
            {
                return false;
            }
            return base.IsColliding(entity);
        }

    }
}
