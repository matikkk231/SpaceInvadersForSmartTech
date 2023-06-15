using System;

namespace Player.Model
{
    public class PlayerModel: IPlayerModel
    {
        public Action Died { get; set; }
        
        public int Health { get; set; }
    }
}