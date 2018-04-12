using System;

namespace Board
{
    public class Casa
    {
      public Piece Peca;
      public char PosLetra;
      public int PosNum;
      public char Convert (int j) {
        switch (j)
        {
            case 0:
              return 'a';
            case 1:
              return 'b';
            case 2:
              return 'c';
            case 3:
              return 'd';
            case 4:
              return 'e';
            case 5:
              return 'f';
            case 6:
              return 'g';
            default:
              return 'h';
        }
      }
    }

}
