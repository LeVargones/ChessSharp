using System;
using Pieces.Pieces;

namespace Game
{
    public class Casa
    {
      public Piece Peca;
      public char PosLetra;
      public int PosNum;
      public Casa GeraCasa(int i, int j) {
        Casa slot = new Casa();
        Boolean cor = false;
        if (i == 1 || i == 2)
          cor = true;
        if (i == 1 || i == 8) {
          switch (j)
          {
            case 0:
            case 7:
              slot.Peca = new Tower(cor);
            break;
            case 1:
            case 6:
              slot.Peca = new Knight(cor);
            break;
            case 2:
            case 5:
              slot.Peca = new Bishop(cor);
            break;
            case 3:
              slot.Peca = new Queen(cor);
            break;
            case 4:
              slot.Peca = new King(cor);
            break;
            default:
            break;
          }
        }
        if (i == 2 || i == 7)
          slot.Peca = new Pawn(cor);
            slot.PosLetra = slot.Convert(j); 
            slot.PosNum = i;
        return slot;
		  }
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
