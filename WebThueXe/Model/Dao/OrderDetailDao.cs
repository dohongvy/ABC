using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        WebThueXeDBContext db = null;
        public OrderDetailDao()
        {
            db = new WebThueXeDBContext();
        }
        public List<Car> PriceTotal(int priceTotal, int includedVAT)

        {
            return db.Cars.Where(x => x.PriceTotal == priceTotal).Skip(priceTotal + includedVAT + priceTotal * 3 / 100).ToList();
        }
        public OrderDetail ViewDetail(int id)
        {
            return db.OrderDetails.Find(id);
        }
        public long Insert(OrderDetail entity)
        {
            entity.PickUp = DateTime.Now;
            entity.DropOff = DateTime.Now;
            db.OrderDetails.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public int CheckList(int id, DateTime ngaydropoff, DateTime ngaypickup)
        {
            var model = db.OrderDetails.Find(id);
            int compare1 = DateTime.Compare(ngaypickup, model.DropOff);
             int compare2 = DateTime.Compare(ngaydropoff, model.PickUp);

             if (compare1 > 0 || compare2 < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
