using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMauiApp
{
    internal class Robot
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public Robot(string name, string type, int size)
        {
            Name = name;
            Type = type;
            Size = size;
        }
    }
}
