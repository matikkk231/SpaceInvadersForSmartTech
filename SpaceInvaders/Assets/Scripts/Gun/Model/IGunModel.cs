using System;

namespace Gun.Model
{
    public interface IGunModel
    {
        Action<int> Attacked { get; set; }

        int DamageAmount { get; set; }
        void Attack();
    }
}