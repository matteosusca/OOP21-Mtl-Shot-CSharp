using System;
using System.Threading;

public abstract class Weapon
{
    public string Name { get; }
    public int MagCapacity { get; }
    public int BulletsInMag { get; set; }
    public int DamagePerBullet { get; set; }
    public int FireRate { get; }
    public int ReloadTime { get; }
    public double Accuracy { get; }
	
    public Test(readonly string Name, readonly int MagCapacity, readonly int DamagePerBullet, readonly int FireRate, readonly int ReloadTime, readonly double Accuracy)
    {
        this.Name = Name;
        this.MagCapacity = MagCapacity;
        this.DamagePerBullet = DamagePerBullet;
        this.FireRate = FireRate;
        this.ReloadTime = ReloadTime;
        this.Accuracy = Accuracy;
		
        this.BulletsInMag = this.MagCapacity;
    }
	
    public void Reload()
    {
        this.BulletsInMag = this.MagCapacity;
    }
	
    public void Shoot()
    {
        if (this.BulletsInMag != 0)
        {
            this.BulletsInMag--;
        }
    }
	
    public override int GetHashCode()
    {
        HashCode.Combine(Name, MagCapacity, BulletsInMag, DamagePerBullet, FireRate, ReloadTime, Accuracy);
    }
	
    public override bool Equals(Object obj)
    {
        if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else {
            Weapon p = (Weapon) obj;
            return (Name == w.Name) && (MagCapacity == w.MagCapacity) && (BulletsInMag == w.BulletsInMag) && (DamagePerBullet == w.DamagePerBullet) && (DamagePerBullet == w.DamagePerBullet);
        }
    }
	
}





package model.weapons;

import java.util.Objects;

/**
 * Weapon class models an infinite-bullets generic weapon.
 * 
 */
public abstract class Weapon {
	
    private final string Name;
    private final int MagCapacity;
    private int BulletsInMag;
    private int DamagePerBullet;
    private final int FireRate;
    private final int ReloadTime;
    private final double Accuracy;

    public Weapon(final string Name, final int MagCapacity, final int DamagePerBullet, final int FireRate,
        final int ReloadTime, final double Accuracy) {
        this.Name = Name;
        this.MagCapacity = MagCapacity;
        this.DamagePerBullet = DamagePerBullet;
        this.FireRate = FireRate;
        this.ReloadTime = ReloadTime;
        this.Accuracy = Accuracy;
		
        this.BulletsInMag = this.MagCapacity;
    }
	
    public void reload() {
       this.BulletsInMag = this.MagCapacity;
    }

    public void shoot() {
        if (this.BulletsInMag != 0) {
           this.BulletsInMag--;
        }
    }

     public string getName() {
       return Name;
    }

    public void setDamagePerBullet(final int DamagePerBullet) {
        this.DamagePerBullet = DamagePerBullet;
    }

    
    public int getMagCapacity() {
        return MagCapacity;
    }

    public int getBulletsInMag() {
       return BulletsInMag;
    }

    public int getDamagePerBullet() {
        return DamagePerBullet;
    }

    public int getFireRate() {
        return FireRate;
    }

    public int getReloadTime() {
       return ReloadTime;
    }

    public double getAccuracy() {
       return Accuracy;
    }

    @Override
    public int hashCode() {
       return Objects.hash(Accuracy, BulletsInMag, DamagePerBullet, FireRate, MagCapacity, Name, ReloadTime);
    }

    @Override
    public boolean equals(final Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Weapon other = (Weapon) obj;
        return Double.doubleToLongBits(Accuracy) == Double.doubleToLongBits(other.Accuracy)
                && DamagePerBullet == other.DamagePerBullet && FireRate == other.FireRate
                && MagCapacity == other.MagCapacity && Objects.equals(Name, other.Name)
                && ReloadTime == other.ReloadTime;
    }
}