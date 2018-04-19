using System;
using Game;

namespace Pieces.Pieces
{
    public class Piece
    {
      private char _Tipo;
      private bool _Cor;

      public virtual bool checkMove (Casa StateAtual, Char[] moveSplited) {return true;}
      
      public virtual string Move()
      {
        return "ad";
      }
      public char Tipo
      {
        get {return _Tipo;}
        set {_Tipo = value;}
      }
      public bool Cor
      {
        get {return _Cor;}
        set {_Cor = value;}
      }
    }
}
