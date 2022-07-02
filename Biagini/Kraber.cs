using System;
using System.Threading;

using model.weapons.Weapon;

public class Kraber : Weapon
{

    private static const int MagCapacity = 5;
    private static const int DamagePerBullet = 100;
    private static const int FireRate = 100;
    private static const int ReloadTime = 150;
    private static const double Accuracy = 50.0;

    public Kraber() : base("Kraber", MagCapacity, DamagePerBullet, FireRate, ReloadTime, Accuracy)
	{
        
    }

}
