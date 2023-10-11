using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.Entities
{
    public interface ITrie
    {
        bool Search(string word);
        void Insert(string word);
        void Delete(string word);
    }
}
