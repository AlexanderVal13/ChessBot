using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ChessBot
{
    public partial class ChessForm : Form
    {
        private ChessBoard chessBoard;
        private Dictionary<Tuple<int, int>, Tuple<int, int>> coordinates;
        private Dictionary<string, Image> ImageStorage;
        private bool chessPieceIsBeingPickedUp;
        private ChessPiece chessPieceInHand;
        private int idNumber;
        private string temporaryNameOfPieceInHand;
        private bool playingAsWhitePieces;
        private bool startGame;
        private bool inCheck;


        public ChessForm()
        {
            startGame = false;
            chessBoard = new ChessBoard();
            coordinates = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            ImageStorage = new Dictionary<string, Image>();
            chessPieceIsBeingPickedUp = false;
            chessPieceInHand = new ChessPiece("Empty", chessPosName(0, 0), 3, Tuple.Create(0, 0), 0);
            temporaryNameOfPieceInHand = "Empty";
            idNumber = 1;
            playingAsWhitePieces = true;
            inCheck = false;
            addToImageStorage();
            InitializeComponent();

            var timer = new Timer();
            timer.Interval = 1000 / 144;  // 1000 milliseconds in a second divided by 144 frames per second
            timer.Tick += (a, b) => this.Invalidate();
            timer.Start();
        }
        private void DrawGame(object sender, PaintEventArgs e)
        {
            if (startGame)
            {
                DrawBoard(e);
                DrawPieces(e);
                if (chessPieceIsBeingPickedUp)
                    DrawPiecePickUp(e);
            }
        }
        private void DrawPieces(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image blackBishopImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessBot\Models\Images\blackBishop.png");
            Image whiteBishopImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteBishop.png");
            Image blackPawnImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackPawn.png");
            Image whitePawnImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whitePawn.png");
            Image blackKnightImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackKnight.png");
            Image whiteKnightImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteKnight.png");
            Image blackRookImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackRook.png");
            Image whiteRookImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteRook.png");
            Image blackQueenImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackQueen.png");
            Image whiteQueenImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteQueen.png");
            Image blackKingImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackKing.png");
            Image whiteKingImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteKing.png");

            int imageWidth = 90;
            int imageHeight = 90;
            int offSet = 4;
            Image blackBishop = ResizeImage(blackBishopImage, imageWidth, imageHeight);
            Image whiteBishop = ResizeImage(whiteBishopImage, imageWidth, imageHeight);
            Image blackPawn = ResizeImage(blackPawnImage, imageWidth, imageHeight);
            Image whitePawn = ResizeImage(whitePawnImage, imageWidth, imageHeight);
            Image blackKnight = ResizeImage(blackKnightImage, imageWidth, imageHeight);
            Image whiteKnight = ResizeImage(whiteKnightImage, imageWidth, imageHeight);
            Image blackRook = ResizeImage(blackRookImage, imageWidth, imageHeight);
            Image whiteRook = ResizeImage(whiteRookImage, imageWidth, imageHeight);
            Image blackQueen = ResizeImage(blackQueenImage, imageWidth, imageHeight);
            Image whiteQueen = ResizeImage(whiteQueenImage, imageWidth, imageHeight);
            Image blackKing = ResizeImage(blackKingImage, imageWidth, imageHeight);
            Image whiteKing = ResizeImage(whiteKingImage, imageWidth, imageHeight);

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    ChessPiece chessPiece = chessBoard.Board[i][k];
                    if (chessPiece.name != "Empty")
                    {
                        if (chessPiece.name == "White Rook")
                            graphics.DrawImage(whiteRook, getCord(i, k).Item1 + (-whiteRook.Width / 2) - offSet, getCord(i, k).Item2 + (-whiteRook.Width / 2) - offSet);
                        if (chessPiece.name == "White Knight")
                            graphics.DrawImage(whiteKnight, getCord(i, k).Item1 + (-whiteKnight.Width / 2) - offSet, getCord(i, k).Item2 + (-whiteKnight.Width / 2) - offSet);
                        if (chessPiece.name == "White Bishop")
                            graphics.DrawImage(whiteBishop, getCord(i, k).Item1 + (-whiteBishop.Width / 2) - offSet, getCord(i, k).Item2 + (-whiteBishop.Width / 2) - offSet);
                        if (chessPiece.name == "White Queen")
                            graphics.DrawImage(whiteQueen, getCord(i, k).Item1 + (-whiteQueen.Width / 2) - offSet, getCord(i, k).Item2 + (-whiteQueen.Width / 2) - offSet);
                        if (chessPiece.name == "White King")
                            graphics.DrawImage(whiteKing, getCord(i, k).Item1 + (-whiteKing.Width / 2) - offSet, getCord(i, k).Item2 + (-whiteKing.Width / 2) - offSet);
                        if (chessPiece.name == "White Pawn")
                            graphics.DrawImage(whitePawn, getCord(i, k).Item1 + (-whitePawn.Width / 2) - offSet, getCord(i, k).Item2 + (-whitePawn.Width / 2) - offSet);
                        if (chessPiece.name == "Black Rook")
                            graphics.DrawImage(blackRook, getCord(i, k).Item1 + (-blackRook.Width / 2) - offSet, getCord(i, k).Item2 + (-blackRook.Width / 2) - offSet);
                        if (chessPiece.name == "Black Knight")
                            graphics.DrawImage(blackKnight, getCord(i, k).Item1 + (-blackKnight.Width / 2) - offSet, getCord(i, k).Item2 + (-blackKnight.Width / 2) - offSet);
                        if (chessPiece.name == "Black Bishop")
                            graphics.DrawImage(blackBishop, getCord(i, k).Item1 + (-blackBishop.Width / 2) - offSet, getCord(i, k).Item2 + (-blackBishop.Width / 2) - offSet);
                        if (chessPiece.name == "Black Queen")
                            graphics.DrawImage(blackQueen, getCord(i, k).Item1 + (-blackQueen.Width / 2) - offSet, getCord(i, k).Item2 + (-blackQueen.Width / 2) - offSet);
                        if (chessPiece.name == "Black King")
                            graphics.DrawImage(blackKing, getCord(i, k).Item1 + (-blackKing.Width / 2) - offSet, getCord(i, k).Item2 + (-blackKing.Width / 2) - offSet);
                        if (chessPiece.name == "Black Pawn")
                            graphics.DrawImage(blackPawn, getCord(i, k).Item1 + (-blackPawn.Width / 2) - offSet, getCord(i, k).Item2 + (-blackPawn.Width / 2) - offSet);
                    }
                }
            }
        }
        private void DrawBoard(PaintEventArgs e)
        {
            int locationX = 40;
            int locationY = 30;
            int size = 100;

            SolidBrush blueBrush = new SolidBrush(Color.CadetBlue);
            SolidBrush whiteBrush = new SolidBrush(Color.FloralWhite);

            bool changeColor = false;

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Rectangle square = new Rectangle(locationX, locationY, size, size);
                    Point centerPoint = Center(square);
                    if (changeColor == true)
                    {
                        e.Graphics.FillRectangle(blueBrush, square);
                        if (!coordinates.ContainsKey(Tuple.Create(i, k)))
                        {
                            coordinates.Add(Tuple.Create(i, k), Tuple.Create(centerPoint.X, centerPoint.Y));
                        }
                        changeColor = false;
                    }
                    else
                    {
                        e.Graphics.FillRectangle(whiteBrush, square);
                        if (!coordinates.ContainsKey(Tuple.Create(i, k)))
                        {
                            coordinates.Add(Tuple.Create(i, k), Tuple.Create(centerPoint.X, centerPoint.Y));
                        }
                        changeColor = true;
                    }
                    locationX += size;
                }
                if (i % 2 == 0)
                    changeColor = true;
                else
                    changeColor = false;

                locationY += size;
                locationX = 40;
            }

        }
        private void DrawPiecePickUp(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image pieceIMG = ImageStorage[temporaryNameOfPieceInHand];
            int offSet = 3;
            Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
            Point convertedP = PointToClient(p);

            graphics.DrawImage(pieceIMG, (convertedP.X) + (-pieceIMG.Width / 2) - offSet, (convertedP.Y) + (-pieceIMG.Width / 2) - offSet);
        }
        private void addToImageStorage()
        {
            Image blackBishopImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessBot\Models\Images\blackBishop.png");
            Image whiteBishopImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteBishop.png");
            Image blackPawnImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackPawn.png");
            Image whitePawnImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whitePawn.png");
            Image blackKnightImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackKnight.png");
            Image whiteKnightImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteKnight.png");
            Image blackRookImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackRook.png");
            Image whiteRookImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteRook.png");
            Image blackQueenImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackQueen.png");
            Image whiteQueenImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteQueen.png");
            Image blackKingImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\blackKing.png");
            Image whiteKingImage = Image.FromFile(@"C:\Users\alexa\source\repos\ChessAI\Models\Images\whiteKing.png");

            int imageWidth = 90;
            int imageHeight = 90;
            Image blackBishop = ResizeImage(blackBishopImage, imageWidth, imageHeight);
            Image whiteBishop = ResizeImage(whiteBishopImage, imageWidth, imageHeight);
            Image blackPawn = ResizeImage(blackPawnImage, imageWidth, imageHeight);
            Image whitePawn = ResizeImage(whitePawnImage, imageWidth, imageHeight);
            Image blackKnight = ResizeImage(blackKnightImage, imageWidth, imageHeight);
            Image whiteKnight = ResizeImage(whiteKnightImage, imageWidth, imageHeight);
            Image blackRook = ResizeImage(blackRookImage, imageWidth, imageHeight);
            Image whiteRook = ResizeImage(whiteRookImage, imageWidth, imageHeight);
            Image blackQueen = ResizeImage(blackQueenImage, imageWidth, imageHeight);
            Image whiteQueen = ResizeImage(whiteQueenImage, imageWidth, imageHeight);
            Image blackKing = ResizeImage(blackKingImage, imageWidth, imageHeight);
            Image whiteKing = ResizeImage(whiteKingImage, imageWidth, imageHeight);
            string[] ImageNames = new string[] { "Black Rook", "Black Knight", "Black Bishop", "Black Queen", "Black King", "Black Pawn", "White Rook", "White Knight", "White Bishop", "White Queen", "White King", "White Pawn", };
            Image[] ImgArray = new Image[] { blackRook, blackKnight, blackBishop, blackQueen, blackKing, blackPawn, whiteRook, whiteKnight, whiteBishop, whiteQueen, whiteKing, whitePawn };
            for (int i = 0; i < 12; i++)
            {
                ImageStorage.Add(ImageNames[i], ImgArray[i]);
            }
        }
        private void applyInitalPieces()
        {
            if (playingAsWhitePieces)
            {
                Pawn wP = new Pawn("Black Pawn", chessPosName(0, 0), 0, Tuple.Create(7, 0), 1);
                Pawn bP = new Pawn("White Pawn", chessPosName(0, 0), 1, Tuple.Create(1, 0), 1);
                chessBoard.Board[1] = new ChessPiece[8] { bP, bP, bP, bP, bP, bP, bP, bP };
                chessBoard.Board[6] = new ChessPiece[8] { wP, wP, wP, wP, wP, wP, wP, wP };

                for (int i = 0; i < 8; i++)
                {
                    Pawn blackPawn = new Pawn("Black Pawn", chessPosName(1, i), 1, Tuple.Create(1, i), idNumber); idNumber++;
                    Pawn whitePawn = new Pawn("White Pawn", chessPosName(6, i), 0, Tuple.Create(6, i), idNumber); idNumber++;

                    chessBoard.Board[1].SetValue(blackPawn, i);
                    chessBoard.Board[6].SetValue(whitePawn, i);
                }

                Rook blackRook = new Rook("Black Rook", chessPosName(0, 0), 1, Tuple.Create(0, 0), idNumber); idNumber++;
                Rook blackRook2 = new Rook("Black Rook", chessPosName(0, 7), 1, Tuple.Create(0, 7), idNumber); idNumber++;
                Rook whiteRook = new Rook("White Rook", chessPosName(7, 0), 0, Tuple.Create(7, 0), idNumber); idNumber++;
                Rook whiteRook2 = new Rook("White Rook", chessPosName(7, 7), 0, Tuple.Create(7, 7), idNumber); idNumber++;
                Knight blackKnight = new Knight("Black Knight", chessPosName(0, 1), 1, Tuple.Create(0, 1), idNumber); idNumber++;
                Knight blackKnight2 = new Knight("Black Knight", chessPosName(0, 6), 1, Tuple.Create(0, 6), idNumber); idNumber++;
                Knight whiteKnight = new Knight("White Knight", chessPosName(7, 1), 0, Tuple.Create(7, 1), idNumber); idNumber++;
                Knight whiteKnight2 = new Knight("White Knight", chessPosName(7, 6), 0, Tuple.Create(7, 6), idNumber); idNumber++;
                Bishop blackBishop = new Bishop("Black Bishop", chessPosName(0, 2), 1, Tuple.Create(0, 2), idNumber); idNumber++;
                Bishop blackBishop2 = new Bishop("Black Bishop", chessPosName(0, 5), 1, Tuple.Create(0, 5), idNumber); idNumber++;
                Bishop whiteBishop = new Bishop("White Bishop", chessPosName(7, 2), 0, Tuple.Create(7, 2), idNumber); idNumber++;
                Bishop whiteBishop2 = new Bishop("White Bishop", chessPosName(7, 5), 0, Tuple.Create(7, 5), idNumber); idNumber++;
                Queen blackQueen = new Queen("Black Queen", chessPosName(0, 3), 1, Tuple.Create(0, 3), idNumber); idNumber++;
                Queen whiteQueen = new Queen("White Queen", chessPosName(7, 3), 0, Tuple.Create(7, 3), idNumber); idNumber++;
                King blackKing = new King("Black King", chessPosName(0, 4), 1, Tuple.Create(0, 4), idNumber); idNumber++;
                King whiteKing = new King("White King", chessPosName(7, 4), 0, Tuple.Create(7, 4), idNumber); idNumber++;
                chessBoard.Board[0] = new ChessPiece[8] { blackRook, blackKnight, blackBishop, blackQueen, blackKing, blackBishop2, blackKnight2, blackRook2 };
                chessBoard.Board[7] = new ChessPiece[8] { whiteRook, whiteKnight, whiteBishop, whiteQueen, whiteKing, whiteBishop2, whiteKnight2, whiteRook2 };

                //Create empty spaces 
                ChessPiece eS = new ChessPiece("Empty", chessPosName(2, 0), 3, Tuple.Create(2, 0), 0);
                ChessPiece eS2 = new ChessPiece("Empty", chessPosName(3, 0), 3, Tuple.Create(3, 0), 0);
                ChessPiece eS3 = new ChessPiece("Empty", chessPosName(4, 0), 3, Tuple.Create(4, 0), 0);
                ChessPiece eS4 = new ChessPiece("Empty", chessPosName(5, 0), 3, Tuple.Create(5, 0), 0);
                chessBoard.Board[2] = new ChessPiece[8] { eS, eS, eS, eS, eS, eS, eS, eS };
                chessBoard.Board[3] = new ChessPiece[8] { eS2, eS2, eS2, eS2, eS2, eS2, eS2, eS2 };
                chessBoard.Board[4] = new ChessPiece[8] { eS3, eS3, eS3, eS3, eS3, eS3, eS3, eS3 };
                chessBoard.Board[5] = new ChessPiece[8] { eS4, eS4, eS4, eS4, eS4, eS4, eS4, eS4 };
                //Update Locations of empty spaces
                for (int i = 0; i < 8; i++)
                {
                    ChessPiece emptySquare = new ChessPiece("Empty", chessPosName(2, i), 3, Tuple.Create(2, i), 0);
                    ChessPiece emptySquare2 = new ChessPiece("Empty", chessPosName(3, i), 3, Tuple.Create(3, i), 0);
                    ChessPiece emptySquare3 = new ChessPiece("Empty", chessPosName(4, i), 3, Tuple.Create(4, i), 0);
                    ChessPiece emptySquare4 = new ChessPiece("Empty", chessPosName(5, i), 3, Tuple.Create(5, i), 0);
                    chessBoard.Board[2].SetValue(emptySquare, i);
                    chessBoard.Board[3].SetValue(emptySquare2, i);
                    chessBoard.Board[4].SetValue(emptySquare3, i);
                    chessBoard.Board[5].SetValue(emptySquare4, i);
                }
            }
            else
            {
                Pawn wP = new Pawn("Black Pawn", chessPosName(0, 0), 0, Tuple.Create(7, 0), 1);
                Pawn bP = new Pawn("White Pawn", chessPosName(0, 0), 1, Tuple.Create(1, 0), 1);
                chessBoard.Board[1] = new ChessPiece[8] { bP, bP, bP, bP, bP, bP, bP, bP };
                chessBoard.Board[6] = new ChessPiece[8] { wP, wP, wP, wP, wP, wP, wP, wP };

                for (int i = 0; i < 8; i++)
                {
                    Pawn blackPawn = new Pawn("Black Pawn", chessPosName(6, i), 1, Tuple.Create(6, i), idNumber); idNumber++;
                    Pawn whitePawn = new Pawn("White Pawn", chessPosName(1, i), 0, Tuple.Create(1, i), idNumber); idNumber++;

                    chessBoard.Board[6].SetValue(blackPawn, i);
                    chessBoard.Board[1].SetValue(whitePawn, i);
                }

                Rook blackRook = new Rook("Black Rook", chessPosName(7, 0), 1, Tuple.Create(7, 0), idNumber); idNumber++;
                Rook blackRook2 = new Rook("Black Rook", chessPosName(7, 7), 1, Tuple.Create(7, 7), idNumber); idNumber++;
                Rook whiteRook = new Rook("White Rook", chessPosName(0, 0), 0, Tuple.Create(0, 0), idNumber); idNumber++;
                Rook whiteRook2 = new Rook("White Rook", chessPosName(0, 7), 0, Tuple.Create(0, 7), idNumber); idNumber++;
                Knight blackKnight = new Knight("Black Knight", chessPosName(7, 1), 1, Tuple.Create(7, 1), idNumber); idNumber++;
                Knight blackKnight2 = new Knight("Black Knight", chessPosName(7, 6), 1, Tuple.Create(7, 6), idNumber); idNumber++;
                Knight whiteKnight = new Knight("White Knight", chessPosName(0, 1), 0, Tuple.Create(0, 1), idNumber); idNumber++;
                Knight whiteKnight2 = new Knight("White Knight", chessPosName(0, 6), 0, Tuple.Create(0, 6), idNumber); idNumber++;
                Bishop blackBishop = new Bishop("Black Bishop", chessPosName(7, 2), 1, Tuple.Create(7, 2), idNumber); idNumber++;
                Bishop blackBishop2 = new Bishop("Black Bishop", chessPosName(7, 5), 1, Tuple.Create(7, 5), idNumber); idNumber++;
                Bishop whiteBishop = new Bishop("White Bishop", chessPosName(0, 2), 0, Tuple.Create(0, 2), idNumber); idNumber++;
                Bishop whiteBishop2 = new Bishop("White Bishop", chessPosName(0, 5), 0, Tuple.Create(0, 5), idNumber); idNumber++;
                Queen blackQueen = new Queen("Black Queen", chessPosName(7, 3), 1, Tuple.Create(7, 3), idNumber); idNumber++;
                Queen whiteQueen = new Queen("White Queen", chessPosName(0, 3), 0, Tuple.Create(0, 3), idNumber); idNumber++;
                King blackKing = new King("Black King", chessPosName(7, 4), 1, Tuple.Create(7, 4), idNumber); idNumber++;
                King whiteKing = new King("White King", chessPosName(0, 4), 0, Tuple.Create(0, 4), idNumber); idNumber++;
                chessBoard.Board[7] = new ChessPiece[8] { blackRook, blackKnight, blackBishop, blackQueen, blackKing, blackBishop2, blackKnight2, blackRook2 };
                chessBoard.Board[0] = new ChessPiece[8] { whiteRook, whiteKnight, whiteBishop, whiteQueen, whiteKing, whiteBishop2, whiteKnight2, whiteRook2 };

                //Create empty spaces 
                ChessPiece eS = new ChessPiece("Empty", chessPosName(2, 0), 3, Tuple.Create(2, 0), 0);
                ChessPiece eS2 = new ChessPiece("Empty", chessPosName(3, 0), 3, Tuple.Create(3, 0), 0);
                ChessPiece eS3 = new ChessPiece("Empty", chessPosName(4, 0), 3, Tuple.Create(4, 0), 0);
                ChessPiece eS4 = new ChessPiece("Empty", chessPosName(5, 0), 3, Tuple.Create(5, 0), 0);
                chessBoard.Board[2] = new ChessPiece[8] { eS, eS, eS, eS, eS, eS, eS, eS };
                chessBoard.Board[3] = new ChessPiece[8] { eS2, eS2, eS2, eS2, eS2, eS2, eS2, eS2 };
                chessBoard.Board[4] = new ChessPiece[8] { eS3, eS3, eS3, eS3, eS3, eS3, eS3, eS3 };
                chessBoard.Board[5] = new ChessPiece[8] { eS4, eS4, eS4, eS4, eS4, eS4, eS4, eS4 };
                //Update Locations of empty spaces
                for (int i = 0; i < 8; i++)
                {
                    ChessPiece emptySquare = new ChessPiece("Empty", chessPosName(2, i), 3, Tuple.Create(2, i), 0);
                    ChessPiece emptySquare2 = new ChessPiece("Empty", chessPosName(3, i), 3, Tuple.Create(3, i), 0);
                    ChessPiece emptySquare3 = new ChessPiece("Empty", chessPosName(4, i), 3, Tuple.Create(4, i), 0);
                    ChessPiece emptySquare4 = new ChessPiece("Empty", chessPosName(5, i), 3, Tuple.Create(5, i), 0);
                    chessBoard.Board[2].SetValue(emptySquare, i);
                    chessBoard.Board[3].SetValue(emptySquare2, i);
                    chessBoard.Board[4].SetValue(emptySquare3, i);
                    chessBoard.Board[5].SetValue(emptySquare4, i);
                }
            }
        }
        public Point Center(Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2,
                             rect.Top + rect.Height / 2);
        }
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            /// AUTHOR:https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {

                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }

            }

            return destImage;
        }
        public string chessPosName(int x, int y)
        {

            string name = "";
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char[] numbers = { '8', '7', '6', '5', '4', '3', '2', '1' };
            char[] lettersForBlack = { 'H', 'G', 'F', 'E', 'D', 'C', 'B', 'A' };
            char[] numbersForBlack = { '1', '2', '3', '4', '5', '6', '7', '8' };
            if (playingAsWhitePieces)
                return name += letters[y].ToString() + numbers[x].ToString();
            else
                return name += lettersForBlack[y].ToString() + numbersForBlack[x].ToString();
        }
        public Tuple<int, int> getCord(int xKey, int yKey)
        {
            return coordinates[Tuple.Create(xKey, yKey)];
        }
        private void ChessForm_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {

                case MouseButtons.Left:
                    for (int index = 0; index < coordinates.Count; index++)
                    {
                        var item = coordinates.ElementAt(index);
                        var pos = item.Key;
                        var location = item.Value;
                        // If mouse is within square (reason for 50 is because a square is 100 pixels width and height)
                        if (e.X < location.Item1 + 50 && e.X > location.Item1 - 50 && e.Y < location.Item2 + 50 && e.Y > location.Item2 - 50)
                        {

                            if (chessBoard.Board[pos.Item1][pos.Item2].name != "Empty" && chessPieceIsBeingPickedUp == false)
                            {
                                ChessPiece chessP = chessBoard.Board[pos.Item1][pos.Item2];
                                chessPieceIsBeingPickedUp = true;
                                chessPieceInHand = chessP;
                                temporaryNameOfPieceInHand = chessPieceInHand.name;
                                chessPieceInHand.name = "Empty"; //Visual Reasons. Dont want 2 pieces shown when you picked up 1.
                                break;
                            }
                            else
                            {
                                chessPieceIsBeingPickedUp = false;
                            }
                        }
                    }
                    break;

                case MouseButtons.Right:
                    chessPieceIsBeingPickedUp = false;
                    chessPieceInHand.name = temporaryNameOfPieceInHand;
                    break;
            }


        }
        private void ChessForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (chessPieceIsBeingPickedUp)
            {
                for (int index = 0; index < coordinates.Count; index++)
                {
                    var item = coordinates.ElementAt(index);
                    var pos = item.Key;
                    var location = item.Value;

                    // If mouse is within square (reason for 50 is because a square is 100 pixels width and height)
                    if (e.X < location.Item1 + 50 && e.X > location.Item1 - 50 && e.Y < location.Item2 + 50 && e.Y > location.Item2 - 50)
                    {

                        if (onlyLegalMoves(chessPieceInHand).Contains(pos))
                        {

                            ChessPiece emptySquare = new ChessPiece("Empty", chessPieceInHand.chessPos, 3, chessPieceInHand.pos, 0);
                            chessBoard.Board[chessPieceInHand.pos.Item1][chessPieceInHand.pos.Item2] = emptySquare;
                            chessPieceInHand.pos = pos;
                            chessPieceInHand.chessPos = chessPosName(pos.Item1, pos.Item2);
                            chessBoard.Board[pos.Item1][pos.Item2] = chessPieceInHand;

                            chessBoard.Board[pos.Item1][pos.Item2].name = temporaryNameOfPieceInHand;
                            chessPieceIsBeingPickedUp = false;
                            if (chessPieceInHand.name == "White Pawn" || chessPieceInHand.name == "Black Pawn")
                            {
                                Pawn p = (Pawn)chessPieceInHand;
                                p.movedTwice = true;
                            }

                        }
                        else
                        {

                            chessPieceIsBeingPickedUp = false;
                            chessPieceInHand.name = temporaryNameOfPieceInHand;
                        }
                    }
                    else
                    {
                        chessPieceIsBeingPickedUp = false;
                        chessPieceInHand.name = temporaryNameOfPieceInHand;
                    }
                }
            }
        }
    
        private List<Tuple<int, int>> onlyLegalMoves(ChessPiece chessPiece)
        {
            var onlyLegalMoves = new List<Tuple<int, int>>();
            int row = chessPiece.pos.Item1;
            int col = chessPiece.pos.Item2;
            switch (chessPiece.GetType().ToString())
            {
                case "Models.Bishop":
                    return bishopOnlyLegalMoves(chessPiece);

                case "Models.King":
                    return kingOnlyLegalMoves(chessPiece);

                case "Models.Knight":
                    return knightOnlyLegalMoves(chessPiece);

                case "Models.Pawn":
                    return pawnOnlyLegalMoves(chessPiece);

                case "Models.Queen":
                    return queenOnlyLegalMoves(chessPiece);

                case "Models.Rook":
                    return rookOnlyLegalMoves(chessPiece);

                default:
                    break;
            }
            return onlyLegalMoves;
        }
        private string printChessBoard()
        {
            textBoxPrintBoard.Multiline = true;
            textBoxPrintBoard.AcceptsReturn = true;
            StringBuilder chessBoardString = new StringBuilder();
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8' };
            string lettersString = "";
            string numberString = "";



            for (int j = 0; j < 8; j++)
            {
                int x = 0;
                int lengthOfGap = 4;
                string gap = "";
                while (x < lengthOfGap)
                {
                    gap += "--------";
                    x++;
                }

                if (j != 7)
                {
                    lettersString += letters[j] + gap;
                    numberString += numbers[j] + gap;
                }
                else
                {
                    lettersString += letters[j];
                    numberString += numbers[j];
                }
            }
            chessBoardString.Append(lettersString + "\r\n");

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    ChessPiece chessPiece = chessBoard.Board[i][k];
                    string name = chessPiece.name;
                    string chessPos = chessPiece.chessPos;
                    string pos = "" + chessPiece.pos.Item1 + " " + chessPiece.pos.Item2;
                    string id = chessPiece.ID + "";




                    if (k != 7)
                    {


                        string data = "[" + name + "," + chessPos + "," + pos + "," + chessPiece.color + $" ID: {id}" + "]";
                        chessBoardString.Append(string.Format("{0,-30}", data));

                    }
                    else
                    {

                        if (name == "Empty")
                        {
                            string data = "[" + name + "," + chessPos + "," + pos + "," + chessPiece.color + $" ID: {id}" + "]" + "\r\n";
                            chessBoardString.Append(string.Format("{0,0}", data));
                        }
                        else
                        {
                            string data = "[" + name + "," + chessPos + "," + pos + "," + chessPiece.color + $" ID: {id}" + "]" + "\r\n";
                            chessBoardString.Append(string.Format("{0,-30}", data));
                        }

                    }
                }
            }
            chessBoardString.Append(numberString + "\r\n");
            return chessBoardString.ToString();
        }
        private List<Tuple<int, int>> pawnOnlyLegalMoves(ChessPiece chessPiece)
        {
            var onlyLegalMoves = new List<Tuple<int, int>>();
            int row = chessPiece.pos.Item1;
            int col = chessPiece.pos.Item2;
            int opponentColor = 1;
            Pawn p = (Pawn)chessPiece;
            ChessPiece chessP = chessPiece;
       
            if (row - 1 >= 0) //Up One
            {
                chessP = chessBoard.Board[row - 1][col];
                if(chessP.name == "Empty")
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row - 2 >= 0 && p.movedTwice == false) //Up Two
            {
                chessP = chessBoard.Board[row - 2][col];
                if (chessP.name == "Empty")
                    onlyLegalMoves.Add(chessP.pos);
            }
            if ((row - 1) >= 0 && (col + 1) <= 7) //Diagonal Up Right
            {
                chessP = chessBoard.Board[row - 1][col + 1];
                if (chessP.name != "Empty" && chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if ((row - 1) >= 0 && (col - 1) >= 0) //Diagonal Up Left
            {
                chessP = chessBoard.Board[row - 1][col - 1];
                if (chessP.name != "Empty" && chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            return onlyLegalMoves;


        }
        private List<Tuple<int, int>> bishopOnlyLegalMoves(ChessPiece chessPiece)
        {
            var onlyLegalMoves = new List<Tuple<int, int>>();
            int row = chessPiece.pos.Item1;
            int col = chessPiece.pos.Item2;
            int opponentColor = 1;
            int i = 1;
  
            ChessPiece chessP = chessPiece;

            while  ((row - i) >= 0 && (col + i) <= 7) //Diagonal Up Right
            {
       
                chessP = chessBoard.Board[row - i][col + i];
                if (chessP.name != "Empty" && chessP.color == opponentColor)
                {
                    onlyLegalMoves.Add(chessP.pos);
                    break;
                }
                else if (chessP.name != "Empty" && chessP.color == opponentColor)
                {
                    break;
                }
                else if (chessP.name == "Empty")
                {
                    onlyLegalMoves.Add(chessP.pos);
                }
                i++;
            
            }
            i = 1;
            while ((row + i) <= 7 && (col + i) <= 7) //Diagonal Down Right
            {
                chessP = chessBoard.Board[row + i][col + i];
                if (chessP.name != "Empty" && chessP.color == opponentColor)
                {
                    onlyLegalMoves.Add(chessP.pos);
                    break;
                }
                else if (chessP.name != "Empty" && chessP.color == opponentColor)
                {
                    break;
                }
                else if (chessP.name == "Empty")
                {
                    onlyLegalMoves.Add(chessP.pos);
                }
                i++;
            }
            i = 1;
            while ((row - i) >= 0 && (col - i) >= 0) //Diagonal Up Left
            {
                chessP = chessBoard.Board[row - i][col - i];
                if (chessP.name != "Empty" && chessP.color == opponentColor)
                {
                    onlyLegalMoves.Add(chessP.pos);
                    break;
                }
                else if (chessP.name != "Empty" && chessP.color == opponentColor)
                {
                    break;
                }
                else if (chessP.name == "Empty")
                {
                    onlyLegalMoves.Add(chessP.pos);
                }
                i++;
            }
            i = 1;
            while ((row + i) <= 7 && (col - i) >= 0) //Diagonal Down Left
            {
                chessP = chessBoard.Board[row + i][col - i];
                if (chessP.name != "Empty" && chessP.color == opponentColor)
                {
                    onlyLegalMoves.Add(chessP.pos);
                    break;
                }
                else if (chessP.name != "Empty" && chessP.color == opponentColor)
                {
                    break;
                }
                else if (chessP.name == "Empty")
                {
                    onlyLegalMoves.Add(chessP.pos);
                }
                i++;
            }
 
            return onlyLegalMoves;
        }
        private List<Tuple<int, int>> rookOnlyLegalMoves(ChessPiece chessPiece)
        {
            var onlyLegalMoves = new List<Tuple<int, int>>();
            int row = chessPiece.pos.Item1;
            int col = chessPiece.pos.Item2;
            int opponentColor = 1;
            int i = 1;

            ChessPiece chessP = chessPiece;

            while (row - i >= 0) //Up
            {
                chessP = chessBoard.Board[row - i][col];
                if (chessP.name == "Empty")
                {
                    onlyLegalMoves.Add(chessP.pos);
                    i++;
                }
                if(chessP.color == opponentColor)
                {
                    onlyLegalMoves.Add(chessP.pos);
                    break;
                }
                if (chessP.color == chessPiece.color)
                    break;
                
            }
                i = 1;
            while (row + i <= 7) //Down
            {
                chessP = chessBoard.Board[row + i][col];
                if (chessP.name == "Empty")
                {
                    onlyLegalMoves.Add(chessP.pos);
                    i++;
                }
                if (chessP.color == opponentColor)
                {
                    onlyLegalMoves.Add(chessP.pos);
                    break;
                }
                if (chessP.color == chessPiece.color)
                    break;

            }
            i = 1;
            while (col + i <= 7) //Right
            {
                chessP = chessBoard.Board[row][col + i];
                if (chessP.name == "Empty")
                {
                    onlyLegalMoves.Add(chessP.pos);
                    i++;
                }
                if (chessP.color == opponentColor)
                {
                    onlyLegalMoves.Add(chessP.pos);
                    break;
                }
                if (chessP.color == chessPiece.color)
                    break;

            }
            i = 1;
            while (col - i >= 0) //Left
            {
                chessP = chessBoard.Board[row][col - i];
                if (chessP.name == "Empty")
                {
                    onlyLegalMoves.Add(chessP.pos);
                    i++;
                }
                if (chessP.color == opponentColor)
                {
                    onlyLegalMoves.Add(chessP.pos);
                    break;
                }
                if (chessP.color == chessPiece.color)
                    break;

            }
            return onlyLegalMoves;
        }
        private List<Tuple<int, int>> queenOnlyLegalMoves(ChessPiece chessPiece)
        {
            var onlyLegalMoves = new List<Tuple<int, int>>();
            List<Tuple<int, int>> upAndDown = new List<Tuple<int, int>>(rookOnlyLegalMoves(chessPiece));
            List<Tuple<int, int>> diagonals = new List<Tuple<int, int>>(bishopOnlyLegalMoves(chessPiece));
           
            return onlyLegalMoves.Concat(upAndDown).Concat(diagonals).ToList();
        }
        private List<Tuple<int, int>> knightOnlyLegalMoves(ChessPiece chessPiece)
        {
            var onlyLegalMoves = new List<Tuple<int, int>>();
            int row = chessPiece.pos.Item1;
            int col = chessPiece.pos.Item2;
            int opponentColor = 1;
            int i = 1;
            ChessPiece chessP = chessPiece;
            if(row - 2 >= 0 && col + 1 <= 7)
            {
                chessP = chessBoard.Board[row - 2][col + 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row - 1 >= 0 && col + 2 <= 7)
            {
                chessP = chessBoard.Board[row - 1][col + 2];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row + 1 <= 7 && col + 2 <= 7)
            {
                chessP = chessBoard.Board[row + 1][col + 2];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row + 2 <= 7 && col + 1 <= 7)
            {
                chessP = chessBoard.Board[row + 2][col + 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row - 2 >= 0 && col - 1 >= 0)
            {
                chessP = chessBoard.Board[row - 2][col - 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row - 1 >= 0 && col - 2 >= 0)
            {
                chessP = chessBoard.Board[row - 1][col - 2];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row + 1 <= 7 && col - 2 >= 0)
            {
                chessP = chessBoard.Board[row + 1][col - 2];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row + 2 <= 7 && col - 1 >= 0)
            {
                chessP = chessBoard.Board[row + 2][col - 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }

            return onlyLegalMoves;
        }
        private List<Tuple<int, int>> kingOnlyLegalMoves(ChessPiece chessPiece)
        {
            var onlyLegalMoves = new List<Tuple<int, int>>();
            int row = chessPiece.pos.Item1;
            int col = chessPiece.pos.Item2;
            int opponentColor = 1;
            ChessPiece chessP = chessPiece;
            if (row - 1 >= 0) //Up
            {
                chessP = chessBoard.Board[row - 1][col];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (row + 1 <= 7) //Down
            {
                chessP = chessBoard.Board[row + 1][col];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (col + 1 <= 7) //Right
            {
                chessP = chessBoard.Board[row][col + 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            if (col - 1 >= 0) //Left
            {
                chessP = chessBoard.Board[row][col - 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }

            if ((row - 1) >= 0 && (col + 1) <= 7) //Diagonal Up Right
            {
                chessP = chessBoard.Board[row - 1][col + 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }

            if ((row - 1) >= 0 && (col - 1) >= 0) //Diagonal Up Left
            {
                chessP = chessBoard.Board[row - 1][col - 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }

            if ((row + 1) <= 7 && (col - 1) >= 0) //Diagonal Down Left
            {
                chessP = chessBoard.Board[row + 1][col - 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }

            if ((row + 1) <= 7 && (col + 1) <= 7) //Diagonal Down Right
            {
                chessP = chessBoard.Board[row + 1][col + 1];
                if (chessP.name == "Empty" || chessP.color == opponentColor)
                    onlyLegalMoves.Add(chessP.pos);
            }
            return onlyLegalMoves;
        }
        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            playingAsWhitePieces = false;
        }

        private void buttonPlayAsWhite_Click(object sender, EventArgs e)
        {
            startGame = true;
            buttonPlayAsWhite.Visible = false;
            labelPlayAsWhite.Visible = false;
            buttonPlayAsBlack.Visible = false;
            labelPlayAsBlack.Visible = false;
            buttonPlayAsRandom.Visible = false;
            labelPlayAsRandom.Visible = false;
            applyInitalPieces();

        }

        private void buttonPlayAsRandom_Click(object sender, EventArgs e)
        {
            startGame = true;

            Random rand = new Random();
            if (rand.Next(0, 2) == 0)
                playingAsWhitePieces = true;
            else
                playingAsWhitePieces = false;

            buttonPlayAsWhite.Visible = false;
            labelPlayAsWhite.Visible = false;
            buttonPlayAsBlack.Visible = false;
            labelPlayAsBlack.Visible = false;
            buttonPlayAsRandom.Visible = false;
            labelPlayAsRandom.Visible = false;
            applyInitalPieces();

        }

        private void buttonPlayAsBlack_Click(object sender, EventArgs e)
        {
            startGame = true;
            playingAsWhitePieces = false;
            buttonPlayAsWhite.Visible = false;
            labelPlayAsWhite.Visible = false;
            buttonPlayAsBlack.Visible = false;
            labelPlayAsBlack.Visible = false;
            buttonPlayAsRandom.Visible = false;
            labelPlayAsRandom.Visible = false;
            applyInitalPieces();
        }

        private void buttonPrintChessBoard_Click(object sender, EventArgs e)
        {
            if (textBoxPrintBoard.Text.Count() == 0)
            {
                textBoxPrintBoard.Visible = true;
                textBoxPrintBoard.Text += printChessBoard();
            }
            else
            {
                textBoxPrintBoard.Visible = false;
                textBoxPrintBoard.Text = "";
            }

        }


    }
}
