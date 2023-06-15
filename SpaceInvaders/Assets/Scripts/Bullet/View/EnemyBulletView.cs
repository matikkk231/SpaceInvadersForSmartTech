using Monster.View;
using UnityEngine;

namespace Bullet.View
{
    public class EnemyBulletView : BulletView
    {
        protected override void CollideWithObject(Collider2D collider)
        {
            var monsterView = collider.GetComponent<IMonsterView>();
            if (monsterView == null)
            {
                Destroy(_gameObject);
            }
        }
    }
}