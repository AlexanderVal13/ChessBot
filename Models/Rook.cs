﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rook : ChessPiece
    {
        public Rook(string name, string chessPos, int color, Tuple<int, int> pos, int ID) : base(name,chessPos, color, pos , ID)
        {

        }
    }
}
