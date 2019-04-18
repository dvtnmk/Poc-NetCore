using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.DataLayer.Entity;
using Newtonsoft.Json;

namespace Workshop.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Province")]
    public class ApiController : Controller
    {
        [HttpGet]
        public IList<Province> get()
        {
            ProvinceService service = new ProvinceService();
            
            return service.Get().ToList();
            //return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public Province GetProvincesById(int id)
        {
            ProvinceService service = new ProvinceService();
            return service.get(id);
        }

        [HttpPut]
        public JsonResult UpdateProvince(int id, [FromBody]Province value)
        {
            try
            {
                ProvinceService service = new ProvinceService();
                var entity = service.get(id);
                if(entity == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                JsonConvert.PopulateObject(JsonConvert.SerializeObject(value), entity,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                entity.UpdateDate = DateTime.Now;
                service.Update(id, entity);

                return Json("{ success : 1}");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}