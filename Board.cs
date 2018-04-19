using System;
using System.Collections.Generic;
using Pieces.Pieces;

namespace Game
{
    static class Board
    {
        static List<Casa> state = new List<Casa>();
        public static bool CorAtual = true;
        public static Char [] MovimentoAtual = new Char[3];
        public static Casa StateAtual;
        static Board() 
        {
            for ( int i = 1; i < 9; i++ ) 
            {
                for ( int j = 0; j < 8; j++ ) 
                {
                    state.Add(GeraCasa(i,j));
                }
            }
        }
        public static Casa GeraCasa (int i, int j) {
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
        public static bool ProcuraPeca (char [] splitedMove, bool Cor)
        {
            CorAtual = Cor;
            foreach (var casa in state)
            {
                if (casa.Peca?.Cor == Cor && casa.Peca?.Tipo == splitedMove[0]) 
                {
                    MovimentoAtual = splitedMove;
                    StateAtual = casa;
                    return MovePeca();
                } 
                else if (splitedMove[0] == 'A' || splitedMove[0] == 'B' || splitedMove[0] == 'C' || splitedMove[0] == 'D' || splitedMove[0] == 'E' || splitedMove[0] == 'F' || splitedMove[0] == 'G' ||splitedMove[0] == 'H')
                {
                    if (casa.Peca?.Cor == Cor && casa.Peca?.Tipo == 'P' && casa.PosLetra == splitedMove[0])
                    {
                        MovimentoAtual[2] = splitedMove[1];
                        MovimentoAtual[1] = splitedMove[0];
                        MovimentoAtual[0] = 'P';
                        StateAtual = casa;
                        return MovePeca();
                    }
                }
            }
            Console.WriteLine("Movimento Inválido, por favor insira outro!");
            return false;
        }
        public static bool MovePeca ()
        {
            if (StateAtual.Peca.checkMove(StateAtual, MovimentoAtual)) 
            {
                if (ChecaColisao())
                {
                    Console.WriteLine("Movimento Inválido, por favor insira outro!");
                    return false;
                } 
                else 
                {
                    foreach (var casaNova in state)
                    {
                        if (casaNova.PosLetra == MovimentoAtual[1] && casaNova.PosNum == (int) MovimentoAtual[2] - '0')
                         {
                            casaNova.Peca = StateAtual.Peca;
                            StateAtual.Peca = null;
                        }
                        
                    }
                    return true;
                }
            }
            else 
            {
                Console.WriteLine("Movimento Inválido, por favor insira outro!");
                return false;
            }
        }
        public static bool ChecaColisao () {
            foreach (var state in state)
                if (state.PosNum == (int) MovimentoAtual[2] - '0' && state.PosLetra == MovimentoAtual[1])
                    return ((state.Peca?.Cor == CorAtual) ? true : ChecaCheque());
            return ChecaCheque();
        }
        public static bool ChecaCheque () {
            // foreach (var state in state)
            // {
            //     if ((char) state.PosNum == MovimentoAtual[2] && state.PosLetra == MovimentoAtual[1])
            //     {
            //         return ((state.Peca?.Cor == CorAtual) ? true : ChecaCheque());
            //     }
            // }
            return false;
        }
        public static void PrintBoard ()
        {
            List<Char> line = new List<Char>();
            for (int j = state.Count - 1; j >= 0; j--)
            {
                if (j % 8 != 0)
                    line.Add(state[j].Peca?.Tipo != null ? state[j].Peca.Tipo : 'x');
                else
                {
                    line.Add(state[j].Peca?.Tipo != null ? state[j].Peca.Tipo : 'x');
                    Console.WriteLine(string.Join(" ", line));
                    line = new List<Char>();
                }
            }
        }
    }
}