using System;
using System.Collections.Generic;
using Monster.Model;
using Player.Model;
using Round;
using UnityEngine;

namespace Level.Model
{
    public interface ILevelModel
    {
        Action<RoundConfig, List<IMonsterModel>> RoundStarted { get; set; }

        Vector2Int LevelScale { get; }
        IPlayerModel Player { get; }
        List<RoundConfig> Rounds { get; }

        int CurrentRound { get; }

        void StartLevel();
    }
}