using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_2
{
    public class ToolsDataService
    {
        private List<Tools> toolsList = new List<Tools>();

        public List<Tools> GetTools()
        {
            return toolsList;
        }

        public void AddTool(Tools tool)
        {
            toolsList.Add(tool);
        }

        public void RemoveTool(Tools tool)
        {
            toolsList.Remove(tool);
        }
    }
}
