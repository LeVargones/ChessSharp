using System;
using System.Collections.Generic;
using Utils;

namespace Game
{
	static class Board
	{
		public static List<Casa> state = new List<Casa>();
		public static bool CorAtual = true;
		public static Char [] MovimentoAtual = new Char[3];
		public static Char[] AateH = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
		public static Casa StateAtual;
		static Board() 
		{
			Casa casa = new Casa();
			for ( int i = 1; i < 9; i++ ) 
			{
				for ( int j = 0; j < 8; j++ ) 
				{
					state.Add(casa.GeraCasa(i,j));
				}
			}
		}
		public static bool ProcuraPeca(char [] splitedMove, bool Cor)
		{
			CorAtual = Cor;
			foreach (var casa in state)
			{
				if (splitedMove[1] == 'X')
				{
					if (Utilidades.IsPawn(splitedMove, casa, Cor))
					{
						MovimentoAtual[2] = splitedMove[3];
						MovimentoAtual[1] = splitedMove[2];
						MovimentoAtual[0] = 'P';
						StateAtual = casa;
						if (CapturaPeca())
							return true;
					}
					else
					{
						MovimentoAtual[2] = splitedMove[3];
						MovimentoAtual[1] = splitedMove[2];
						MovimentoAtual[0] = splitedMove[0];
						StateAtual = casa;
						if (CapturaPeca())
							return true;
					}
				}
				else if (casa.Peca?.Cor == Cor && casa.Peca?.Tipo == splitedMove[0]) 
				{
					MovimentoAtual = splitedMove;
					StateAtual = casa;
					if (MovePeca())
						return true;
				} 
				else if (Utilidades.IsPawn(splitedMove, casa, Cor))
				{
					MovimentoAtual[2] = splitedMove[1];
					MovimentoAtual[1] = splitedMove[0];
					MovimentoAtual[0] = 'P';
					StateAtual = casa;
					if (MovePeca())
						return true;
				}
			}
			Console.WriteLine("Movimento Inválido, por favor insira outro!");
			return false;
		}

		public static bool CapturaPeca()
		{ 
			if (StateAtual.Peca.checkMove(StateAtual, MovimentoAtual)) 
			{
				int ChecaColisao = Board.ChecaColisao();
				if (ChecaColisao == 1)
				{
					Console.WriteLine("Movimento Inválido, por favor insira outro!");
					return false;
				} 
				else if (ChecaColisao == 0)
				{
					Console.WriteLine("Não tem nenhuma peça a ser tomada, não utilize o X!");
					return false;
				} 
				else
				{ 
					Utilidades.Movimenta();
					return true;
				}
			}
			else 
			{
				Console.WriteLine("Movimento Inválido, por favor insira outro!");
				return false;
			}
		}
		public static bool MovePeca()
		{
			if (StateAtual.Peca.checkMove(StateAtual, MovimentoAtual)) 
			{
				int ChecaColisao = Board.ChecaColisao();
				if (ChecaColisao == 1)
				{
					Console.WriteLine("Movimento Inválido, por favor insira outro!");
					return false;
				} 
				else if (ChecaColisao == 0)
				{
					Utilidades.Movimenta();
					return true;
				} 
				else
				{
					Console.WriteLine("Para tomar uma peça, utilize o X no movimento!");
					return false;
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
			foreach (var state in state)
				if (state.PosNum == (int) MovimentoAtual[2] - '0' && state.PosLetra == MovimentoAtual[1]) {
					if (state.Peca?.Cor == null)
						return 0;
					return ((state.Peca?.Cor == CorAtual) ? 1 : -1);
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
	}
}