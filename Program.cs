using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class FamousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }

    static void Main(string[] args)
    {
        IList<FamousPeople> stemPeople = new List<FamousPeople>()
        {
            new FamousPeople() { Name= "Michael Faraday", BirthYear=1791, DeathYear=1867 },
            new FamousPeople() { Name= "James Clerk Maxwell", BirthYear=1831, DeathYear=1879 },
            new FamousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867, DeathYear=1934 },
            new FamousPeople() { Name= "Katherine Johnson", BirthYear=1918, DeathYear=2020 },
            new FamousPeople() { Name= "Jane C. Wright", BirthYear=1919, DeathYear=2013 },
            new FamousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
            new FamousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
            new FamousPeople() { Name = "Lydia Villa-Komaroff", BirthYear=1947 },
            new FamousPeople() { Name = "Mae C. Jemison", BirthYear=1956 },
            new FamousPeople() { Name = "Stephen Hawking", BirthYear=1942, DeathYear=2018 },
            new FamousPeople() { Name = "Tim Berners-Lee", BirthYear=1955 },
            new FamousPeople() { Name = "Terence Tao", BirthYear=1975 },
            new FamousPeople() { Name = "Florence Nightingale", BirthYear=1820, DeathYear=1910 },
            new FamousPeople() { Name = "George Washington Carver", DeathYear=1943 },
            new FamousPeople() { Name = "Frances Allen", BirthYear=1932, DeathYear=2020 },
            new FamousPeople() { Name = "Bill Gates", BirthYear=1955 }
        };

        var bornAfter1900 = from person in stemPeople
                            where person.BirthYear.HasValue && person.BirthYear > 1900
                            select person;

        Console.WriteLine("People born after 1900:");
        foreach (var person in bornAfter1900)
        {
            Console.WriteLine($"{person.Name}, Born: {person.BirthYear}");
        }

        var twolsInName = from person in stemPeople
                          where person.Name.Count(c => c == 'l') == 2
                          select person;

        Console.WriteLine("\nPeople with two lowercase 'l's in their name:");
        foreach (var person in twolsInName)
        {
            Console.WriteLine(person.Name);
        }

        var countAfter1950 = (from person in stemPeople
                              where person.BirthYear.HasValue && person.BirthYear > 1950
                              select person).Count();

        Console.WriteLine($"\nNumber of people born after 1950: {countAfter1950}");

        var between1920and2000 = from person in stemPeople
                                 where person.BirthYear.HasValue && person.BirthYear >= 1920 && person.BirthYear <= 2000
                                 select person;
        int birthCount = between1920and2000.Count();

        Console.WriteLine("\nPeople born between 1920 and 2000:");
        foreach (var person in between1920and2000)
        {
            Console.WriteLine($"{person.Name}, Born: {person.BirthYear}");
        }
        Console.WriteLine($"Count: {birthCount}");

        var sortByBirthYear = from person in stemPeople
                                where person.BirthYear.HasValue
                                orderby person.BirthYear
                                select person;

        Console.WriteLine("\nSorted by Birth Year:");
        foreach (var person in sortByBirthYear)
        {
            Console.WriteLine($"{person.Name}, Born: {person.BirthYear}");
        }

        var diedBetween1960and2015 = from person in stemPeople
                                     where person.DeathYear.HasValue && person.DeathYear > 1960 && person.DeathYear < 2015
                                     orderby person.Name
                                     select person;

        Console.WriteLine("\nDied between 1960 and 2015, sorted by name:");
        foreach (var person in diedBetween1960and2015)
        {
            Console.WriteLine($"{person.Name}, Died: {person.DeathYear}");
        }
    }
}