using Monster;
using Monster.View;
using Player.View;
using Round;
using UnityEngine;

namespace Level.View
{
    public interface ILevelView
    {
        Vector2 LevelScale { get; set; }

        void StartRound(RoundConfig roundConfig);
        IMonsterView CreateMonsterView(MonsterType type, Vector2Int position);
        IPlayerView CreatePlayerView(Vector2Int position);

        void SetSpeed(float speed);
    }
}