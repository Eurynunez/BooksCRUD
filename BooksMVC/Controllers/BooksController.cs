using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksMVC.Models;
using BooksMVC.Models.ViewModels;

namespace BooksMVC.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        [HttpGet]
        public ActionResult Index()
        {
            List<Book> LstBook = new List<Book>();
            using (BOOKSDBEntities DB = new BOOKSDBEntities())
            {
                LstBook = (from d in DB.BOOK
                           select new Book
                           {
                               Id = d.ID,
                               Nombre = d.NOMBRE,
                               Autor = d.AUTOR
                           }).ToList();
                          
            }

                return View(LstBook);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(NewBook item)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (BOOKSDBEntities DB = new BOOKSDBEntities())
                    {
                        var NewBook = new BOOK();
                        NewBook.NOMBRE = item.Nombre;
                        NewBook.AUTOR = item.Autor;
                        NewBook.FECHA_CREACION = item.FechaCreacion;

                        DB.BOOK.Add(NewBook);
                        DB.SaveChanges();
                    }

                    return Redirect("~/Books");
                }

                return View(item);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        [HttpPost]
        public ActionResult Edit(int Id)
        {
            NewBook newBook = new NewBook();
            using (BOOKSDBEntities DB = new BOOKSDBEntities())
            {
                var item = DB.BOOK.Find(Id);
                newBook.Id = item.ID;
                newBook.Nombre = item.NOMBRE;
                newBook.Autor = item.AUTOR;
                newBook.FechaCreacion = item.FECHA_CREACION.Value.Date;

            }

            return View(newBook);
        }

        [HttpPost]
        public ActionResult Edit(NewBook model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (BOOKSDBEntities DB = new BOOKSDBEntities())
                    {
                        var item = DB.BOOK.Find(model.Id);
                        item.NOMBRE = model.Nombre;
                        item.AUTOR = model.Autor;
                        item.FECHA_CREACION = model.FechaCreacion;

                        DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                    }

                    return Redirect("~/Books");
                }

                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Book model = new Book();
            using (BOOKSDBEntities DB = new BOOKSDBEntities())
            {
                var item = DB.BOOK.Find(Id);
                DB.BOOK.Remove(item);
                DB.SaveChanges();
            }

            return Redirect("~/Books");
        }
    }
}
