using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NasabahAPI.Models;
using NasabahAPI.Provider;

namespace NasabahAPI.Controllers
{
    public class NasabahController : ApiController
    {
        private NasabahProvider prov = new NasabahProvider();

        [HttpGet]
        public IHttpActionResult GetAllData() {
            try
            {
                var getData = prov.GetAllData();

                return Json(getData);
            }
            catch (Exception err)
            {
                return Json(err.Message);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataByKTP(string NoKTP)
        {
            try
            {
                var getData = prov.GetDataByKTP(NoKTP);

                return Json(getData);
            }
            catch (Exception err)
            {
                return Json(err.Message);
            }

        }

        [HttpPost]
        public IHttpActionResult CreateData(DataNasabahViewModel model) {
            try
            {
                prov.CreateData(model);
                return Json(new Result(true, "Success"));
            }
            catch (Exception err)
            {
                return Json(new Result(false, "Failed"));
            }
        }
        [HttpPost]
        public IHttpActionResult UpdateData(DataNasabahViewModel model)
        {
            try
            {
                prov.UpdateData(model);
                return Json(new Result(true, "Success"));
            }
            catch (Exception err)
            {
                return Json(new Result(false, "Failed"));
            }
        }
        [HttpPost]
        public IHttpActionResult DeleteData(DataNasabahViewModel model)
        {
            try
            {
                prov.DeleteData(model);
                return Json(new Result(true, "Success"));
            }
            catch (Exception err)
            {
                return Json(new Result(false, "Failed"));
            }
        }
    }
}
