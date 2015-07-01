using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Platformer_AI
{
    class Actor
    {
        protected GamePosition position;
        public GamePosition Position { get { return position; } set { position = value; } }

        public Actor(GamePosition pos)
        {
            position = pos;
        }
    }

    class Player : Actor
    {
        public Player(GamePosition pos) : base(pos)
        {
            
        }
    }
}
