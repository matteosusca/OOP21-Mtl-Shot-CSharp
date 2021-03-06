using System;

public class BasicBot : ISimpleBot
{
    private readonly Enemy _enemy;
    private readonly Player _player;
    private readonly Level _level;
    private readonly double _maxDistance = EntityConstants.EnemyDistance
        + (new Random.NextDouble* EntityConstants.EnemyVariation - EntityConstants.EnemyVariation / 2);
    private bool _lastDir = true;

    public BasicBot(Enemy enemy, Level level, Player player)
    {
        this.Enemy = enemy;
        this.Level = level;
        this.Player = player;
    }

    public void ControllerTick()
    {
        switch (Enemy.GetStatus())
        {
            case Idle:
                this.RandomMove();
                break;
            case Active:
                this.Move();
                this.Fire();
                break;
            default:
        }
    }

    private void RandomMove()
    {
        this.LastDir = (new Random().Next(0, EntityConstants.ChangeDirProbability) == 0) ? !LastDir : LastDir;
        Enemy.GetAim().SetHorizontal(LastDir ? DirectionHorizontal.Left : DirectionHorizontal.Right);
        MovementLogic(LastDir);
        readonly double distance = Enemy.GetPosition().getX() - Player.GetPosition().GetX();
        if (Math.Abs(distance) < this.MaxDistance)
        {
            Enemy.SetStatus(Status.Active);
        }
    }

    public void Move()
    {
        if (this.Player != null)
        {
            double distance = Enemy.Position.X - Player.Position.X;
            if (Math.Abs(distance) < MaxDistance + EntityConstants.EnemyTolerance
                    && Math.Abs(distance) > MaxDistance - EntityConstants.EnemyTolerance)
            {
                Enemy.SetLeft(false);
                Enemy.SetRight(false);
            }
            else
            {
                bool dir = distance > 0;
                Enemy.GetAim().setHorizontal(dir ? DirectionHorizontal.Left : DirectionHorizontal.Right);
                dir = Math.Abs(distance) < MaxDistance ? !dir : dir;
                MovementLogic(dir);
            }
        }
    }

    private void MovementLogic(bool dir)
    {
        Enemy.SetLeft(dir);
        Enemy.SetRight(!dir);
        double nearTileX = dir ? -(EntityConstants.EnemyDelta)
                : EntityConstants.EnemyDelta + Enemy.Hitbox.X;
        Enemy.SetJump(GetCurrentCharacterSegment()
                .IsCollidableAtPosition(this.Enemy.Position.Sum(nearTileX, Enemy.GetHitbox().GetY() - 1))
                || GetCurrentCharacterSegment().IsCollidableAtPosition(this.Enemy.Position.Sum(nearTileX, 0)));
    }

    public Segment GetCurrentCharacterSegment()
    {
        return Level.GetSegmentAtPosition(this.Enemy.Position);
    }

    public void Fire()
    {
        Enemy.SetFire(Math.Abs(Enemy.Position.X - Player.Position.X) < MaxDistance);
    }

}
