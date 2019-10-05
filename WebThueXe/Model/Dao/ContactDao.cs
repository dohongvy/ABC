using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContactDao
    {
        WebThueXeDBContext db = null;
        public ContactDao()
        {
            db = new WebThueXeDBContext();
        }
        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }
        public int InsertFeedback(Feedback feedback)
        {
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return feedback.ID;
        }

    }
}
