using System;
using UnityEngine;

namespace Bullet.View
{
    public abstract class BulletView : MonoBehaviour, IBulletView
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] protected GameObject _gameObject;
        public int DamageAmount { get; set; }

        public Vector2 Velocity
        {
            set => _rigidbody2D.velocity = value;
        }

        public Vector3 Position
        {
            set => transform.position = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            CollideWithObject(other);
        }

        protected abstract void CollideWithObject(Collider collider);
    }
}