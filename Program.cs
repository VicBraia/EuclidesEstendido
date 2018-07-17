using System;
using System.Collections.Generic;

namespace Euclides_Estendido
{
    class Program
    {
        public static int num1, num2, tam;
        public static string[] line;
        public static int[] r = new int[10000];
        public static int[] q = new int[10000];
        public static int[] m = new int[10000];
        public static int[] n = new int[10000];

        public static void InicializaListas()
        {
            r[0] = num1;
            r[1] = num2;
            q[0] = q[1] = 0;
            m[0] = n[1] = 1;
            m[1] = n[0] = 0;
        }

        public static void CalculaQ(int i) //calcula o quociente de cada etapa
        {
            q[i + 1] = r[i - 1] / r[i];
        }

        public static void CalculaR(int i) //calcula o resto de cada etapa
        {
            r[i + 1] = r[i - 1] % r[i];
        }

        public static void CalculaM(int i) //calcula o m de cada etapa
        {
            m[i + 1] = m[i - 1] - (q[i + 1] * m[i]);
        }

        public static void CalculaN(int i) //calcula o n de cada etapa
        {
            n[i + 1] = n[i - 1] - (q[i + 1] * n[i]);
        }

        public static void CalculaEuclidesEstendido()
        {
            int i = 1;
            while (r[i - 1] % r[i] != 0) //até encontrar o MDC 
            {
                CalculaQ(i); //calcula o quociente
                CalculaR(i); //calcula o resto
                CalculaM(i); //calcula o m
                CalculaN(i); //calcula o n
                i++;            //tal que num1*m + num2*n = 
            }
            tam = i;
            CalculaQ(i); //a última linha da tabela que contém o mod = 0
            CalculaR(i);
            CalculaM(i);
            CalculaN(i);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Insira os números a e b:");
            line = Console.ReadLine().Split();
            num1 = int.Parse(line[0]);
            num2 = int.Parse(line[1]);

            InicializaListas(); //inicializa as posições 0 e 1 de cada coluna da tabela pra iniciar o passo-a-passo do algoritmo
            CalculaEuclidesEstendido(); //passo a passo do algoritmo
            Console.WriteLine("MDC = " + r[tam]);
            Console.WriteLine("m = " + m[tam]);
            Console.WriteLine("n = " + n[tam]);
            Console.WriteLine("tal que " + num1 + " * " + m[tam] + " + " + num2 + " * " + n[tam] + " = MDC(" + num1 + "," + num2 + ") = " + r[tam]);

        }
    }
}
