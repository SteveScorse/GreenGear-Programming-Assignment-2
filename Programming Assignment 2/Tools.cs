using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_2
{
    internal class Tools
    {
        public int ID { get; set; }
        public string ToolName { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }

        public Tools(int iD, string toolName, float price, bool isAvailable)
        {
            ID = iD;
            ToolName = toolName;
            Price = price;
            IsAvailable = isAvailable;
            
        }

    }
}
