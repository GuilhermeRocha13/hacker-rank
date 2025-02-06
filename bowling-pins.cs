using System;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        int numTestes = int.Parse(Console.ReadLine());

        while (numTestes-- > 0)
        {
            int numPinos = int.Parse(Console.ReadLine());
            string configPinos = Console.ReadLine();

            List<int> gruposPinos = new List<int>();
            int contadorPinos = 0;

            for (int i = 0; i < numPinos; i++)
            {
                if (configPinos[i] == 'I')
                {
                    contadorPinos++;
                }
                else if (contadorPinos > 0)
                {
                    gruposPinos.Add(contadorPinos);
                    contadorPinos = 0;
                }
            }

            if (contadorPinos > 0)
            {
                gruposPinos.Add(contadorPinos);
            }


            int XOR = 0;
            foreach (int grupo in gruposPinos)
            {
                XOR ^= CalcularGrundy(grupo);
            }

            Console.WriteLine(XOR == 0 ? "LOSE" : "WIN");
        }
    }

    static int CalcularGrundy(int tamanhoGrupo)
    {

        List<int> valGrundy = new List<int>();

        for (int i = 1, parteEsquerda = 0, parteDireita = 0; i <= tamanhoGrupo; i++)
        {
            int grundyEsquerda, grundyDireita;
            if (i <= tamanhoGrupo / 2)
            {
                grundyEsquerda = CalcularGrundy(parteEsquerda);
                grundyDireita = CalcularGrundy(tamanhoGrupo - parteEsquerda - 2);
                parteEsquerda++;
            }
            else
            {
                grundyEsquerda = CalcularGrundy(parteDireita);
                grundyDireita = CalcularGrundy(tamanhoGrupo - parteDireita - 1);
                parteDireita++;
            }
            valGrundy.Add(grundyEsquerda ^ grundyDireita);
        }

        return CalcularMex(valGrundy);
    }
    static int CalcularMex(List<int> valGrundy)
    {
        int mex = 0;
        while (valGrundy.Contains(mex))
            mex++;
        return mex;
    }
}
