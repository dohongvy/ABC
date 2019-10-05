using Common;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Model.Dao
{
    public class ContentDao
    {
        WebThueXeDBContext db = null;
        public ContentDao()
        {
            db = new WebThueXeDBContext();
        }
        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
        public Tag GetTag(string id)
        {
            return db.Tags.Find(id);
        }
        public IEnumerable<Content> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        /// <summary>
        ///  List all content for member
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Content ViewDetail(int id)
        {
            return db.Contents.Find(id);
        }
        public long Create(Content content)
        {

            if (string.IsNullOrEmpty(content.MetaTitle))
            {
                content.MetaTitle = StringHelper.ToUnsignString(content.Name);
            }
            content.CreateDate = DateTime.Now;
            db.Contents.Add(content);
            db.SaveChanges();

            //Xử lý tag
            if (!string.IsNullOrEmpty(content.Tags))
            {
                string[] tags = content.Tags.Split(',');
                foreach (var tag in tags)
                {
                    var tagId = StringHelper.ToUnsignString(tag);
                    var existedTag = this.CheckTag(tagId);
                    //insert to tag table
                    if (!existedTag)
                    {
                        this.InsertTag(tagId, tag);
                    }

                    //insert to content tag
                    this.InsertContentTag(content.ID, tagId);
                }
            }

            return content.ID;
        }

        public void InsertTag(string id, string name)
        {
            var tag = new Tag();
            tag.ID = id;
            tag.Name = name;
            db.Tags.Add(tag);
            db.SaveChanges();
        }
        
        public bool CheckTag(string id)
        {
            return db.Tags.Count(x => x.ID == id) > 0;
        }
        public List<Tag> ListTag(int contentId)
        {
            var model = (from a in db.Tags
                         join b in db.ContentTags
                         on a.ID equals b.TagId
                         where b.ContentId == contentId
                         select new
                         {
                             ID = b.TagId,
                             Name = a.Name
                         }).AsEnumerable().Select(x => new Tag()
                         {
                             ID = x.ID,
                             Name = x.Name
                         });
            return model.ToList();
        }
        public long Edit(Content content)
        {
                if (string.IsNullOrEmpty(content.MetaTitle))
                {
                    content.MetaTitle = StringHelper.ToUnsignString(content.Name);
                }
                content.CreateDate = DateTime.Now;
                db.Contents.Add(content);
                db.SaveChanges();

                //Xử lý tag
                if (!string.IsNullOrEmpty(content.Tags))
                {
                    this.RemoveAllContentTag(content.ID);
                    string[] tags = content.Tags.Split(',');
                    foreach (var tag in tags)
                    {
                        var tagId = StringHelper.ToUnsignString(tag);
                        var existedTag = this.CheckTag(tagId);
                        //insert to tag table
                        if (!existedTag)
                        {
                            this.InsertTag(tagId, tag);
                        }

                        //insert to content tag
                        this.InsertContentTag(content.ID, tagId);
                    }
                }
            return content.ID;

        }
        public void InsertContentTag(int contentId, string tagId)
        {
            var contentTag = new ContentTag();
            contentTag.ContentId = contentId;
            contentTag.TagId = tagId;
            db.ContentTags.Add(contentTag);
            db.SaveChanges();
        }
        public void RemoveAllContentTag(long contentId)
        {
            db.ContentTags.RemoveRange(db.ContentTags.Where(x => x.ContentId == contentId));
            db.SaveChanges();
        }
        public bool ChangeStatus(int id)
        {
            var content = db.Contents.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Content> ListNewContent(int top)
        {
            return db.Contents.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public IEnumerable<Content> ListAllByTag(string tag, int page, int pageSize)
        {
            var model = (from a in db.Contents
                         join b in db.ContentTags
                         on a.ID equals b.ContentId
                         where b.TagId == tag
                         select new
                         {
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Image = a.Image,
                             Description = a.Description,
                             CreatedDate = a.CreateDate,
                             CreatedBy = a.CreateBy,
                             ID = a.ID

                         }).AsEnumerable().Select(x => new Content()
                         {
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Image = x.Image,
                             Description = x.Description,
                             CreateDate = x.CreatedDate,
                             CreateBy = x.CreatedBy,
                             ID = x.ID
                         });
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }


        
    }
}
