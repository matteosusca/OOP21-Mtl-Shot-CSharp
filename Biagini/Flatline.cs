using System;
using System.Threading;

using model.weapons.Weapon;

public class Flatline : Weapon
{

    private static const int MagCapacity = 25;
    private static const int DamagePerBullet = 6;
    private static const int FireRate = 13;
    private static const int ReloadTime = 100;
    private static const double Accuracy = 0.8;

    public Flatline() : base("Flatline", MagCapacity, DamagePerBullet, FireRate, ReloadTime, Accuracy)
	{
        
    }

}
