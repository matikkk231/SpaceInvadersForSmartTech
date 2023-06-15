using System;
using Bullet.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gun.View
{
    public class ClassicMonsterGunView : GunView
    {
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private GameObject _bulletPref;
        private const int _bulletSpeed = 1;
        private float _secTillNextAttack;

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
            _secTillNextAttack = Random.Range(2, 8);
        }
    }
}