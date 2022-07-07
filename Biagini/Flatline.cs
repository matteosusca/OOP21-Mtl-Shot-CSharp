namespace OOP21MtlShot.Model.Weapon
{
    public class Flatline : Weapon
    {
        private const string FlatlineName = "Flatline";
        private const int FlatlineMagCapacity = 25;
        private const int FlatlineDamagePerBullet = 6;
        private const int FlatlineFireRate = 13;
        private const int FlatlineReloadTime = 100;
        private const double FlatlineAccuracy = 0.8;

        public Flatline() :
            base(FlatlineName, FlatlineMagCapacity, FlatlineDamagePerBullet, FlatlineFireRate, FlatlineReloadTime, FlatlineAccuracy)
        { }
    }
}