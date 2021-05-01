using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public static class Settings
    {
        public static Mode Read()
        {

            switch (Properties.Settings.Default.Mode)
            {
                case 0:
                    return Mode.Author;

                case 1:
                    return Mode.Book;

                case 2:
                    return Mode.Reader;

                default:
                    return Mode.Book;
            }
        }

        public static void Save(Mode mode)
        {
            Properties.Settings.Default.Mode = (byte)mode;
            Properties.Settings.Default.Save();
        }
    }

    public enum Mode : byte
    {
        Author = 0,
        Book = 1,
        Reader = 2
    }
}
