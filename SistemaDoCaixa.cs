using System;

namespace SysCaixaeletronico;

public class SistemaDoCaixa
{
    public SistemaDoCaixa(User usuario)
    {
        Usuario = usuario;
        Saldo = Usuario.Saldo;
    }
    
    public User Usuario { get; set; }
    public decimal Saldo { get; set; }

    public void Sacar()
    {
        Console.Clear();

        Console.Write("Quanto deseja sacar: ");
        
        decimal sac;
        string? baseSac = Console.ReadLine();
        
        try
        {
            sac = decimal.Parse(baseSac);
        }
        catch
        {
            Console.WriteLine("Informação inválida! Não foi possível sacar!");
            return;
        }
        
        if (sac <= Saldo)
        {
            if (sac >= 0)
            {
                Saldo -= sac;
                Console.WriteLine($"Valor sacado! Saldo atual: {Saldo}");
   
            }
            else
            {
                Console.WriteLine("Você não pode sacar valores negativos ou nulos");
            }
            
        }
        else
        {
            Console.WriteLine("Você não tem saldo!");
        }
    }

    public void Depositar()
    {
        Console.Clear();
        Console.Write("Quanto deseja depositar: ");
        string? baseString = Console.ReadLine();
        decimal dep;
        
        try { dep = decimal.Parse(baseString); }
        catch 
        { 
            Console.WriteLine("Não foi depositado nenhum valor!");
            dep = 0;
        }

        if (dep >= 0)
        {
            Saldo += dep;
            Console.WriteLine($"Valor depositado! Saldo atual: {Saldo}");
        }
        else
        {
            Console.WriteLine("Você não pode depositar valores negativos ou nulos!");
        }
    }

    public void VerSaldo()
    {
        Console.Clear();
        Console.WriteLine();
        Console.Write($"Seu saldo é: {Saldo:C}");
        Console.WriteLine();

    }

    public void BemVindo()
    {
        
        Console.WriteLine();
        Console.WriteLine($"Nome: {Usuario.Name} | Id: {Usuario.Id}");
        Console.WriteLine();
        
        Console.WriteLine("-------------------------------");
        Console.WriteLine("         - 1 - Sacar           ");
        Console.WriteLine("         2 - Depositar         ");
        Console.WriteLine("           3 - Saldo           ");
        Console.WriteLine("           0 - Voltar          ");
        Console.WriteLine("-------------------------------\n");

        
    }
}