using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitBasketSimulator.Domain.Abstract;
using FruitBasketSimulator.Domain.Fruit;
using FruitBasketSimulator.Domain.Users;

namespace FruitBasketSimulator.Domain.Concrete
{
    public class FruitBasketRepo : IFruitBaskets
    {

        DBContext db = new DBContext();

        public void AddFruitBasket(FruitBasket fruitBasket)
        {
            //var db = new DBContext();
            db.FruitBasketList.Add(fruitBasket);
            db.SaveChanges();
        }

        public void RemoveFruitBasket(int fruitBasketId)
        {
            //var db = new DBContext();
            db.FruitBasketList.Remove((from b in db.FruitBasketList
                                       where b.FruitBasketId== fruitBasketId
                                       select b).FirstOrDefault());
            db.SaveChanges();
        }

        public FruitBasket GetFruitBasket(int fruitBasketId)
        {
            //var db = new DBContext();

            if (fruitBasketId == 0 )
            {
                FruitBasket temp2 = new FruitBasket();
                return temp2;
            }

            FruitBasket temp = new FruitBasket();
            temp = (from b in db.FruitBasketList
                    where b.FruitBasketId == fruitBasketId
                    select b).FirstOrDefault();
            return temp;
        }

        public List<FruitBasket> GetAllFruitBaskets()
        {
            //var db = new DBContext();
            List<FruitBasket> temp = (db.FruitBasketList).ToList();
            return temp;
        }


        public IQueryable<FruitBasket> FruitBaskets
        {

            get
            {
                //var db = new DBContext();
                return db.FruitBasketList;
            }
            set {/*not implemented*/}
        }

        public bool FruitBasketExists(int ID)
        {
            List<FruitBasket> temp = (db.FruitBasketList).ToList();
            foreach (FruitBasket f in temp)
            {
                if (f.FruitBasketId == ID)
                {
                    return true;
                }
            }
            return false;
        }






        //zomg layers 
        //public void SaveFruitBasket(FruitBasketViewModelNope fruitBasketVM)
        //{
        //    if (fruitBasketVM.FruitBasket.FruitBasketId == 0)
        //    {
        //        //add a new fruit basket to the user
        //        RegisteredUser RUser = db.RegisteredUserList.Find(fruitBasketVM.RegisteredUser.Password);
        //        RUser.FruitBasketList.Add(fruitBasketVM.FruitBasket);
        //    }
        //    else
        //    {
        //        //update the existing fruitbasket
        //        RegisteredUser RUser = db.RegisteredUserList.Find(fruitBasketVM.RegisteredUser.Password);
        //        var RUserSelectedFruitBasket = ((from b in RUser.FruitBasketList
        //            where b.FruitBasketId == fruitBasketVM.FruitBasket.FruitBasketId
        //            select b).FirstOrDefault());

        //        if (RUserSelectedFruitBasket != null)
        //        {
        //            //var temp2 = RUser.FruitBasketList.Find(x => x.FruitBasketId == temp.FruitBasketId);
        //            RUserSelectedFruitBasket.AppleList = fruitBasketVM.FruitBasket.AppleList;
        //            RUserSelectedFruitBasket.BananaList = fruitBasketVM.FruitBasket.BananaList;
        //            RUserSelectedFruitBasket.GrapesList = fruitBasketVM.FruitBasket.GrapesList;
        //            RUserSelectedFruitBasket.KiwiList = fruitBasketVM.FruitBasket.KiwiList;
        //            RUserSelectedFruitBasket.MelonList = fruitBasketVM.FruitBasket.MelonList;
        //            RUserSelectedFruitBasket.OrangeList = fruitBasketVM.FruitBasket.OrangeList;
                    
        //        }
        //    }
        //    db.SaveChanges();
        //}

        public void SaveFruitBasket2(FruitBasket fruitBasket)
        {
            if (fruitBasket.FruitBasketId == 0)
            {
                db.FruitBasketList.Add(fruitBasket);
            }
            else
            {
                FruitBasket dbEntry = db.FruitBasketList.Find(fruitBasket.FruitBasketId);
                if (dbEntry != null)
                {
                    dbEntry.AppleList = fruitBasket.AppleList;
                }
            }
            db.SaveChanges();
        }

        public FruitBasket DeleteFruitBasket(int fruitBasketId)
        {
            throw new NotImplementedException();
        }



    }
}
