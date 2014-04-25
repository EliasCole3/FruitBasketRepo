using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitBasketSimulator.Domain.Fruit;


namespace FruitBasketSimulator.Domain.Abstract
{
    public interface IFruitBaskets
    {
        void AddFruitBasket(FruitBasket fruitBasket);
        void RemoveFruitBasket(int fruitBasketId);
        FruitBasket GetFruitBasket(int fruitBasketId);
        List<FruitBasket> GetAllFruitBaskets();


        IQueryable<FruitBasket> FruitBaskets { get; set; }
        FruitBasket DeleteFruitBasket(int fruitBasketId);
        void SaveFruitBasket2(FruitBasket fruitBasket);

        bool FruitBasketExists(int ID);


    }
}
