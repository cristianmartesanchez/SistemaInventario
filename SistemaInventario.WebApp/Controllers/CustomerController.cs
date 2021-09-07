using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventario.Core.DTOs;
using SistemaInventario.Core.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SistemaInventario.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly string Ruta = "http://localhost:8092/api/";
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List()
        {
            var client = new HttpHelper<List<CustomerDto>>();
            var data = await client.Get($"{Ruta}Customer");

            return new JsonResult(data);
        }

        async Task DropDown()
        {
            var client = new HttpHelper<IEnumerable<CustomerTypeDto>>();
            var data = await client.Get($"{Ruta}CustomerType");
            ViewBag.CustomerType = new SelectList(data, "CustomerTypeId", "CustomerTypeName");
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            var client = new HttpHelper<CustomerDto>();
            var result = await client.Get($"{Ruta}Customer/{id}");
            return View(result);
        }

        // GET: CustomerController/Create
        public async Task<ActionResult> Create()
        {
            await DropDown();
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerDto model)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    var client = new HttpHelper<CustomerDto>();
                    var result = await client.Post($"{Ruta}Customer",model);
                    return RedirectToAction("Detalle", new { id = result.CustomerId });
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            await DropDown();
            var client = new HttpHelper<CustomerDto>();
            var result = await client.Get($"{Ruta}Customer/{id}");
            return View(result);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerDto model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var client = new HttpHelper<CustomerDto>();
                    var result = await client.Put($"{Ruta}Customer", model);
                    return RedirectToAction("Detalle", new { id = result.CustomerId });
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
