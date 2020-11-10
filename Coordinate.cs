using System;

namespace ConsoleChess
{
    public class Coordinate
    {
        private readonly int x;
        private readonly int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Direction GetDirectionWith(Coordinate other)
        {
            if (this.Equals(other)) return Direction.NONE;

            if (KnightJump(other)) return Direction.KNIGHT_JUMP;

            if (DistanceX(other) == 0 && DistanceY(other) > 0) return Direction.NORTH;
            if (DistanceX(other) == 0 && DistanceY(other) < 0) return Direction.SOUTH;

            if (DistanceX(other) > 0 && DistanceY(other) == 0) return Direction.EAST;
            if (DistanceX(other) < 0 && DistanceY(other) == 0) return Direction.WEST;

            if (DistanceX(other) > 0 && PositiveSlope(other)) return Direction.NORTHEAST;
            if (DistanceX(other) < 0 && !PositiveSlope(other)) return Direction.SOUTHEAST;

            if (DistanceX(other) > 0 && !PositiveSlope(other)) return Direction.NORTHWEST;
            if (DistanceX(other) < 0 && PositiveSlope(other)) return Direction.SOUTHWEST;

            return Direction.NONE;
        }

        public int Distance(Coordinate other)
        {
            return Math.Max(Math.Abs(DistanceX(other)), Math.Abs(DistanceY(other)));
        }

        public Coordinate GetUnitVector(Coordinate other)
        {
            var direction = this.GetDirectionWith(other);

            int newX = 0;
            int newY = 0;

            if (direction == Direction.NORTH || direction == Direction.NORTHEAST || direction == Direction.NORTHWEST) { newY++; }
            if (direction == Direction.SOUTH || direction == Direction.SOUTHEAST || direction == Direction.SOUTHWEST) { newY--; }

            if (direction == Direction.EAST || direction == Direction.NORTHEAST || direction == Direction.SOUTHEAST) { newX++; }
            if (direction == Direction.WEST || direction == Direction.NORTHWEST || direction == Direction.SOUTHWEST) { newX--; }

            return new Coordinate(newX, newY);
        }

        public Coordinate Displaced(Coordinate displacement)
        {
            return new Coordinate(this.x + displacement.x, this.y + displacement.y);
        }

        private bool Equals(Coordinate other)
        {
            return this.x == other.x && this.y == other.y;
        }

        private int DistanceX(Coordinate other)
        {
            return other.x - this.x;
        }

        private int DistanceY(Coordinate other)
        {
            return other.y - this.y;
        }

        private bool PositiveSlope(Coordinate other)
        {
            double incrementY = other.y - this.y;
            double incrementX = other.x - this.x;

            return (incrementY / incrementX) > 0;
        }

        private bool KnightJump(Coordinate other)
        {
            var yDistance = Math.Abs(DistanceY(other));
            var xDistance = Math.Abs(DistanceX(other));

            return yDistance == 1 && xDistance == 2 || yDistance == 2 && xDistance == 1;
        }

        public int GetX() => this.x;
        public int GetY() => this.y;

        public static Square ToSquare(Coordinate coordinate)
        {
            return new Square(coordinate.GetY(), coordinate.GetX());
        }

    }
}
