using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBasketSimulator.Domain.Fruit
{
    public class Grapes
    {
        string fileURL = "/Images/Fruit/grapes.png";

        [Key]
        public int GrapesId { get; set; }
        public string Color { get; set; }

        public string FileURL
        {
            get { return fileURL; }
            set { fileURL = value; }
        }
    }
}
