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
		public static int IsPawn(char[] splitedMove, Casa casa, bool Cor)
		{
			if (Array.IndexOf(Board.AateH, splitedMove[0]) > -1)
			{
				return (casa.Peca?.Cor == Cor 
								&& casa.Peca?.Tipo == 'P' 
								&& casa.PosLetra == splitedMove[0]) ? 1 : -1;
			}
			else 
				return 0;
		}		
    public static int MovePeca(bool Captura)
		{
			if (Board.StateAtual.Peca == null)
				return 0;
			int ChecaColisao = Utilidades.ChecaColisao();
			// Se tem peça da mesma cor
			if (ChecaColisao == 1)
				return -1;
			// Se não tem peça
			else if (ChecaColisao == 0)
			{
				if (Captura)
				// Se for pra capturar e não tem peça da erro
					return -1;
				else
				// Senão tenta mover a peça
				{
					if (Board.StateAtual.Peca.checkMove(Board.StateAtual, Board.MovimentoAtual)) 
					{
						Movimenta();
						return 1;
					}
				}
			} 
			else
			// Se tem peça da outra cor
			{	
				if (!Captura)
					return -1;
				else
				{
					if (Board.StateAtual.Peca.checkMove(Board.StateAtual, Board.MovimentoAtual)) 
					{
						Movimenta();
						return 1;
					}
				}
			}
			return 0;
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