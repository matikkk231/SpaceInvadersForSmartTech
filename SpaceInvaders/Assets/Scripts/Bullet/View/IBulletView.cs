using UnityEngine;

namespace Bullet.View
{
    public interface IBulletView
    {
        int DamageAmount { get; set; }
        Vector2 Velocity { set; }
        Vector3 Position { set; }
    }
}