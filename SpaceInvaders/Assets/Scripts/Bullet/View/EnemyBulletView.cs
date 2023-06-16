using Monster.View;
using UnityEngine;

namespace Bullet.View
{
    public class EnemyBulletView : BulletView
    {
        protected override void CollideWithObject(Collider2D collider)
        {
            var monsterView = collider.GetComponent<IMonsterView>();
            var enemyBulletView = collider.GetComponent<EnemyBulletView>();
            if (monsterView == null && enemyBulletView == null)
            {
                Destroy(_gameObject);
            }
        }
    }
}