using System;

namespace Player.Model
{
    public interface IPlayerModel
    {
        Action Died { get; set; }

        int Health { get; set; }
    }
}