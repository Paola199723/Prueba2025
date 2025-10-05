using System;
using System.Collections.Generic;

    public class Ejercicio2
    {
        public int[] CalcularIndices(int[] numeros, int destino)
        {
            Dictionary<int, int> mapa = new Dictionary<int, int>();

            for (int i = 0; i < numeros.Length; i++)
            {
                int complemento = destino - numeros[i];

                if (mapa.ContainsKey(complemento))
                {
                    // Devuelve los índices de los dos números que suman el destino
                    return new int[] { mapa[complemento], i };
                }

                if (!mapa.ContainsKey(numeros[i]))
                    mapa[numeros[i]] = i;
            }

            // Si no hay combinación que sume el destino
            return Array.Empty<int>();
        }
    }

