using System;
using System.Threading;

using model.weapons.Weapon;

public class R99 : Weapon
{

    private static const int MagCapacity = 30;
    private static const int DamagePerBullet = 8;
    private static const int FireRate = 7;
    private static const int ReloadTime = 100;
    private static const double Accuracy = 1.0;

    public R99() : base("R99", MagCapacity, DamagePerBullet, FireRate, ReloadTime, Accuracy)
	{
        
    }

}
