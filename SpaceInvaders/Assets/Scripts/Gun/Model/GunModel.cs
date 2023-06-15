using System;

namespace Gun.Model
{
    public class GunModel : IGunModel
    {
        public Action<int> Attacked { get; set; }

        public int DamageAmount { get; set; }

        public GunModel(int damageAmount)
        {
            DamageAmount = damageAmount;
        }

        public void Attack()
        {
            Attacked?.Invoke(DamageAmount);
        }
    }
}