using UnityEngine;

namespace Bullet.View
{
    public class BulletView : MonoBehaviour, IBulletView
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private GameObject _gameObject;
        public int DamageAmount { get; set; }

        public Vector2 Velocity
        {
            get => _rigidbody2D.velocity;
            set => _rigidbody2D.velocity = value;
        }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        private void OnCollisionEnter2D()
        {
            Destroy(_gameObject);
        }
    }
}