using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>(); 

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcao();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        InserirConta();
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
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcao();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            }
        private static void Sacar()
        {
            Console.Write("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Depositado:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }
        
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int valorSaque = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaOrigem]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta juridica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)entradaTipoConta,
                                        entradaSaldo,
                                        entradaCredito,
                                        entradaNome);
            listContas.Add(novaConta);

        }

        private static void ListarConta()
        {
            Console.WriteLine("Listar contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }


        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo !!!");
            Console.WriteLine("Informe a opção desejada.");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }

        
}
