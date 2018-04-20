using System;
using System.Collections.Generic;
using Game;

namespace Utils
{
	static class Utilidades
	{	
		public static void Movimenta()
		{
			foreach (var casaNova in Board.state)
				{
					if (casaNova.PosLetra == Board.MovimentoAtual[1] && casaNova.PosNum == (int) Board.MovimentoAtual[2] - '0')
						{
						casaNova.Peca = Board.StateAtual.Peca;
						Board.StateAtual.Peca = null;
					}
				}
		}
		public static bool IsPawn(char[] splitedMove, Casa casa, bool Cor)
		{
			return (Array.IndexOf(Board.AateH, splitedMove[0]) > -1 
								&& casa.Peca?.Cor == Cor 
								&& casa.Peca?.Tipo == 'P' 
								&& casa.PosLetra == splitedMove[0]) ? true : false;
		}
		public static void PrintBoard()
		{
			List<Char> line = new List<Char>();
			for (int j = Board.state.Count - 1; j >= 0; j--)
			{
				if (j % 8 != 0)
					line.Add(Board.state[j].Peca?.Tipo != null ? Board.state[j].Peca.Tipo : 'x');
				else
				{
					line.Add(Board.state[j].Peca?.Tipo != null ? Board.state[j].Peca.Tipo : 'x');
					line.Reverse();
					Console.WriteLine(string.Join(" ", line));
					line = new List<Char>();
				}
			}
		}
  }
}