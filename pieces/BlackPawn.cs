using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.pieces
{

    class BlackPawn : Piece
    {

        public BlackPawn(Board board) : base(Figure.PAWN, Color.BLACK, board)
        {

        }

        protected override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);
            var distance = origin.MaxDistanceWith(destination);

            if ((Direction.SOUTHEAST == direction || Direction.SOUTHWEST == direction)
                && !destination.IsEmpty() && !destination.HasAllyPiece(color)
                && distance == 1) return true;

            if (Direction.SOUTH == direction && destination.IsEmpty()
                && ((distance <= 2 && origin.Row() == 6)
                || distance == 1)) return true;

            return false;
        }

    }
}
