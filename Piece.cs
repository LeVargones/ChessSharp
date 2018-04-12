using System;

namespace Board
{
    public class Piece
    {
      private char _Tipo;
      private bool _Cor;

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
