using Model.Round;
using UnityEngine;

namespace Model.Level
{
    public interface ILevelModel
    {
        IRoundModel[] Rounds { get; }
        int CurrentRound { get; set; }
        Vector2 LevelScale { get; }

        void StartRound(int round);
        void Win();
        void Loose();
    }
}