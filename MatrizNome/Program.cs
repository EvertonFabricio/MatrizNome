using System;

namespace MatrizNome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] proj = new string[3, 3];
            do
            {
                Console.WriteLine(">>>Tabela de Nomes<<<\nEscolha a opção desejada:");
                Console.WriteLine("1 - Ler os nomes e inserir na tabela\n2 - Imprimir a tabela completa\n3 - Escolher uma linha da tabela para imprimir");
                Console.WriteLine("4 - Escolher uma coluna da tabela para imprimir\n5 - Procurar um nome para saber sua posição na Tabela\n6 - Escolher uma linha para ordenar os nomes");
                Console.WriteLine("0 - Sair");
                string menu = Console.ReadLine();
                Console.Clear();


                switch (menu)
                {
                    case "1":
                        for (int l = 0; l < proj.GetLength(0); l++)
                        {
                            for (int c = 0; c < proj.GetLength(0); c++)
                            {
                                Console.Write("\nInforme um nome para registro:");
                                proj[l, c] = Console.ReadLine();
                            }
                        }
                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        for (int l = 0; l < proj.GetLength(0); l++)
                        {
                            for (int c = 0; c < proj.GetLength(0); c++)
                            {
                                Console.WriteLine($"[{l+1}][{c+1}] = {proj[l, c]}\t");
                            }
                        }
                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":
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
                        break;

                    case "4":
                        Console.WriteLine("Escolha a COLUNA para ser exibida ( 1, 2 ou 3)");
                        int choiceC = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (choiceC < 1 || choiceC > proj.GetLength(0))
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
                        break;

                    case "5":
                        Console.WriteLine("Digite um nome para procurar:");
                        string find = Console.ReadLine();
                        bool flag = false;

                        for (int l = 0; l < proj.GetLength(0); l++)
                        {
                            for (int c = 0; c < proj.GetLength(0); c++)
                            {
                                if (String.Compare(find, proj[l, c], StringComparison.OrdinalIgnoreCase) == 0)
                                {
                                    Console.WriteLine($"O nome '{find}' foi encontrado na linha [{l+1}] e coluna [{c+1}]");
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
                        break;

                    case "6":
                        Console.Write("Digite o numero da linha que gostaria de ordenar: ");
                        int choice = int.Parse(Console.ReadLine()); 
                        if (choice < 1 || choice > proj.GetLength(0)) 
                        {
                            Console.WriteLine("\nOpção invalida. Tente novamente.");
                        }
                        else 
                        {
                            choice--; 

                            for (int c1 = 0; c1 < proj.GetLength(0); c1++) 
                            {
                                for (int c2 = c1 + 1; c2 < proj.GetLength(0); c2++) 
                                {
                                    if (String.Compare(proj[choice, c1], proj[choice, c2], StringComparison.Ordinal) > 0) 
                                    {   
                                        string aux = proj[choice, c1];
                                        proj[choice, c1] = proj[choice, c2];
                                        proj[choice, c2] = aux;
                                    }
                                }
                            }
                        Console.WriteLine("\nLinha ordenada com sucesso!");
                        }
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        Console.Clear();
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
    }
}
