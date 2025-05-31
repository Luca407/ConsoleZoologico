    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAtividadePOO
{
    public abstract class Animal
    {
        public string Nome { get; set; }

        private int idade;
        public int Idade
        {
            get => idade;
            set
            {
                if (value < 0)
                    throw new ArgumentException("A idade não pode ser negativa.");
                idade = value;
            }
        }

        public abstract void EmitirSom();

        public virtual void Apresentar()
        {
            Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
        }
    }

    // Cachorro
    public class Cachorro : Animal
    {
        public override void EmitirSom()
        {
            Console.WriteLine("Au Au!");
        }
    }

    // Gato
    public class Gato : Animal
    {
        public override void EmitirSom()
        {
            Console.WriteLine("Miau!");
        }
    }

    // Pássaro
    public class Passaro : Animal
    {
        public override void EmitirSom()
        {
            Console.WriteLine("Piu Piu!");
        }

        public void Voar()
        {
            Console.WriteLine($"{Nome} está voando!");
        }
    }

    // Zoo (Composição)
    public class Zoo
    {
        private List<Animal> animais = new List<Animal>();

        public void AdicionarAnimal(Animal animal)
        {
            animais.Add(animal);
        }

        public void MostrarAnimais()
        {
            foreach (var animal in animais)
            {
                animal.Apresentar();
                animal.EmitirSom();
            }
        }

        public Animal BuscarPorNome(string nome)
        {
            return animais.Find(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
    }

    // Veterinário
    public class Veterinario
    {
        private string especialidade;
        public string Especialidade
        {
            get => especialidade;
            set
            {
                if (value != "Caninos" && value != "Felinos" && value != "Aves")
                    throw new ArgumentException("Especialidade inválida.");
                especialidade = value;
            }
        }

        public void Examinar(Animal animal)
        {
            Console.WriteLine("Veterinário está examinando o animal...");
            animal.EmitirSom();
        }
    }
}
