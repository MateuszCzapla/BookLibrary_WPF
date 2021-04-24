using System;

namespace BookLibrary.Models
{
    public class Readers
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private readonly int pesel;
        public int PESEL
        {
            get
            {
                return pesel;
            }
        }
        public bool Debt { get; set; }

        public Readers(string name, string surname, int pesel)
        {
            this.Name = name;
            this.Surname = surname;
            this.pesel = pesel;
        }
    }
}
