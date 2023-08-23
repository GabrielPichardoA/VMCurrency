using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatabaseModels
{
    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Limit { get; set; }
    }
}
