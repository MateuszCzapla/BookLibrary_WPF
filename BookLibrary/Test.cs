using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.Sqlite;

namespace BookLibrary
{
    class Test
    {
        /// <summary>
        /// Creates a database file.  This just creates a zero-byte file which SQLite
        /// will turn into a database when the file is opened properly.
        /// </summary>
        /// <param name="databaseFileName">The file to create</param>
        static public void CreateFile(string databaseFileName)
        {
            //File.WriteAllBytes(databaseFileName, new byte[0]);
        }

        public Test()
        {

        }
    }
}
