using ConsoleAtividadePOO;
using System;


class Program
{
    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- MENU ZOOLÓGICO ---");
            Console.WriteLine("1. Adicionar Cachorro");
            Console.WriteLine("2. Adicionar Gato");
            Console.WriteLine("3. Adicionar Pássaro");
            Console.WriteLine("4. Mostrar Animais");
            Console.WriteLine("5. Examinar com Veterinário");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    zoo.AdicionarAnimal(CriarAnimal(new Cachorro()));
                    break;
                case "2":
                    zoo.AdicionarAnimal(CriarAnimal(new Gato()));
                    break;
                case "3":
                    zoo.AdicionarAnimal(CriarAnimal(new Passaro()));
                    break;
                case "4":
                    zoo.MostrarAnimais();
                    break;
                case "5":
                    Veterinario vet = new Veterinario();
                    Console.Write("Digite a especialidade do veterinário (Caninos, Felinos, Aves): ");
                    try
                    {
                        vet.Especialidade = Console.ReadLine();
                        Console.Write("Digite o nome do animal a ser examinado: ");
                        string nome = Console.ReadLine();
                        Animal animal = zoo.BuscarPorNome(nome);
                        if (animal != null)
                            vet.Examinar(animal);
                        else
                            Console.WriteLine("Animal não encontrado.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static Animal CriarAnimal(Animal animal)
    {
        Console.Write("Digite o nome: ");
        animal.Nome = Console.ReadLine();

        bool idadeValida = false;
        while (!idadeValida)
        {
            Console.Write("Digite a idade: ");
            try
            {
                animal.Idade = int.Parse(Console.ReadLine());
                idadeValida = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        return animal;
    }
}
