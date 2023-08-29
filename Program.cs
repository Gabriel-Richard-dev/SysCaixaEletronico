using System;
using System.Text;

namespace SysCaixaeletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Clear();
            List<User> usuarios = new List<User>();
            Menu(usuarios);
        }

        static void Menu(List<User> usuarios)
        {
            BoasVindas();

            string? opt = Console.ReadLine();
            short? option;
            try
            {
                option = short.Parse(opt);
            }
            catch
            {
                option = null;
            }
            
            switch (option)
            {
                case 1:
                {
                    PaginaDeLogin(usuarios);
                    
                    break;
                }
                case 2:
                {
                    usuarios.Add(CadastrarUsuario(usuarios));
                    Menu(usuarios);
                    break;
                } 
                case 3:
                {
                    EsqueciASenha(usuarios);
                    Menu(usuarios);
                    break;
                }
                case 0: 
                    System.Environment.Exit(0); break;
                default:
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, insira uma escolha correta");
                    Menu(usuarios);
                    break;
                }
            }
            
        }

        static void EsqueciASenha(List<User> usrs)
        {
            if (usrs.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há usuários cadastrados, por favor, cadastre-se");
                Menu(usrs);
            }
            Console.Clear();
            Console.Write("Informe o seu username:");
            var username = Console.ReadLine();
            foreach (var user in usrs)
            {
                if (user.Name.Equals(username) == true)
                {
                    user.NewPassword();
                }
            }
        }
        static void PaginaDeLogin(List<User> usrs)
        {
            if (usrs.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há usuários cadastrados, por favor, cadastre-se");
                Menu(usrs);
            }
            Console.Clear();
            Console.Write("Por favor insira seu username: ");
            var username = Console.ReadLine();
            Console.Write("Por favor insira sua senha: ");
            var password = Console.ReadLine();

            foreach (var us in usrs)
            {
                if (us.Name.Equals(username) == true & us.Senha.Equals(password) == true)
                {
                    Console.Clear();
                    Console.WriteLine($"Logado, bem vindo {us.Name}");
                    var sys = new SistemaDoCaixa(us);
                    Operacoes(sys, us);
                    Menu(usrs);
                }    
            }
            Console.Clear();
            Console.WriteLine("Tente novamente! Usuário ou senha incorretos");
            Menu(usrs);
        }

        static void Operacoes(SistemaDoCaixa sc, User us)
        {
            while (true)
            {
                sc.BemVindo();
                short? opt;
                string? baseOpt = Console.ReadLine();
                try
                {
                    opt = short.Parse(baseOpt);
                }
                catch
                {
                    opt = null;
                }

                switch (opt)
                {
                    case 1:
                    {
                        sc.Sacar();
                        break;
                    }
                    case 2:
                    {
                        sc.Depositar();
                        break;
                    }
                    case 3:
                    {
                        sc.VerSaldo();
                        break;
                    }
                    case 0:
                    {
                        Console.Clear();
                        us.Saldo = sc.Saldo;
                        return;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Por favor insira um valor válido!");
                        Console.Clear();
                        break;
                    }
                }
            }
        }
        static User CadastrarUsuario(List<User> users)
        {
            User usr = new User();
            foreach (var user in users)
            {
                if (user.Name.Equals(usr.Name) == true)
                {
                    Console.WriteLine("Username já existente");
                    Menu(users);
                }
            }
            return usr;
        }
        
        static void BoasVindas()
        {
            Console.WriteLine("Bem vindo ao Sistema do Caixa Eletronico!");
            Console.WriteLine("-----------------------------------------\n");
            
            Console.WriteLine("---------------------------");
            Console.WriteLine("|                         |");
            Console.WriteLine("|         1 - Login       |");
            Console.WriteLine("|  2 - Cadastrar Usuário  |");
            Console.WriteLine("|   3 - Esqueci a Senha   |");
            Console.WriteLine("|                         |");
            Console.WriteLine("---------------------------");
            
            Console.WriteLine("--------- 0 - Sair --------\n");

        }
        
        
    }
}