using System;
using Pieces.Pieces;

namespace Game
{
    public class Casa
    {
      public Piece Peca;
      public char PosLetra;
      public int PosNum;
      public char Convert (int j) {
        string returnValue;
        switch (j)
        {
            case 0:
              returnValue = "a";
            break;
            case 1:
              returnValue = "b";
            break;
            case 2:
              returnValue = "c";
            break;
            case 3:
              returnValue = "d";
            break;
            case 4:
              returnValue = "e";
            break;
            case 5:
              returnValue = "f";
            break;
            case 6:
              returnValue = "g";
            break;
            default:
              returnValue = "h";
            break;
        }
        return (char) returnValue.ToUpper()[0];
      }
    }

}
