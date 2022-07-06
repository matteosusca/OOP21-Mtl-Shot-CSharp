using System;

namespace OOP21MtlShot.Model.Weapon
{
    public abstract class Weapon
    {
        public string Name { get; }
        public int MagCapacity { get; }
        public int BulletsInMag { get; private set; }
        public int DamagePerBullet { get; set; }
        public int FireRate { get; }
        public int ReloadTime { get; }
        public double Accuracy { get; }

        public Weapon(string name, int magCapacity, int damagePerBullet, int fireRate, int reloadTime, double accuracy)
        {
            this.Name = name;
            this.MagCapacity = magCapacity;
            this.DamagePerBullet = damagePerBullet;
            this.FireRate = fireRate;
            this.ReloadTime = reloadTime;
            this.Accuracy = accuracy;
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
            return HashCode.Combine(this.Name, this.MagCapacity, this.BulletsInMag,
                this.DamagePerBullet, this.FireRate, this.ReloadTime, this.Accuracy);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Weapon))
            {
                return false;
            }
            else
            {
                Weapon w = (Weapon)obj;
                return
                    this.Name == w.Name &&
                    this.Accuracy == w.Accuracy &&
                    this.DamagePerBullet == w.DamagePerBullet &&
                    this.FireRate == w.FireRate &&
                    this.MagCapacity == w.MagCapacity &&
                    this.ReloadTime == this.ReloadTime;
            }
        }

    }
}