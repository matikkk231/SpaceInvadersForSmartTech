using System;
using UnityEngine;

namespace Gun.View
{
    public abstract class GunView : MonoBehaviour, IGunView
    {
        public Action PreparedToShoot { get; set; }
        
        [SerializeField] protected Transform _shootPosition;
        [SerializeField] protected GameObject _bulletPref;
        private const int _bulletSpeed = 1;
        
        public abstract void Attack(int damage);
    }
}