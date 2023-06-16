using System;
using Gun.Model;
using Monster.View;
using Unity.Mathematics;
using UnityEngine;

namespace Monster.Model
{
    public class MonsterModel : IMonsterModel
    {
        public Action<MovingDirection> Moved { get; set; }
        public Action Died { get; set; }

        private readonly Vector2Int _levelScale;
        private int _health;
        public MonsterType Type { get; }
        public Vector2Int Position { get; private set; }

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    Died?.Invoke();
                }
            }
        }

        public IGunModel Gun { get; }
        public int Reward { get; }

        public MonsterModel(MonsterConfig config, Vector2Int levelScale)
        {
            Position = config.Position;
            Type = config.Type;
            _levelScale = levelScale;
            Reward = config.Reward;

            switch (Type)
            {
                case MonsterType.LittleMonster:
                    Health = 1;
                    Gun = new GunModel(1);
                    break;
                default: throw new Exception("monster type not found");
            }
        }

        public void Move()
        {
            if (Position.x == _levelScale.x && (Position.y % 2 != 0))
            {
                MoveDown();
                return;
            }

            if (Position.x == _levelScale.x && (Position.y % 2 == 0))
            {
                MoveLeft();
                return;
            }

            if (Position.x == -_levelScale.x && (Position.y % 2 == 0))
            {
                MoveDown();
                return;
            }

            if (Position.x == -_levelScale.x && (Position.y % 2 != 0))
            {
                MoveRight();
                return;
            }

            var absPositionX = math.abs(Position.x);
            if (absPositionX != _levelScale.x && (Position.y % 2 != 0))
            {
                MoveRight();
                return;
            }

            if (absPositionX != _levelScale.x && (Position.y % 2 == 0))
            {
                MoveLeft();
            }
        }

        private void MoveDown()
        {
            var oldPosition = Position;
            Position = new Vector2Int(oldPosition.x, oldPosition.y - 1);
            Moved?.Invoke(MovingDirection.Down);
        }

        private void MoveLeft()
        {
            var oldPosition = Position;
            Position = new Vector2Int(oldPosition.x - 1, oldPosition.y);
            Moved?.Invoke(MovingDirection.Left);
        }

        private void MoveRight()
        {
            var oldPosition = Position;
            Position = new Vector2Int(oldPosition.x + 1, oldPosition.y);
            Moved?.Invoke(MovingDirection.Right);
        }
    }
}