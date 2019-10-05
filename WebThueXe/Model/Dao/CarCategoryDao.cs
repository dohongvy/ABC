using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CarCategoryDao
    {
        WebThueXeDBContext db = null;
        public CarCategoryDao()
        {
            db = new WebThueXeDBContext();
        }
        public List<CarCategory> ListAll()
        {
            return db.CarCategories.Where(x => x.Status == true).ToList();
        }

    }
}
