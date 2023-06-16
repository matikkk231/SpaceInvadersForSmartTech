using Player.View;
using UnityEngine;

namespace Bullet.View
{
    public class PlayerBulletView : BulletView
    {
        protected override void CollideWithObject(Collider2D collider)
        {
            var playerView = collider.GetComponent<IPlayerView>();
            var bulletView = collider.GetComponent<PlayerBulletView>();
            if (playerView == null && bulletView == null)
            {
                Destroy(_gameObject);
            }
        }
    }
}