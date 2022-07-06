using OOP21MtlShot.Model.Weapon;

public class R99 : Weapon
{
    private const string R99Name = "R99";
    private const int R99MagCapacity = 30;
    private const int R99DamagePerBullet = 8;
    private const int R99FireRate = 7;
    private const int R99ReloadTime = 100;
    private const double R99Accuracy = 1.0;

    public R99() :
        base(R99Name, R99MagCapacity, R99DamagePerBullet, R99FireRate, R99ReloadTime, R99Accuracy)
    { }

}
