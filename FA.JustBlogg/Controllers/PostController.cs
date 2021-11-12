using FA.JustBlogg.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlogg.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        FA_JustBloggEntities dbObj = new FA_JustBloggEntities();
        public ActionResult Post(tbl_PostList obj)
        {
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddPost(tbl_PostList model)
        {
            if (ModelState.IsValid)
            {
                tbl_PostList obj = new tbl_PostList();
                obj.Name = model.Name;
                obj.ShortDescription = model.ShortDescription;
                obj.Description = model.Description;
                obj.PostedOn = model.PostedOn;

                if(model.ID == 0)
                {
                    dbObj.tbl_PostList.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();
                
            
            return View("Post");
        }

        public ActionResult PostList()
        {
            var res = dbObj.tbl_PostList.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.tbl_PostList.Where(x => x.ID == id).First();
            dbObj.tbl_PostList.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.tbl_PostList.ToList();

            return View("PostList", list);
        }
    }
}