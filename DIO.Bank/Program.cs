using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();


        static void Main(string[] args)
        {
            string opcaoMenu = ObterOpcaoMenu();

            while (opcaoMenu.ToUpper() != "X")
            {
                switch (opcaoMenu)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, digite novamente uma opção!");
                        break;
                }

                opcaoMenu = ObterOpcaoMenu();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static string ObterOpcaoMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Sistema DIO Bank");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoMenu = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return opcaoMenu;
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de saque: ");
            int indiceContaSaq = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de depósito: ");
            int indiceContaDep = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque: ");
            double valorTransf = double.Parse(Console.ReadLine());

            listaContas[indiceContaSaq].Transferir(valorTransf, listaContas[indiceContaDep]);
        }


        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir nova conta!");
            Console.Write("Digite o Tipo de Conta (1 - Pessoa Física; 2 - Pessoa Jurídica): ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito: ");
            double entradaCrédito = double.Parse(Console.ReadLine());


            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCrédito, nome: entradaNome);

            listaContas.Add(novaConta);

        }




    }
}
