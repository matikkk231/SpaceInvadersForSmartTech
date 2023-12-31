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
        public Action AttackPressed { get; set; }

        private float _speed = 3;
        private Vector2 _movingDirection;
        [SerializeField] private GunView _gun;
        [SerializeField] private Rigidbody2D _rigidbody;

        public IGunView Gun
        {
            get => _gun;
            set => _gun = (GunView) value;
        }

        public float MaxPositionX { get; set; }
        public float MaxPositionY { get; set; }
        public float MinPositionX { get; set; }
        public float MinPositionY { get; set; }

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void AttackNotify()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                AttackPressed?.Invoke();
            }
        }

        public void GetDamage(int damage)
        {
            Damaged?.Invoke(damage);
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        private void Move()
        {
            _movingDirection = Vector2.zero;

            if (Input.GetKey(KeyCode.A) && Position.x > MinPositionX)
            {
                _movingDirection.x = -1;
            }

            if (Input.GetKey(KeyCode.D) && Position.x < MaxPositionX)
            {
                _movingDirection.x = 1;
            }

            if (Input.GetKey(KeyCode.W) && Position.y < MaxPositionY)
            {
                _movingDirection.y = 1;
            }

            if (Input.GetKey(KeyCode.S) && Position.y > MinPositionY)
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
            AttackNotify();
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