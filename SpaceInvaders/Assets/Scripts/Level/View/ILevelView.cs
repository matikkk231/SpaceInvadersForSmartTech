using Monster;
using Monster.View;
using Player.View;
using Round;
using UnityEngine;

namespace Level.View
{
    public interface ILevelView
    {
        IMonsterView CreateMonsterView(MonsterType type, Vector2Int position, RoundConfig roundConfig);
        IPlayerView CreatePlayerView(Vector2Int position);
        
    }
}