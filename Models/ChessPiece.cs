using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChessPiece
    {
        public string name { get; set; }
        public string chessPos { get; set; }
        public int color { get; set; }
        public Tuple<int, int> pos { get; set; }
        public int ID { get; set; }
        public ChessPiece(string name,string chessPos, int color , Tuple<int, int> pos, int ID)
        {
            this.name = name;
            this.chessPos = chessPos;
            this.pos = pos;
            this.color = color;
            this.ID = ID;
        }
    }
}
