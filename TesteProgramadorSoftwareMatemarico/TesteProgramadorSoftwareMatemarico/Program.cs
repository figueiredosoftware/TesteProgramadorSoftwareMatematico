using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteProgramadorSoftwareMatemarico
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            while ((op = escolheOpcao()) != 5 )
            {
                switch (op)
                {
                    case 1:
                        Console.Write("\n ==================");
                        Console.Write("\n Executando Teste 1");
                        Console.Write("\n ==================");
                        Console.Write("\n Prim: ");
                        int prim = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\n Razao: ");
                        int razao = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\n Posicao: ");
                        int posicao = Convert.ToInt32(Console.ReadLine());
                        int pa = funcaoPA(prim, razao, posicao);
                        Console.Write("\n Resultado da funcao PA(" + prim + "," + razao + "," + posicao + "): " + pa);
                        Console.Write("\n\n\n");
                        break;
                    case 2:
                        Console.Write("\n ==================");
                        Console.Write("\n Executando Teste 2");
                        Console.Write("\n ==================");
                        resultadoExpressoes(true, true, false);
                        Console.Write("\n\n\n");
                        break;
                    case 3:
                        Console.Write("\n ==================");
                        Console.Write("\n Executando Teste 3");
                        Console.Write("\n ==================");
                        Console.Write("\n Valor de elementos do vetor A: ");
                        int qtdElementosVetorA = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\n Valor de elementos do vetor B: ");
                        int qtdElementosVetorB = Convert.ToInt32(Console.ReadLine());
                        int[] a = new int[qtdElementosVetorA];
                        int[] b = new int[qtdElementosVetorB];
                        bool resultado = Parece(a, qtdElementosVetorA, b, qtdElementosVetorB);
                        if (resultado)
                        {
                            Console.Write("\n Valores são PARECIDOS entre os vetores");
                        }
                        else
                        {
                            Console.Write("\n Valores NÃO são PARECIDOS entre os vetores");
                        }
                        break;
                    case 4:
                        Console.Write("\n ==================");
                        Console.Write("\n Executando Teste 4");
                        Console.Write("\n ==================");
                        Console.Write("\n Valor de elementos do vetor Vetor1 : ");
                        int nVetor1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\n Valor de elementos do vetor Vetor2: ");
                        int nVetor2 = Convert.ToInt32(Console.ReadLine());
                        int[] Vetor1 = new int[nVetor1];
                        int[] Vetor2 = new int[nVetor2];
                        Vetor1 = carregaVetor1(nVetor1); //carrega Vetor1
                        Vetor2 = carregaVetor2(nVetor2); //carrega Vetor2
                        int qtdValoresComuns = calculaQtdValoresComuns(Vetor1, Vetor2);
                        int[] Vetor3 = new int[qtdValoresComuns];
                        Vetor3 = geraVetor3(Vetor1, Vetor2, Vetor3);
                        break;
                }
            }
        }

        static int escolheOpcao()
        {
            int op = 0;

            Console.Write("\n TESTE PARA PROGRAMADOR");
            Console.Write("\n ======================");
            Console.Write("\n 1 - Teste 1");
            Console.Write("\n 2 - Teste 2");
            Console.Write("\n 3 - Teste 3");
            Console.Write("\n 4 - Teste 4");
            Console.Write("\n 5 - Sair");
            Console.Write("\n Escolha a opção :");

            string opcao = Console.ReadLine();
            if(opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4" || opcao == "5")
            {
                op = Convert.ToInt32(opcao);
            }
            else
            {
                Console.Write("\n Valor inválido, valor deve ser entre 1 e 5. Digite um valor válido :");
            }

            return op;
        }

        static int funcaoPA(int prim, int razao, int posicao)
        {
            int resultado = prim;

            Console.WriteLine("\n Progressão PA: ");
            for (int i=1; i<posicao; i++)
            {
                Console.WriteLine(resultado + " ");
                resultado += razao;
            }
            Console.WriteLine("\n" + resultado + " ");

            return resultado;
        }

        static void resultadoExpressoes(bool a, bool b, bool c)
        {
            Console.WriteLine("\n Sendo A = True, B = True e C = False");
            Console.WriteLine("\n ------------------------------------");
            Console.WriteLine("\n a) (A ou B) e (A e C) : ");

            if((a || b) && (a && c))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            Console.WriteLine("\n não B ou (A ou C) : ");
            if ((!b) || (a || c))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        static bool Parece(int[] a, int qtdElementosVetorA,  int[] b, int qtdElementosVetorB)
        {
            bool resultado = false;
            bool resultadoParcialA = false;
            bool resultadoParcialB = false;
            int contadorA = 0;
            int contadorB = 0;

            //Carrega e mostra vetor A
            Console.WriteLine("\nCarrega valores do vetor A de tamanho " + qtdElementosVetorA);
            Console.WriteLine("\n--------------------------");
            for (int i = 0; i < qtdElementosVetorA; i++)
            {
                Console.WriteLine("\nA[" + i + "]: ");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nValores do Vetor A : ");
            foreach(int valores in a)
            {
                Console.Write(valores + ", ");
            }
            Console.Write("\n");

            //Carrega e mostra vetor B
            Console.WriteLine("\nCarrega valores do vetor B de tamanho " + qtdElementosVetorB);
            Console.WriteLine("\n--------------------------");
            for (int i = 0; i < qtdElementosVetorB; i++)
            {
                Console.WriteLine("\nB[" + i + "]: ");
                b[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nValores do Vetor B : ");
            foreach (int valores in b)
            {
                Console.Write(valores + ", ");
            }
            Console.Write("\n");

            decimal qtdElementosDe90DeA = (qtdElementosVetorA * 90) / 100;
            decimal qtdElementosDe80DeB = (qtdElementosVetorB * 80) / 100;

            //verifica se 90% dos elementos de A estejam em B
            foreach(int valoresA in a)
            {
                foreach(int valoresB in b)
                {
                    if(valoresA == valoresB)
                    {
                        contadorA++;
                        break;
                    }
                }
            }

            if (contadorA >= qtdElementosDe90DeA) resultadoParcialA = true;

            //verifica se 80% dos elementos de B estejam em A
            foreach (int valoresB in b)
            {
                foreach (int valoresA in a)
                {
                    if (valoresB == valoresA)
                    {
                        contadorB++;
                        break;
                    }
                }
            }

            if (contadorB >= qtdElementosDe80DeB) resultadoParcialB = true;

            //Conclusão do Cálculo
            if (resultadoParcialA && resultadoParcialB) resultado = true;

            return resultado;
        }

        static int[] carregaVetor1(int nVetor1)
        {
            int[] Vetor1 = new int[nVetor1];
            //Carrega e mostra vetor Vetor1
            Console.WriteLine("\nCarrega valores do vetor Vetor1 de tamanho " + nVetor1);
            Console.WriteLine("\n--------------------------");
            for (int i = 0; i < nVetor1; i++)
            {
                Console.WriteLine("\nVetor1[" + i + "]: ");
                Vetor1[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nValores do Vetor Vetor1 : ");
            foreach (int valores in Vetor1)
            {
                Console.Write(valores + ", ");
            }
            Console.Write("\n");

            return Vetor1;
        }

        static int[] carregaVetor2(int nVetor2)
        {
            int[] Vetor2 = new int[nVetor2];
            //Carrega e mostra vetor Vetor2
            Console.WriteLine("\nCarrega valores do vetor Vetor2 de tamanho " + nVetor2);
            Console.WriteLine("\n--------------------------");
            for (int i = 0; i < nVetor2; i++)
            {
                Console.WriteLine("\nVetor2[" + i + "]: ");
                Vetor2[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nValores do Vetor Vetor2 : ");
            foreach (int valores in Vetor2)
            {
                Console.Write(valores + ", ");
            }
            Console.Write("\n");

            return Vetor2;
        }

        static int calculaQtdValoresComuns(int[] Vetor1, int[] Vetor2)
        {
            int contador = 0;
            foreach(int valoresVetor1 in Vetor1)
            {
                foreach(int valoresVetor2 in Vetor2)
                {
                    if (valoresVetor1 == valoresVetor2) contador++;
                }
            }
            return contador;
        }

        static int[] geraVetor3(int[] Vetor1, int[] Vetor2, int[] Vetor3)
        {
            int indice = 0;
            //gera Vetor3
            foreach (int valoresVetor1 in Vetor1)
            {
                foreach (int valoresVetor2 in Vetor2)
                {
                    if (valoresVetor1 == valoresVetor2)
                    {
                        Vetor3[indice] = valoresVetor1;
                        indice++;
                    }
                }
            }

            //Mostra valor do Vetor3
            Console.Write("\nElementos do Vetor3:");
            Console.Write("\n--------------------");
            Console.Write("\n");
            foreach (int valoresVetor3 in Vetor3)
            {
                Console.Write(valoresVetor3 + " ");
            }

            //ordena Vetor3
            int aux = 0;
            for(int j=0; j < Vetor3.Length; j++)
            {
                for (int i = 0; i < Vetor3.Length - 1; i++)
                {
                    if (Vetor3[i] > Vetor3[i + 1])
                    {
                        aux = Vetor3[i];
                        Vetor3[i] = Vetor3[i + 1];
                        Vetor3[i + 1] = aux;
                    }
                }
            }

            //Mostra valor do Vetor3 ordenado
            Console.Write("\nElementos do Vetor3:");
            Console.Write("\n--------------------");
            Console.Write("\n");
            foreach (int valoresVetor3 in Vetor3)
            {
                Console.Write(valoresVetor3 + " ");
            }

            return Vetor3;
        }
    }
}
