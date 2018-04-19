using System;
using Game;

namespace Pieces.Pieces
{
    class Tower : Piece
    {
      public Tower (bool Cor)
        {
          this.Cor = Cor;
          this.Tipo = 'R';
        }

      public override bool checkMove (Casa StateAtual, Char[] moveSplited) {
        Console.WriteLine("Torre");
        return true;
      }
    }
}
