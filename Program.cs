using System;
using System.Collections.Generic;

while (true)
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1. Adicionar Animal");
    Console.WriteLine("2. Listar Animais");
    Console.WriteLine("3. Buscar Animal");
    Console.WriteLine("4. Atualizar Animal");
    Console.WriteLine("5. Deletar Animal");
    Console.WriteLine("6. Sair");
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
            BuscarAnimais();
            break;
        case "4":
            AtualizarAnimal();
            break;
        case "5":
            DeletarAnimal();
            break;
        case "6":
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
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
    Console.Write("Sexo: ");
    char sexo = char.Parse(Console.ReadLine());
    Console.Write("Cor: ");
    string cor = Console.ReadLine();

    var animal = new Animal(nome, especie, raca, idade, peso, sexo, cor);
    animal.AddAnimal();
    Console.WriteLine("Animal adicionado com sucesso!");
}

static void ListarAnimais()
{
    List<Animal> animais = Animal.GetAnimais();

    if (animais.Count == 0)
    {
        Console.WriteLine("Nenhum animal encontrado.");
        return;
    }

    foreach (var a in animais)
    {
        Console.WriteLine($"ID: {a.ID_Animal}, Nome: {a.Nome}, Espécie: {a.Especie}, Raça: {a.Raca}, Idade: {a.Idade}, Peso: {a.Peso}, Sexo: {a.Sexo}, Cor: {a.Cor}");
    }
}

static void BuscarAnimais()
{
    Console.Write("ID do Animal a ser buscado: ");
    int id = int.Parse(Console.ReadLine());

    var encontraranimal = Animal.GetAnimais().Find(a => a.ID_Animal == id);
    if (encontraranimal == null)
    {
        Console.WriteLine("Animal não encontrado.");
        return;
    }

    List<Animal> animais = Animal.SearchAnimal(id);
    foreach (var a in animais)
    {
        Console.WriteLine($"ID: {a.ID_Animal}, Nome: {a.Nome}, Espécie: {a.Especie}, Raça: {a.Raca}, Idade: {a.Idade}, Peso: {a.Peso}, Sexo: {a.Sexo}, Cor: {a.Cor}");
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

    Console.WriteLine("Escolha o que deseja atualizar:");
    Console.WriteLine("1. Nome");
    Console.WriteLine("2. Espécie");
    Console.WriteLine("3. Raça");
    Console.WriteLine("4. Idade");
    Console.WriteLine("5. Peso");
    Console.WriteLine("6. Sexo");
    Console.WriteLine("7. Cor");
    Console.Write("Opção: ");
    var opcao = int.Parse(Console.ReadLine());

    if (opcao == 1)
    {
        Console.Write("Novo Nome: ");
        string nome = Console.ReadLine();
        animal.UpdateDetails(nome, animal.Especie, animal.Raca, animal.Idade, animal.Peso, animal.Sexo, animal.Cor);
    }

    if (opcao == 2)
    {
        Console.Write("Nova Espécie: ");
        string especie = Console.ReadLine();
        animal.UpdateDetails(animal.Nome, especie, animal.Raca, animal.Idade, animal.Peso, animal.Sexo, animal.Cor);
    }

    if (opcao == 3)
    {
        Console.Write("Nova Raça: ");
        string raca = Console.ReadLine();
        animal.UpdateDetails(animal.Nome, animal.Especie, raca, animal.Idade, animal.Peso, animal.Sexo, animal.Cor);
    }

    if (opcao == 4)
    {
        Console.Write("Nova Idade: ");
        string idadeStr = Console.ReadLine();
        int idade;
        int.TryParse(idadeStr, out idade);
        animal.UpdateDetails(animal.Nome, animal.Especie, animal.Raca, idade, animal.Peso, animal.Sexo, animal.Cor);
    }

    if (opcao == 5)
    {
        Console.Write("Novo Peso: ");
        string pesoStr = Console.ReadLine();
        decimal peso;
        decimal.TryParse(pesoStr, out peso);
        animal.UpdateDetails(animal.Nome, animal.Especie, animal.Raca, animal.Idade, peso, animal.Sexo, animal.Cor);
    }

    if (opcao == 6)
    {
        Console.Write("Novo Sexo: ");
        string sexoStr = Console.ReadLine();
        char sexo;
        char.TryParse(sexoStr, out sexo);
        animal.UpdateDetails(animal.Nome, animal.Especie, animal.Raca, animal.Idade, animal.Peso, sexo, animal.Cor);
    }

    if (opcao == 7)
    {
        Console.Write("Nova Cor: ");
        string cor = Console.ReadLine();
        animal.UpdateDetails(animal.Nome, animal.Especie, animal.Raca, animal.Idade, animal.Peso, animal.Sexo, cor);
    }

    animal.UpdateAnimal();
    Console.WriteLine("Animal atualizado com sucesso!");

    Console.WriteLine("Deseja atualizar outro Animal?");
    Console.WriteLine("1. Sim");
    Console.WriteLine("2. Não");
    Console.Write("Opção: ");
    var recomecar = int.Parse(Console.ReadLine());

    if (recomecar == 1)
    {
        AtualizarAnimal();
    }
}

static void DeletarAnimal()
{
    Console.Write("ID do Animal a ser deletado: ");
    int id = int.Parse(Console.ReadLine());

    var encontraranimal = Animal.GetAnimais().Find(a => a.ID_Animal == id);
    if (encontraranimal == null)
    {
        Console.WriteLine("Animal não encontrado.");
        return;
    }

    Animal.DeleteAnimal(id);
    Console.WriteLine("Animal deletado com sucesso!");
}