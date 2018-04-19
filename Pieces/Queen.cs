using System;
using Game;

namespace Pieces.Pieces
{
    class Queen : Piece
    {
      public Queen (bool Cor)
        {
          this.Cor = Cor;
          this.Tipo = 'Q';
        }

      public override bool checkMove (Casa StateAtual, Char[] moveSplited) {
        Console.WriteLine("Dama");
        return true;
      }
    }
}
