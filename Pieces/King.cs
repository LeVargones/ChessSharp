using System;
using Game;

namespace Pieces.Pieces
{
    class King : Piece
    {
      public King (bool Cor)
        {
          this.Cor = Cor;
          this.Tipo = 'K';
        }

      public override bool checkMove (Casa StateAtual, Char[] moveSplited) {
        Console.WriteLine("Rei");
        return true;
      }
    }
}
