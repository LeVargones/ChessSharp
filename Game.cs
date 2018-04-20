using System;
using System.Collections.Generic;
using Utils;

namespace Game
{
    public class GameStart
    {
      static void Main(string[] args) 
      {
        bool CorAtual = true;
        while (true)
        {
          Utilidades.PrintBoard();
          Console.WriteLine("Insira um movimento"); 
          string movimento = Console.ReadLine().ToUpper();
          // Fazer o tratamento da string do movimento, atualizar o tabuleiro para re-impressão
          Char[] moveSplited = movimento.ToCharArray();
          if (Board.ProcuraPeca(moveSplited, CorAtual))
            CorAtual = !CorAtual;
        }
      }
    }
}
