using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBasketSimulator.Domain.Fruit
{
    public class Kiwi
    {
        string fileURL = "/Images/Fruit/Kiwi.png";

        [Key]
        public int KiwiId { get; set; }
        public string Type { get; set; }

        public string FileURL
        {
            get { return fileURL; }
            set { fileURL = value; }
        }

    }
}
