using System;
using System.IO;

namespace MatrizNome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] proj = new string[3, 3];
            do
            {
                string menu = Menu();

                switch (menu)
                {
                    case "1":
                        Inserir(proj);
                        break;

                    case "2":
                        Imprimir(proj);
                        break;

                    case "3":
                        BuscaLinha(proj);
                        break;

                    case "4":
                        BuscaColuna(proj);
                        break;

                    case "5":
                        Buscar(proj);
                        break;

                    case "6":
                        Ordenar(proj);
                        break;


                    case "7":
                        Exportar(proj);
                        break;


                    case "8":
                        Importar(proj);
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Opção invalida. Tente novamente.");
                        break;
                }
                if (menu == "0")
                    break;
            } while (true);
        }

        private static string Menu()
        {
            Console.WriteLine(">>>Tabela de Nomes<<<\nEscolha a opção desejada:");
            Console.WriteLine("1 - Ler os nomes e inserir na tabela\n2 - Imprimir a tabela completa\n3 - Escolher uma linha da tabela para imprimir");
            Console.WriteLine("4 - Escolher uma coluna da tabela para imprimir\n5 - Procurar um nome para saber sua posição na Tabela\n6 - Escolher uma linha para ordenar os nomes");
            Console.WriteLine("7 - Gravar os dados em formato .txt\n8 - Ler um arquivo .txt com os dados\n0 - Sair");
            string menu = Console.ReadLine();
            Console.Clear();
            return menu;
        }

        private static void Importar(string[,] proj)
        {
            Console.Clear();
            string linha;

            try
            {

                StreamReader sr = new StreamReader("c:\\Users\\Everton Fabricio\\Desktop\\MatrizNome.txt");
                linha = sr.ReadLine();

                do
                {
                    for (int l = 0; l < proj.GetLength(0); l++)
                    {
                        for (int c = 0; c < proj.GetLength(1); c++)
                        {
                            proj[l, c] = linha;
                            linha = sr.ReadLine();
                        }
                    }
                } while (linha != null);
                sr.Close();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Deu ruim: >>> " + erro);
            }
            finally
            {
                Console.WriteLine("Importação concluída com sucesso.\n\n");
            }
        }

        private static void Exportar(string[,] proj)
        {
            Console.Clear();

            StreamWriter sw = new StreamWriter("c:\\Users\\Everton Fabricio\\Desktop\\MatrizNome.txt");
            bool flag2 = false;

            for (int l = 0; l < proj.GetLength(0); l++)
            {
                for (int c = 0; c < proj.GetLength(1); c++)
                {
                    try
                    {
                        sw.WriteLine($"{proj[l, c]}");
                        flag2 = true;
                    }
                    catch (Exception erro)
                    {
                        Console.WriteLine("Deu ruim: >>> " + erro);
                        flag2 = false;
                    }
                }
            }
            sw.Close();
            if (flag2 == true)
            {
                Console.WriteLine("Tabela exportada com sucesso.\n\n");
            }
        }

        private static void Ordenar(string[,] proj)
        {
            Console.Write("Digite o numero da linha que gostaria de ordenar: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice < 1 || choice > proj.GetLength(0))
            {
                Console.WriteLine("\nOpção invalida. Tente novamente.");
            }
            else
            {
                choice--;

                for (int colRef = 0; colRef < proj.GetLength(1); colRef++)
                {
                    for (int colComp = colRef + 1; colComp < proj.GetLength(1); colComp++)
                    {
                        if (String.Compare(proj[choice, colRef], proj[choice, colComp], StringComparison.Ordinal) > 0)
                        {
                            string aux = proj[choice, colRef];
                            proj[choice, colRef] = proj[choice, colComp];
                            proj[choice, colComp] = aux;
                        }
                    }
                }
                Console.WriteLine("\nLinha ordenada com sucesso!");
            }
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Buscar(string[,] proj)
        {
            Console.WriteLine("Digite um nome para procurar:");
            string find = Console.ReadLine();
            bool flag = false;

            for (int l = 0; l < proj.GetLength(0); l++)
            {
                for (int c = 0; c < proj.GetLength(1); c++)
                {
                    if (String.Compare(find, proj[l, c], StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        Console.WriteLine($"O nome '{find}' foi encontrado na linha [{l + 1}] e coluna [{c + 1}]");
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("Nome não encontrado na tabela. Tente novamente.");
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void BuscaColuna(string[,] proj)
        {
            Console.WriteLine("Escolha a COLUNA para ser exibida ( 1, 2 ou 3)");
            int choiceC = int.Parse(Console.ReadLine());
            Console.Clear();
            if (choiceC < 1 || choiceC > proj.GetLength(1))
                Console.WriteLine("\nOpção invalida. Tente novamente.");
            else
            {
                for (int l = 0; l < 3; l++)
                {
                    Console.WriteLine(proj[l, choiceC - 1]);
                }
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void BuscaLinha(string[,] proj)
        {
            Console.WriteLine("Escolha a LINHA para ser exibida (1, 2 ou 3)");
            int choiceL = int.Parse(Console.ReadLine());
            Console.Clear();
            if (choiceL < 1 || choiceL > proj.GetLength(0))
                Console.WriteLine("\nOpção invalida. Tente novamente.");
            else
            {
                for (int c = 0; c < 3; c++)
                {
                    Console.WriteLine(proj[choiceL - 1, c]);
                }
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Imprimir(string[,] proj)
        {
            for (int l = 0; l < proj.GetLength(0); l++)
            {
                for (int c = 0; c < proj.GetLength(1); c++)
                {
                    Console.WriteLine($"[{l + 1}][{c + 1}] = {proj[l, c]}\t");
                }
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Inserir(string[,] proj)
        {
            if (proj[0, 0] != null)
            {
                Console.WriteLine("Tabela ja está preenchida. Escolha outra opção.");
            }
            else
            {

                for (int l = 0; l < proj.GetLength(0); l++)
                {
                    for (int c = 0; c < proj.GetLength(1); c++)
                    {
                        Console.Write("\nInforme um nome para registro:");
                        proj[l, c] = Console.ReadLine();
                    }
                }
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
