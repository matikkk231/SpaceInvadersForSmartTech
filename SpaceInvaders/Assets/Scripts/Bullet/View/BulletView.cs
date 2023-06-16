using System;
using UnityEngine;

namespace Bullet.View
{
    public abstract class BulletView : MonoBehaviour, IBulletView
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] protected GameObject _gameObject;
        private float _timeInFly;
        private const float _disappearingTime = 9;
        public int DamageAmount { get; set; }

        public Vector2 Velocity
        {
            set => _rigidbody2D.velocity = value;
        }

        public Vector3 Position
        {
            set => transform.position = value;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CollideWithObject(other);
        }

        private void Update()
        {
            _timeInFly += Time.deltaTime;

            if (_timeInFly > _disappearingTime)
            {
                Destroy(_gameObject);
            }
        }

        protected abstract void CollideWithObject(Collider2D collider);
    }
}