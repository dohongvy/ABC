using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class CarDao
    {
        WebThueXeDBContext db = null;
        public CarDao()
        {
            db = new WebThueXeDBContext();
        }
        public List<Car> ListNewCar(int top)
        {   
            return db.Cars.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Car> ListFeartureCar(int top)
        {
            return db.Cars.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Car> ListCar(int top)
        {
            return db.Cars.Where(x => x.Status == true).ToList();
        }
        public List<Car> ListPriceCar(int top)
        {
            return db.Cars.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Car> ListByCategoryId(long categoryID, int pageIndex=1,int pageSize = 2)

        {
            return db.Cars.Where(x => x.CategoryID == categoryID).Skip((pageSize - 1) * pageIndex).Take(pageSize).ToList(); 
        }
        public Car ViewDetail(int id)
        {
            return db.Cars.Find(id);
        }
        
        public IEnumerable<Car> SearchAll(int? province, int page, int pagesize )
        {
            IQueryable<Car> model = db.Cars;
            if (province != null)
            {
                    model = model.Where(x => x.ProvinceId == province);
            }
            return model.OrderBy(x => x.ID).ToPagedList(page,pagesize);
        }

        public IEnumerable<Car> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Car> model = db.Cars;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Car> ListAllPagingByAgency(string searchString, int id, int page, int pageSize)
        {
            IQueryable<Car> model = db.Cars.Where(x => x.AgencyId == id);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public long Insert(Car entity)
        {
            db.Cars.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Car entity)
        {
            try
            {
                var car = db.Cars.Find(entity.ID);
                car.Name = entity.Name;
                car.ProvinceId = entity.ProvinceId;
                car.Price = entity.Price;
                car.Description = entity.Description;
                car.PriceSale = entity.PriceSale;
                car.PriceTotal = entity.PriceTotal;
                car.IncludedVAT = entity.IncludedVAT;
                car.Brand = entity.Brand;
                car.Image = entity.Image;
                car.Detail = entity.Detail;
                car.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var car = db.Cars.Find(id);
                db.Cars.Remove(car);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
