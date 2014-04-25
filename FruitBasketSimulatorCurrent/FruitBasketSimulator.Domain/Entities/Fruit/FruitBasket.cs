using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBasketSimulator.Domain.Fruit
{
    public class FruitBasket
    {
        List<Apple> appleList = new List<Apple>();
        List<Banana> bananaList = new List<Banana>();
        List<Orange> orangeList = new List<Orange>();
        List<Grapes> grapesList = new List<Grapes>();
        List<Kiwi> kiwiList = new List<Kiwi>();
        List<Melon> melonList = new List<Melon>();

        [Key]
        public int FruitBasketId { get; set; }
        public virtual List<Apple> AppleList
        {
            get { return appleList; }
            set { appleList = value; }
        }
        public virtual List<Banana> BananaList
        {
            get { return bananaList; }
            set { bananaList = value; }
        }
        public virtual List<Orange> OrangeList
        {
            get { return orangeList; }
            set { orangeList = value; }
        }
        public virtual List<Grapes> GrapesList
        {
            get { return grapesList; }
            set { grapesList = value; }
        }
        public virtual List<Kiwi> KiwiList
        {
            get { return kiwiList; }
            set { kiwiList = value; }
        }
        public virtual List<Melon> MelonList
        {
            get { return melonList; }
            set { melonList = value; }
        }
        public int size { get; set; }
    }
}
