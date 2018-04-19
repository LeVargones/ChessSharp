using System;
using Game;

namespace Pieces.Pieces
{
    class Knight : Piece
    {
      public Knight (bool Cor)
        {
          this.Cor = Cor;
          this.Tipo = 'N';
        }

      public override bool checkMove (Casa StateAtual, Char[] moveSplited) {
        Console.WriteLine("Cavalo");
        return true;
      }
    }
}
