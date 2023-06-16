using System;
using Bullet.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gun.View
{
    public class TripleMonsterGunView : GunView
    {
        private const int _bulletSpeed = 1;
        private float _secTillNextAttack;

        private void Start()
        {
            _secTillNextAttack = Random.Range(6, 13);
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
            var positionPosition = _shootPosition.position;

            var bullet1 = Instantiate(_bulletPref).GetComponent<IBulletView>();
            bullet1.Velocity = Vector2.down * _bulletSpeed;
            bullet1.Position = positionPosition;

            var bullet2 = Instantiate(_bulletPref).GetComponent<IBulletView>();
            bullet2.Position = positionPosition;
            bullet2.Velocity = new Vector2(0.5f, -1) * _bulletSpeed;

            var bullet3 = Instantiate(_bulletPref).GetComponent<IBulletView>();
            bullet3.Position = positionPosition;
            bullet3.Velocity = new Vector2(-0.5f, -1) * _bulletSpeed;

            _secTillNextAttack = Random.Range(6, 13);
        }
    }
}