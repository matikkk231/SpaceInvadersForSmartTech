using System;
using UnityEngine;

namespace Monster.View
{
    public class MonsterView : MonoBehaviour, IMonsterView
    {
        public Action<int> Damaged { get; set; }
        public Action PositionChanged { get; set; }

        public Vector2 Position
        {
            get => transform.position;
            set
            {
                transform.position = value;
                PositionChanged?.Invoke();
            }
        }

        [SerializeField] private Transform _transform;

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void GetDamage(int damageAmount)
        {
            throw new NotImplementedException();
        }
    }
}