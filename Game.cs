using System;
using System.Collections.Generic;
using Pieces;
using Board;

namespace Game
{
    public class GameStart
    {
      public void Start(List<Casa> board) {
          GameStart GameStart = new GameStart();
          Console.WriteLine("Insira um movimento"); 
          string movimento = Console.ReadLine().ToLower();
          // Fazer o tratamento da string do movimento, atualizar o tabuleiro para re-impressão
          Char[] moveSplited = movimento.ToCharArray();
          GameStart.interpMove(board, moveSplited);
        }

      public void interpMove (List<Casa> board, Char[] moveSplited) {
        GameStart GameStart = new GameStart();
        switch (moveSplited[0])
        {
          // Torre
            case 'r':
              Console.WriteLine("Torre");
            break;
          // Cavalo
            case 'n':
              Knight.checkMove(moveSplited);
              Console.WriteLine("Cavalo");
            break;
          // Bispo
            case 'b':
              Console.WriteLine("Bispo");
            break;
          // Rei
            case 'k':
              Console.WriteLine("Rei");
            break;
          // Dama
            case 'q':
              Console.WriteLine("Dama");
            break;
          // Peão
            default:
              Console.WriteLine("Peão");
            break;
        }
        GameStart.Start(board);
      }
    }
}
