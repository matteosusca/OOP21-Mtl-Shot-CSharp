using OOP21MtlShot.Model.Weapon;

public class PeaceKeeper : Weapon
{
    private const string PaceKeeperName = "PeaceKeeper";
    private const int PeaceKeeperMagCapacity = 6;
    private const int PeaceKeeperDamagePerBullet = 30;
    private const int PeaceKeeperFireRate = 0;
    private const int PeaceKeeperReloadTime = 120;
    private const double PeaceKeeperAccuracy = 0.2;

    public PeaceKeeper() :
        base(PaceKeeperName, PeaceKeeperMagCapacity, PeaceKeeperDamagePerBullet, PeaceKeeperFireRate, PeaceKeeperReloadTime, PeaceKeeperAccuracy)
    { }

}
