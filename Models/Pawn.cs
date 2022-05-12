using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pawn : ChessPiece
    {
        public bool movedTwice;
        public Pawn(string name, string chessPos, int color, Tuple<int, int> pos, int ID) : base(name,chessPos, color, pos,ID )
        {
            movedTwice = false;
        }
    }
}
