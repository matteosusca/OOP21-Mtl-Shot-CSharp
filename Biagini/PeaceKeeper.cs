using System;
using System.Threading;

using model.weapons.Weapon;

public class PeaceKeeper : Weapon
{

    private static const int MagCapacity = 6;
    private static const int DamagePerBullet = 30;
    private static const int FireRate = 0;
    private static const int ReloadTime = 120;
    private static const double Accuracy = 0.2;

    public PeaceKeeper() : base("PeaceKeeper", MagCapacity, DamagePerBullet, FireRate, ReloadTime, Accuracy)
	{
        
    }

}
