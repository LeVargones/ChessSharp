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
    public static bool MovePeca(bool Captura)
		{
			if (Board.StateAtual.Peca.checkMove(Board.StateAtual, Board.MovimentoAtual)) 
			{
				int ChecaColisao = Utilidades.ChecaColisao();
				if (ChecaColisao == 1)
				{
					Console.WriteLine("Movimento Inválido, por favor insira outro!");
					return false;
				} 
				else if (ChecaColisao == 0)
				{
					if (Captura)
						Console.WriteLine("Não tem nenhuma peça a ser tomada, não utilize o X!");
					else
						Movimenta();
					return !Captura;
				} 
				else
				{
					if (!Captura)
						Console.WriteLine("Para tomar uma peça, utilize o X no movimento!");
					else
						Movimenta();
					return Captura;
				}
			}
			else 
			{
				Console.WriteLine("Movimento Inválido, por favor insira outro!");
				return false;
			}
		}
    public static int ChecaColisao() 
		{
			foreach (var state in Board.state)
				if (state.PosNum == (int) Board.MovimentoAtual[2] - '0' && state.PosLetra == Board.MovimentoAtual[1]) {
					if (state.Peca?.Cor == null)
						return 0;
					return ((state.Peca?.Cor == Board.CorAtual) ? 1 : -1);
				}
			return 0;
		}
		public static bool ChecaCheque() 
		{
			// foreach (var state in state)
			// {
			//     if ((char) state.PosNum == MovimentoAtual[2] && state.PosLetra == MovimentoAtual[1])
			//     {
			//         return ((state.Peca?.Cor == CorAtual) ? true : ChecaCheque());
			//     }
			// }
			return false;
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