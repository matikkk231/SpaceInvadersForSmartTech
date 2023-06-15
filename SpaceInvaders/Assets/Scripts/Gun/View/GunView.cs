using System;
using UnityEngine;

namespace Gun.View
{
    public abstract class GunView : MonoBehaviour, IGunView
    {
        public Action PreparedToShoot { get; set; }
        public abstract void Attack(int damage);
    }
}