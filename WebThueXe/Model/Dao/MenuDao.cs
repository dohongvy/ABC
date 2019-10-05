using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class MenuDao
    {
        WebThueXeDBContext db = null;
        public MenuDao()
        {
            db = new WebThueXeDBContext();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId).ToList();
        }

    }
}
