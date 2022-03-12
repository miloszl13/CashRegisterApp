using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class UpdateProductCommand:ProductCommand
    {
        public UpdateProductCommand(int id, string name, int cost)
        {
            Product_id = id;
            Name = name;
            Cost = cost;
        }
    }
}
