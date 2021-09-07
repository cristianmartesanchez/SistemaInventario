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
    public class ProductController : Controller
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
            var client = new HttpHelper<List<ProductDto>>();
            var data = await client.Get($"{Ruta}Products");

            return new JsonResult(data);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            var client = new HttpHelper<ProductDto>();
            var result = await client.Get($"{Ruta}Products/{id}");
            return View(result);
        }

        async Task DropDown()
        {
            var client = new HttpHelper<IEnumerable<UnitOfMeasureDto>>();
            var data = await client.Get($"{Ruta}UnitOfMeasure");
            ViewBag.UnitOfMeasure = new SelectList(data, "UnitOfMeasureId", "UnitOfMeasureName");
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            await DropDown();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDto model)
        {
            try
            {
                await DropDown();
                if (ModelState.IsValid)
                {
                    var client = new HttpHelper<ProductDto>();
                    var result = await client.Post($"{Ruta}Products", model);
                    return RedirectToAction("Detalle", new { id = result.Id });
                }

                return View();
            }
            catch(Exception ex)
            {
                
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            await DropDown();
            var client = new HttpHelper<ProductDto>();
            var result = await client.Get($"{Ruta}Products/{id}");
            return View(result);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductDto model)
        {
            try
            {
                await DropDown();
                if (ModelState.IsValid)
                {
                    var client = new HttpHelper<ProductDto>();
                    var result = await client.Put($"{Ruta}Products", model);
                    return RedirectToAction("Detalle", new { id = result.Id });
                }

                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
