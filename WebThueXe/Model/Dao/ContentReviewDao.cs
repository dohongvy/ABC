using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentReviewDao
    {
        WebThueXeDBContext db = null;
        public ContentReviewDao()
        {
            db = new WebThueXeDBContext();
        }
        public Content GetByContentID(long id)
        {
            return db.Contents.Find(id);
        }

        public List<ContentReview> ListByCategoryId(int contentId)

        {
            return db.ContentReviews.Where(x => x.ContentId == contentId).ToList();
        }
    }
}
