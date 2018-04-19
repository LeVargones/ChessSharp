using System;
using Game;

namespace Pieces.Pieces
{
    class Pawn : Piece
    {
      public Pawn (bool Cor)
        {
          this.Cor = Cor;
          this.Tipo = 'P';
        }

      public override bool checkMove (Casa StateAtual, Char[] moveSplited) {
        Console.WriteLine("Peao");
        return true;
      }
    }
}
