using Round;
using UnityEngine;

namespace Level.View
{
    public interface ILevelView
    {
        Vector2 LevelScale { get; set; }

        void StartRound(RoundConfig roundConfig);
    }
}