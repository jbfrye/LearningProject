using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_3
{
    // 3.7
    class PetQueue
    {
        LinkedList<Animal> petList;
        public PetQueue()
        {
            petList = new LinkedList<Animal>();
        }

        public void Enqueue(Animal a)
        {
            petList.AddLast(a);
        }

        public Animal DequeueAny()
        {
            Animal animal = petList.First.Value;
            petList.RemoveFirst();
            return animal;
        }

        public Animal DequeueDog()
        {
            LinkedListNode<Animal> node = petList.First;
            while (node.Next != null)
            {
                if (node.Value is Dog)
                {
                    Animal animal = node.Value;
                    petList.Remove(node);
                    return animal;
                }
                node = node.Next;
            }
            return null;
        }

        public Animal DequeueCat()
        {
            LinkedListNode<Animal> node = petList.First;
            while (node.Next != null)
            {
                if (node.Value is Cat)
                {
                    Animal animal = node.Value;
                    petList.Remove(node);
                    return animal;
                }
                node = node.Next;
            }
            return null;
        }

        public int Count()
        {
            return petList.Count;
        }

        public static void RunPetQueue()
        {
            PetQueue petQueue = new PetQueue();
            petQueue.Enqueue(new Dog("Fido"));
            petQueue.Enqueue(new Dog("Charles"));
            petQueue.Enqueue(new Cat("Pepper"));
            petQueue.Enqueue(new Cat("Pusheen"));
            petQueue.Enqueue(new Dog("Bandit"));

            Console.WriteLine(petQueue.DequeueAny().GetName());
            Console.WriteLine(petQueue.DequeueCat().GetName());
            Console.WriteLine(petQueue.DequeueCat().GetName());
            Console.WriteLine(petQueue.DequeueDog().GetName());
        }
    }

    public class Animal
    {
        string name = "";

        public Animal(string n)
        {
            name = n;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string n)
        {
            name = n;
        }
    }

    class Cat : Animal
    {
        public Cat(string n) : base(n)
        { }
    }

    class Dog : Animal
    {
        public Dog(string n) : base(n)
        { }
    }
}
