using System;
using Bullet.View;
using Gun.View;
using UnityEngine;

namespace Monster.View
{
    public class MonsterView : MonoBehaviour, IMonsterView
    {
        public Action<int> Damaged { get; set; }
        public Action ReachedKeyPoint { get; set; }

        public IGunView GunView
        {
            get => _gunView;
        }


        private float _speed = 0.8f;
        private MovingDirection _movingDirection;
        private Vector2 _positionShouldReach;
        private float _distanceBetweenPoints = 1;

        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GunView _gunView;

        public Vector2 Position
        {
            get => transform.position;
            set { transform.position = value; }
        }

        private void Update()
        {
            if (_movingDirection == MovingDirection.Down)
            {
                if (Position.y < _positionShouldReach.y)
                {
                    StopMoving();
                }
            }

            if (_movingDirection == MovingDirection.Up)
            {
                if (Position.y > _positionShouldReach.y)
                {
                    StopMoving();
                }
            }

            if (_movingDirection == MovingDirection.Right)
            {
                if (Position.x > _positionShouldReach.x)
                {
                    StopMoving();
                }
            }

            if (_movingDirection == MovingDirection.Left)
            {
                if (Position.x < _positionShouldReach.x)
                {
                    StopMoving();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var bulletView = other.collider.GetComponent<IBulletView>();
            if (bulletView != null)
            {
                GetDamage(bulletView.DamageAmount);
            }
        }

        public void GetDamage(int damageAmount)
        {
            throw new NotImplementedException();
        }

        public void Move(MovingDirection direction)
        {
            if (direction == MovingDirection.Down)
            {
                _positionShouldReach = new Vector2(Position.x, Position.y - _distanceBetweenPoints);
                _movingDirection = MovingDirection.Down;
                _rigidbody.velocity = Vector2.down * _speed;
            }

            if (direction == MovingDirection.Left)
            {
                _positionShouldReach = new Vector2(Position.x - _distanceBetweenPoints, Position.y);
                _movingDirection = MovingDirection.Left;
                _rigidbody.velocity = Vector2.left * _speed;
            }

            if (direction == MovingDirection.Right)
            {
                _positionShouldReach = new Vector2(Position.x + _distanceBetweenPoints, Position.y);
                _movingDirection = MovingDirection.Right;
                _rigidbody.velocity = Vector2.right * _speed;
            }

            if (direction == MovingDirection.Up)
            {
                _positionShouldReach = new Vector2(Position.x, Position.y + _distanceBetweenPoints);
                _movingDirection = MovingDirection.Up;
                _rigidbody.velocity = Vector2.up * _speed;
            }
        }

        public void SetDistanceBetweenPoints(float measure)
        {
            _distanceBetweenPoints = measure;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }


        private void StopMoving()
        {
            _rigidbody.velocity = Vector2.zero;
            _movingDirection = MovingDirection.Nowhere;
            _positionShouldReach = Vector2.zero;
            ReachedKeyPoint?.Invoke();
        }
    }

    public enum MovingDirection
    {
        Right,
        Left,
        Down,
        Up,
        Nowhere
    }
}