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
				for ( int j = 0; j < 8; j++ ) 
					state.Add(casa.GeraCasa(i,j));
		}
		public static bool ProcuraPeca(char [] splitedMove, bool Cor)
		{
			CorAtual = Cor;
			foreach (var casa in state)
			{
				bool Captura = false;
				if (splitedMove[1] == 'X')
				{
					Captura = true;
					if (Utilidades.IsPawn(splitedMove, casa, Cor))
					{
						MovimentoAtual[2] = splitedMove[3];
						MovimentoAtual[1] = splitedMove[2];
						MovimentoAtual[0] = 'P';
						StateAtual = casa;
						if (Utilidades.MovePeca(Captura))
							return true;
					}
					else
					{
						MovimentoAtual[2] = splitedMove[3];
						MovimentoAtual[1] = splitedMove[2];
						MovimentoAtual[0] = splitedMove[0];
						StateAtual = casa;
						if (Utilidades.MovePeca(Captura))
							return true;
					}
				}
				else if (casa.Peca?.Cor == Cor && casa.Peca?.Tipo == splitedMove[0]) 
				{
					MovimentoAtual = splitedMove;
					StateAtual = casa;
					if (Utilidades.MovePeca(Captura))
						return true;
				} 
				else if (Utilidades.IsPawn(splitedMove, casa, Cor))
				{
					MovimentoAtual[2] = splitedMove[1];
					MovimentoAtual[1] = splitedMove[0];
					MovimentoAtual[0] = 'P';
					StateAtual = casa;
					if (Utilidades.MovePeca(Captura))
						return true;
				}
			}
			Console.WriteLine("Movimento Inválido, por favor insira outro!");
			return false;
		}
	}
}