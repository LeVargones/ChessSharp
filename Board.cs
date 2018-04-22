using System;
using System.Collections.Generic;
using Utils;

namespace Game
{
	static class Board
	{
		public static List<Casa> state = new List<Casa>();
		public static bool CorAtual = true;
		public static Char[] AateH = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
		public static Casa StateAtual;
		public static Char [] MovimentoAtual = new Char[3];
		
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
			int MovePeca = 0;
			foreach (var casa in state)
			{
				Array.Clear(MovimentoAtual, 0, 0);
				bool Captura = false;
				if (casa.Peca != null)
				{
					StateAtual = casa;
					MovimentoAtual[0] = splitedMove[0];
					int isPawn = Utilidades.IsPawn(splitedMove, casa, Cor);
					if (isPawn == 1)
					{
						MovimentoAtual[2] = splitedMove[1];
						MovimentoAtual[1] = splitedMove[0];
						MovimentoAtual[0] = 'P';
					}
					if (splitedMove[1] == 'X')
					{
						Captura = true;
						MovimentoAtual[2] = splitedMove[3];
						MovimentoAtual[1] = splitedMove[2];
						MovimentoAtual[0] = MovimentoAtual[0] == 'P' ? 'P' : splitedMove[0];
					}
					if (isPawn != -1)
					{
						MovePeca = Utilidades.MovePeca(Captura);
						if (casa.Peca?.Cor == Cor && casa.Peca?.Tipo == MovimentoAtual[0]) 
						{
							if (MovimentoAtual[0] == '0')
								MovimentoAtual = splitedMove;
							if (MovePeca != 0)
								break;
						} 
					}
				}
			}
		 	if (MovePeca == 1)
				return true;
			Console.WriteLine("Movimento Inválido, por favor insira outro!");
			return false;
		}
	}
}