﻿namespace WeaponShopV10
{
    /// <summary>
    /// This class represents a Axe. An Axe is 
    /// considered to be a weapon.
    /// </summary>
    public class Axe : Weapon
    {
        public const int AxeMinDamage = 20;
        public const int AxeMaxDamage = 50;

        #region Constructor
        public Axe(string description) : base(description, 20, 50)
        {
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Returns the damage dealt by the Axe. Also lowers the
        /// minimum and maximum damage dealt by three points.
        /// </summary>
        public int DamageFromAxe()
        {
            int damage = CalculateDamage();

            MinDamage = MinDamage < 3 ? 0 : MinDamage - 3;
            MaxDamage = MaxDamage < 3 ? 0 : MaxDamage - 3;

            return damage;
        }

        /// <summary>
        /// Resets the minimum and maximum damage dealt by 
        /// the Axe to its original values.
        /// </summary>
        public void Sharpen()
        {
            MinDamage = AxeMinDamage;
            MaxDamage = AxeMaxDamage;
        } 
        #endregion
    }
}