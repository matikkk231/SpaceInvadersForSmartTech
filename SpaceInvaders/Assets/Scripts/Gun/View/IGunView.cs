using System;

namespace Gun.View
{
    public interface IGunView
    {
        Action PreparedToShoot { get; set; }

        void Attack(int damage);
    }
}