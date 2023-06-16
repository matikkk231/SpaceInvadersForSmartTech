using Bullet.View;
using UnityEngine;

namespace Gun.View
{
    public class ClassicPlayerGunView : GunView
    {
        private const int _bulletSpeed = 3;

        public override void Attack(int damage)
        {
            var bulletObject = Instantiate(_bulletPref);
            var bulletView = bulletObject.GetComponent<IBulletView>();
            bulletView.DamageAmount = damage;
            bulletView.Velocity = Vector2.up * _bulletSpeed;
            bulletView.Position = _shootPosition.position;
        }
    }
}