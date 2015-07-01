using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asuro_AI;
using System.Drawing;

namespace Platformer_AI
{
    class Level
    {
        private int seed;
        public int Seed { get { return seed; } }
        private int length;
        public int Length { get { return length; } }
        private Random rnd;
        private List<Block> blocks = new List<Block>();
        private Player player;

        public Dictionary<GamePosition, Block> Blocks
        {
            get
            {
                Dictionary<GamePosition, Block> result = new Dictionary<GamePosition, Block>();
                blocks.ForEach((block) => result.Add(block.Position, block));
                return result;
            }
        }

        public GamePosition PlayerPosition { get { return new GamePosition(player.Position.X, player.Position.Y); } }

        public Level(int levelSeed, int levelLength = 200)
        {
            seed = levelSeed;
            length = levelLength;
            rnd = new Random(seed);
            player = new Player(new GamePosition(0, 6));
            CreateLevel();
        }

        private void CreateLevel()
        {
            // Create ground
            const int maxGapLength = 5;
            int gapCounter = 0;

            for (int x = 0; x < length; x++)
            {
                if (rnd.Next(0, 100) > 10 || gapCounter > maxGapLength)
                {
                    blocks.Add(new Block(BlockType.Ground, new GamePosition(x, 5)));
                    gapCounter = 0;
                }
                else
                    gapCounter++;
            }
        }

        public void MovePlayer(bool left, bool right, bool up)
        {
            bool moveRight = right && !left && !IsBlockAt(player.Position + new GamePosition(1, 0));
            bool moveLeft = left && !right && !IsBlockAt(player.Position + new GamePosition(-1, 0));
            bool moveUp = up && !IsBlockAt(player.Position + new GamePosition(0, 1)) && IsBlockAt(player.Position + new GamePosition(0, -1));
            bool moveDown = !IsBlockAt(player.Position + new GamePosition(0, -1));

            if (moveRight)
                player.Position += new GamePosition(1, 0);
            if (moveLeft)
                player.Position += new GamePosition(-1, 0);
            if (moveUp)
                player.Position += new GamePosition(0, 1);
            if (moveDown)
                player.Position += new GamePosition(0, -1);
        }

        private bool IsBlockAt(GamePosition pos)
        {
            return Blocks.ContainsKey(pos);
        }
        
        public void Draw(Graphics target, int leftCameraBound, int screenWidth, int screenHeight, int blockWidth, int blockHeight)
        {
            // Draw blocks
            for (int x = leftCameraBound; x < leftCameraBound + screenWidth; x++)
            {
                for (int y = 0; y < screenHeight; y++)
                {
                    GamePosition pos = new GamePosition(x, y);
                    if (Blocks.ContainsKey(pos))
                    {
                        target.DrawRectangle(Pens.Green, (x * blockWidth), ((screenHeight - y - 1) * blockHeight), blockWidth, blockHeight);
                    }
                }
            }

            // Draw player
            target.DrawEllipse(Pens.Green, (player.Position.X * blockWidth), ((screenHeight - player.Position.Y - 1) * blockHeight), blockWidth, blockHeight);
        }
    }

    enum BlockType
    {
        Ground,
        Wall
    }

    class Block
    {
        private BlockType type;
        public BlockType Type { get { return type; } }
        private GamePosition pos;
        public GamePosition Position { get { return pos; } }

        public Block(BlockType blockType, GamePosition position)
        {
            type = blockType;
            pos = position;
        }
    }

    public class GamePosition : Position
    {
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public GamePosition(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
        }

        public static bool operator ==(GamePosition a, GamePosition b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(GamePosition a, GamePosition b)
        {
            return !a.Equals(b);
        }

        public static GamePosition operator +(GamePosition a, GamePosition b)
        {
            return new GamePosition(a.x + b.x, a.y + b.y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.GetType() == typeof(GamePosition))
            {
                GamePosition castObj = (GamePosition)obj;
                return castObj.x == this.x && castObj.y == this.y;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return 5 * x + 7 * y;
        }
    }
}
