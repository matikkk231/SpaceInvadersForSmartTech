using System;
using Bullet.View;
using Gun.View;
using Monster.View;
using UnityEngine;

namespace Player.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        public Action<int> Damaged { get; set; }
        public Action AttackStarted { get; set; }

        private float _speed = 3;
        private Vector2 _movingDirection = new Vector2();
        [SerializeField] private GunView _gun;
        [SerializeField] private Rigidbody2D _rigidbody;

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void Attack(int damage)
        {
            _gun.Attack(damage);
        }

        public void AttackNotify()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                AttackStarted?.Invoke();
            }
        }

        public void GetDamage(int damage)
        {
            Damaged?.Invoke(damage);
        }

        private void Move()
        {
            _movingDirection = Vector2.zero;

            if (Input.GetKey(KeyCode.A))
            {
                _movingDirection.x = -1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                _movingDirection.x = 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                _movingDirection.y = 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                _movingDirection.y = -1;
            }

            if (_movingDirection.x != 0 || _movingDirection.y != 0)
            {
                _rigidbody.velocity = new Vector2(_movingDirection.x, _movingDirection.y) * _speed;
                return;
            }

            _rigidbody.velocity = Vector2.zero;
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var monsterView = other.GetComponent<IMonsterView>();
            if (monsterView != null)
            {
                GetDamage(Int32.MaxValue);
                return;
            }

            var bulletView = other.GetComponent<IBulletView>();
            if (bulletView != null)
            {
                GetDamage(bulletView.DamageAmount);
            }
        }
    }
}