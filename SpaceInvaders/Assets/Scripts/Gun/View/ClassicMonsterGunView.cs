using System;
using Bullet.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gun.View
{
    public class ClassicMonsterGunView : GunView
    {
        private float _secTillNextAttack;
        private const int _bulletSpeed = 1;

        private void Start()
        {
            _secTillNextAttack = Random.Range(4, 8);
        }

        private void Update()
        {
            _secTillNextAttack -= Time.deltaTime;

            if (_secTillNextAttack < 0)
            {
                PreparedToShoot?.Invoke();
            }
        }

        public override void Attack(int damage)
        {
            var bulletObject = Instantiate(_bulletPref);
            var bulletView = bulletObject.GetComponent<IBulletView>();
            bulletView.DamageAmount = damage;
            bulletView.Velocity = Vector2.down * _bulletSpeed;
            bulletView.Position = _shootPosition.position;
            _secTillNextAttack = Random.Range(4, 8);
        }
    }
}