using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CarAttributeDetailDao
    {
        WebThueXeDBContext db = null;
        public CarAttributeDetailDao()
        {
            db = new WebThueXeDBContext();
        }
        public List<CarAttributeDetail> ListAll()
        {
            return db.CarAttributeDetails.Where(x => x.Status == true).ToList();
        }
    
    }
}
