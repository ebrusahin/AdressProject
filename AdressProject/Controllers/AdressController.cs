using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdressProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdressProject.Controllers
{
    public class AdressController : Controller
    {
        // GET: Adress

        private Context con;

        public AdressController(Context con)
        {
            this.con = con;
        }
        public ActionResult Index()
        {
            var list = con.Adresses.ToList();
            var f = con.Adresses.Include(p => p.AdressType).ToList();
            return View(f);
        }

        // GET: Adress/Details/5
        public ActionResult Details(int id)
        {
            var f = con.Adresses.Include(p => p.AdressType).Where(x => x.Id == id).FirstOrDefault();
            return View(f);
        }

        // GET: Adress/Create
        public ActionResult Create()
        {
            ViewBag.AdressTypess = new SelectList(con.AdressTypes, "AdressTypeId", "AdressTipi");
            return View();
        }

        // POST: Adress/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here Adress p = new Adress();
                Adress p = new Adress();
                //p.Id = Convert.ToInt32(collection["Id"]);
                p.Name = collection["Name"];
                p.SurName = collection["SurName"];
                p.PhoneNumber = collection["PhoneNumber"];
                p.Adres = collection["Adres"];
                
                //con.Adresses.Update(p);
                Microsoft.Extensions.Primitives.StringValues f;
                if (collection.TryGetValue("AdressType", out f))
                {
                    p.AdressType = new AdressType() { AdressTypeId = Convert.ToInt32(f[0]) };

                }
                con.Entry(p).State = EntityState.Added;
                con.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Adress/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.AdressTypess = new SelectList(con.AdressTypes, "AdressTypeId", "AdressTipi");
            var f = con.Adresses.Include(p => p.AdressType).Where(x => x.Id == id).FirstOrDefault();
            return View(f);
        }

        // POST: Adress/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Adress dd)
        {
            try
            {
                // TODO: Add update logic here
                Adress p = new Adress();
                p.Id = Convert.ToInt32(collection["Id"]);
                p.Name = collection["Name"];
                p.SurName = collection["SurName"];
                p.PhoneNumber= collection["PhoneNumber"];
                p.Adres= collection["Adres"];
                p.AdressTypeId = dd.AdressType.AdressTypeId;
                con.Adresses.Update(p);

                con.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Adress/Delete/5
        public ActionResult Delete(int id)
        {
            var f = con.Adresses.Include(p => p.AdressType).Where(x => x.Id == id).FirstOrDefault();
            return View(f);
        }

        // POST: Adress/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var f = con.Adresses.Find(id);

                con.Adresses.Remove(f);
                con.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}