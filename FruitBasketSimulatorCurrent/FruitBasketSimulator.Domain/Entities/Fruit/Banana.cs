using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBasketSimulator.Domain.Fruit
{
    public class Banana
    {
        string fileURL = "/Images/Fruit/Banana.png";

        [Key]
        public int BananaId { get; set; }
        public string Color { get; set; }
        public int NumberOfSpots { get; set; }

        public string FileURL
        {
            get { return fileURL; }
            set { fileURL = value; }
        }
    }
}
