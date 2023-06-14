using System;
using System.Collections.Generic;
using Monster.Model;
using Round;
using UnityEngine;

namespace Level.Model
{
    public interface ILevelModel
    {
        Action<RoundConfig, List<MonsterModel>> RoundStarted { get; set; }

        Vector2Int LevelScale { get; }

        void StartLevel();
    }
}