using System;
using System.Collections.Generic;
using Game;

namespace Board
{
    class IniciaBoard
    {
        static void Main(string[] args)
        {
            List<Casa> board = new List<Casa>();
            char[] piecesLine = new char[8] {'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'};
            PrintBoard PrintBoard = new PrintBoard();
            GameStart GameStart = new GameStart();
            /* initialize elements of array n */
            for ( int i = 1; i < 9; i++ ) 
            {
                for ( int j = 0; j < 8; j++ ) 
                {
                    Casa slot = new Casa();
                    Piece peca = new Piece();
                    slot.PosLetra = slot.Convert(j); 
                    slot.PosNum = i;
                    if (i == 1 || i == 2)
                        peca.Cor = true;
                    else if (i == 7 || i == 8)
                        peca.Cor = false;
                    if (i == 1 || i == 8)
                        peca.Tipo = piecesLine[j];
                    else if (i == 2 || i == 7)
                        peca.Tipo = 'P';
                    slot.Peca = peca;
                    board.Add(slot);
                }
            }
            PrintBoard.Print(board);
            GameStart.Start(board);
        }
    }
    class PrintBoard 
    {
        public void Print (List<Casa> board) 
        {
            for (int j = 0; j < 8; j++)
            {
                List<Char> line = new List<Char>();
                foreach(Casa block in board)
                    if (block.PosNum == j + 1)
                        line.Add(block.Peca.Tipo != 0 ? block.Peca.Tipo : 'x');
                Console.WriteLine(string.Join(" ", line));
            }
        }
    }
}