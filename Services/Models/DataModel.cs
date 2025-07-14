using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class DataModel
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public DateTime TimeStamp {get;set;}

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, TimeStamp: {TimeStamp}";
        }
    }
}
