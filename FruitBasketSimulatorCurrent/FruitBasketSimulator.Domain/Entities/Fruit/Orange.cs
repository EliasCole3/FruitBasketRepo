using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBasketSimulator.Domain.Fruit
{
    public class Orange
    {
        string fileURL = "/Images/Fruit/orange.png";

        [Key]
        public int OrangeId { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }

        public string FileURL
        {
            get { return fileURL; }
            set { fileURL = value; }
        }
    }
}
