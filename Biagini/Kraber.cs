using OOP21MtlShot.Model.Weapon;

public class Kraber : Weapon
{
    private const string KraberName = "Kraber";
    private const int KraberMagCapacity = 5;
    private const int KraberDamagePerBullet = 100;
    private const int KraberFireRate = 100;
    private const int KraberReloadTime = 150;
    private const double KraberAccuracy = 50.0;

    public Kraber() :
        base(KraberName, KraberMagCapacity, KraberDamagePerBullet, KraberFireRate, KraberReloadTime, KraberAccuracy)
    { }

}
