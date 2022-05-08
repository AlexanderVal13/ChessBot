namespace Models
{
    public class ChessBoard
    {
        public ChessPiece[][] Board { get; set;}
        public ChessBoard()
        {
            Board = new ChessPiece[8][];
        }
    }
}