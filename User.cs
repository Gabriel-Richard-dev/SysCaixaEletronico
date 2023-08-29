using System;
using SysCaixaeletronico;

namespace SysCaixaeletronico
{
    public class User
    {
        public User()
        {
        
            Name = CreateUsername();
            Id = Guid.NewGuid();
            Senha = CreatePassword();
        
        }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Senha { get; set; }
        public decimal Saldo { get; set; }

        static string CreateUsername()
        {
            Console.Clear();
            Console.Write("Informe seu username: ");
            var username = Console.ReadLine();
            if (username is null)
            {
                Console.WriteLine("Por favor insira um valor válido");
                CreateUsername();
            }

            return username;

        }
        static string CreatePassword()
        {
            Console.Clear();
            Console.Write("Informe sua senha: ");
            var password = Console.ReadLine();
        
            if (password is null)
            {
                Console.WriteLine("Por favor insira um valor válido");
                CreatePassword();
            }
        
            Console.Write("Confirme sua senha: ");
            var passwordConfirm = Console.ReadLine();
        
            if (!password.Equals(passwordConfirm))
            {
                Console.WriteLine("As senhas não coincidem, por favor, tente novamente");
                CreatePassword();
            }
            Console.Clear();

            return password;

        }
        public void NewPassword()
        {
            Console.Clear();
            Console.Write("Informe sua nova senha: ");
            var password = Console.ReadLine();
        
            if (password is null)
            {
                Console.WriteLine("Por favor insira um valor válido");
                CreatePassword();
            }
        
            Console.Write("Confirme sua senha: ");
            var passwordConfirm = Console.ReadLine();
        
            if (!password.Equals(passwordConfirm))
            {
                Console.WriteLine("As senhas não coincidem, por favor, tente novamente");
                CreatePassword();
            }
            Console.Clear();
        
            Senha = password;
        
        }
    }
}


