using System;
using Game;

namespace Pieces.Pieces
{
    class Bishop : Piece
    {
      public Bishop (bool Cor)
        {
          this.Cor = Cor;
          this.Tipo = 'B';
        }

      public override bool checkMove (Casa StateAtual, Char[] moveSplited) {
        Console.WriteLine("Bispo");
        return true;
      }
    }
}
