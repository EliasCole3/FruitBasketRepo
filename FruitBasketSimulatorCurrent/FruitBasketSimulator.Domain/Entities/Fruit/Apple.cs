using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBasketSimulator.Domain.Fruit
{
    public class Apple
    {
        string fileURL = "/Images/Fruit/Apple.png";

        [Key]
        public int AppleId { get; set; }
        public string Color{get;set;}
        public string Type{get;set;}
        public string FileURL 
        {
            get { return fileURL; }
            set { fileURL = value; }
        }
    }
}
