using Player.View;
using UnityEngine;

namespace Bullet.View
{
    public class PlayerBulletView : BulletView
    {
        protected override void CollideWithObject(Collider2D collider)
        {
            var playerView = collider.GetComponent<IPlayerView>();
            if (playerView == null)
            {
                Destroy(_gameObject);
            }
        }
    }
}