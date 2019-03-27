using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
            var bird = new Bird();
            

        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
    }

    public abstract class Species: ISpecies
    {
        public abstract void GetSpecies();        

        public void Eat()   
        {
            throw new NotImplementedException();
        }

        public void Drink()
        {
            throw new NotImplementedException();
        }

        
    }

    public class Human : Species
    {
        public override void GetSpecies()
        {
            Console.WriteLine($"human");
        }
        
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    public class Bird : Species
    {

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public override void GetSpecies()
        {
            throw new NotImplementedException();
        }
    }

    public class Fish : Species
    {
        public override void GetSpecies()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
}

