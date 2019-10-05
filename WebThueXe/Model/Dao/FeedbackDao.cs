using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FeedbackDao
    {
        WebThueXeDBContext db = null;
        public FeedbackDao()
        {
            db = new WebThueXeDBContext();
        }
        public Feedback ViewDetail(int id)
        {
            return db.Feedbacks.Find(id);
        }
        public int InsertFeedback(Feedback feedback)
        {
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return feedback.ID;
        }
        public IEnumerable<Feedback> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Feedback> model = db.Feedbacks;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public bool Update(Feedback entity)
        {
            try
            {
                var feedback = db.Feedbacks.Find(entity.ID);
                feedback.Name = entity.Name;
                feedback.Phone = entity.Phone;
                feedback.Address = entity.Address;
                feedback.Email = entity.Email;
                feedback.CreateDate = DateTime.Now;
                feedback.Content = entity.Content;
                feedback.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
    }
}
