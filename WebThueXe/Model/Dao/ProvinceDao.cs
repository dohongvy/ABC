using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProvinceDao
    {
        WebThueXeDBContext db = null;
        public ProvinceDao()
        {
            db = new WebThueXeDBContext();
        }
        public List<Province> ListAll()
        {
            return db.Provinces.Where(x => x.Status == true).ToList();
        }
        public Province ViewDetail(int id)
        {
            return db.Provinces.Find(id);
        }

    }
}
