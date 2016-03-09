using ApiService.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiService.Controllers
{
    [EnableCors(origins: "http://localhost:58892", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        // GET: api/Product
        public HttpResponseMessage Get()
        {
            DBContext db = new DBContext();
            var query = db.Product.ToList();

            //Change list to Product(object) list
            List<Product> products = new List<Product>();
            foreach (Product p in query)
            {
                products.Add(p);
            }
            //If has no count it'll "No itens"
            if (products.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new string[] { "No itens." });
            }
            return Request.CreateResponse(HttpStatusCode.OK, products );
        }

        // GET: api/Product/5
        public HttpResponseMessage Get(int id)
        {
            DBContext db = new DBContext();
            Product query = (from p in db.Product where p.id == id select p).First();
    
            return Request.CreateResponse(HttpStatusCode.OK, new { query });
        }

        // POST: api/Product
        public void Post([FromBody]JObject value)
        {
            DBContext db = new DBContext();
            dynamic json = value;
            Product p = new Product();
            p = json.Product.ToObject<Product>();
            db.Product.Add(p);
            db.SaveChanges();
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]JObject value)
        {
            DBContext db = new DBContext();
            dynamic json = value["Product"];

            var it = db.Product.Single(p => p.id == id);
            it.name = json.name;
            it.description = json.description;
            it.price = Convert.ToDouble(json.price);
            db.SaveChanges();
        }

        //PUT by List: api/Product 
        public void Put([FromBody]JObject value)
        {
            DBContext db = new DBContext();
            dynamic json = value["products"];
            foreach(var prod in json)
            {
                int id = 0;id = prod.Id;
                var it = db.Product.Single(p => p.id == id);
                it.name = prod.name;
                it.description = prod.description;
                it.price = Convert.ToDouble(prod.price);
                db.SaveChanges();
            }
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            DBContext db = new DBContext();
            db.Product.Remove(db.Product.Single(s => s.id == id));
            db.SaveChanges();
        }
    }
}
