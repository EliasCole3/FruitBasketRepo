using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitBasketSimulator.Domain.Abstract;
using FruitBasketSimulator.Domain.Fruit;

namespace FruitBasketSimulator.Domain.Concrete
{
    public class MockFruitBasketRepo : IFruitBaskets
    {

        //Class members
        List<FruitBasket> fruitBasketList = new List<FruitBasket>();

        //Constructors
        public MockFruitBasketRepo() { }

        public MockFruitBasketRepo(List<FruitBasket> ListOfFruitBasket)
        {
            FruitBasketList = ListOfFruitBasket;
        }


        //Properties
        public List<FruitBasket> FruitBasketList
        {
            get
            {
                return fruitBasketList;
            }
            set
            {
                fruitBasketList = value;
            }
        }


        //Implemmented interface methods
        public void AddFruitBasket(FruitBasket fruitBasket)
        {
            fruitBasketList.Add(fruitBasket);
        }

        public void RemoveFruitBasket(int fruitBasketId)
        {
            FruitBasketList.Remove(FruitBasketList.Find(x => x.FruitBasketId == fruitBasketId));
        }

        public FruitBasket GetFruitBasket(int fruitBasketId)
        {
            return (fruitBasketList.Find(x => x.FruitBasketId == fruitBasketId));
        }

        public List<FruitBasket> GetAllFruitBaskets()
        {
            return (FruitBasketList);
        }


        public IQueryable<FruitBasket> FruitBaskets
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public FruitBasket DeleteFruitBasket(int fruitBasketId)
        {
            throw new NotImplementedException();
        }


        //public void SaveFruitBasket(Entities.FruitBasketViewModelNope fruitBasketVM)
        //{
        //    throw new NotImplementedException();
        //}


        public void SaveFruitBasket2(FruitBasket fruitBasket)
        {
            throw new NotImplementedException();
        }


        public bool FruitBasketExists(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
