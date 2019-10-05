using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CarAttributeDao
    {
        WebThueXeDBContext db = null;
        public CarAttributeDao()
        {
            db = new WebThueXeDBContext();
        }
        public List<CarAttribute> ListAll()
        {
            return db.CarAttributes.ToList();
        }
    }
}
