using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar Animal");
            Console.WriteLine("2. Listar Animais");
            Console.WriteLine("3. Atualizar Animal");
            Console.WriteLine("4. Deletar Animal");
            Console.WriteLine("5. Sair");
            Console.Write("Opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarAnimal();
                    break;
                case "2":
                    ListarAnimais();
                    break;
                case "3":
                    AtualizarAnimal();
                    break;
                case "4":
                    DeletarAnimal();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarAnimal()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Espécie: ");
        string especie = Console.ReadLine();
        Console.Write("Raça: ");
        string raca = Console.ReadLine();
        Console.Write("Idade: ");
        int idade = int.Parse(Console.ReadLine());
        Console.Write("Peso: ");
        decimal peso = decimal.Parse(Console.ReadLine());
        Console.Write("Cor: ");
        string cor = Console.ReadLine();

        var animal = new Animal(nome, especie, raca, idade, peso, cor);
        animal.AddAnimal();
        Console.WriteLine("Animal adicionado com sucesso!");
    }

    static void ListarAnimais()
    {
        List<Animal> animais = Animal.GetAnimais();
        foreach (var a in animais)
        {
            Console.WriteLine($"ID: {a.ID_Animal}, Nome: {a.Nome}, Espécie: {a.Especie}, Raça: {a.Raca}, Idade: {a.Idade}, Peso: {a.Peso}, Cor: {a.Cor}");
        }
    }

    static void AtualizarAnimal()
    {
        Console.Write("ID do Animal a ser atualizado: ");
        int id = int.Parse(Console.ReadLine());

        var animal = Animal.GetAnimais().Find(a => a.ID_Animal == id);
        if (animal == null)
        {
            Console.WriteLine("Animal não encontrado.");
            return;
        }

        Console.Write("Novo Nome (deixe vazio para manter o atual): ");
        string nome = Console.ReadLine();
        if (!string.IsNullOrEmpty(nome)) animal.UpdateDetails(nome, animal.Especie, animal.Raca, animal.Idade, animal.Peso, animal.Cor);

        Console.Write("Nova Espécie (deixe vazio para manter o atual): ");
        string especie = Console.ReadLine();
        if (!string.IsNullOrEmpty(especie)) animal.UpdateDetails(animal.Nome, especie, animal.Raca, animal.Idade, animal.Peso, animal.Cor);

        Console.Write("Nova Raça (deixe vazio para manter o atual): ");
        string raca = Console.ReadLine();
        if (!string.IsNullOrEmpty(raca)) animal.UpdateDetails(animal.Nome, animal.Especie, raca, animal.Idade, animal.Peso, animal.Cor);

        Console.Write("Nova Idade (deixe vazio para manter o atual): ");
        string idadeStr = Console.ReadLine();
        int idade;
        if (!string.IsNullOrEmpty(idadeStr) && int.TryParse(idadeStr, out idade)) animal.UpdateDetails(animal.Nome, animal.Especie, animal.Raca, idade, animal.Peso, animal.Cor);

        Console.Write("Novo Peso (deixe vazio para manter o atual): ");
        string pesoStr = Console.ReadLine();
        decimal peso;
        if (!string.IsNullOrEmpty(pesoStr) && decimal.TryParse(pesoStr, out peso)) animal.UpdateDetails(animal.Nome, animal.Especie, animal.Raca, animal.Idade, peso, animal.Cor);

        Console.Write("Nova Cor (deixe vazio para manter o atual): ");
        string cor = Console.ReadLine();
        if (!string.IsNullOrEmpty(cor)) animal.UpdateDetails(animal.Nome, animal.Especie, animal.Raca, animal.Idade, animal.Peso, cor);

        animal.UpdateAnimal();
        Console.WriteLine("Animal atualizado com sucesso!");
    }

    static void DeletarAnimal()
    {
        Console.Write("ID do Animal a ser deletado: ");
        int id = int.Parse(Console.ReadLine());

        Animal.DeleteAnimal(id);
        Console.WriteLine("Animal deletado com sucesso!");
    }
}