using System.Web.Http;
using PetSmart.Entities;
using System;
using PetSmart.DAL;

namespace PetSmart.API.Controllers
{
    [RoutePrefix("Status")]
    public class StatusController : ApiController
    {
        [HttpGet]
        [Route("Web")]
        public string ApplicationStatusCheck()
        {
            return "Web application running successfully";
        }

        [HttpGet]
        [Route("SQL")]
        public string MySQLStatusCheck()
        {
            try
            {
                SQLConnection.Verify();
                return "MySQL connected successfully";
            }
            catch (Exception ex){
                return "MySQL connection failed. Exception: " + ex.Message;
            }
        }

        [HttpGet]
        [Route("Config")]
        public string ConfigFileCheck() {
            try {
                Helper.CheckConfigFile();
            }
            catch(Exception ex) {
                return "Exception while reading config file. Exception: " + ex.Message;
            }
            return "Config file read successfully";
        }
    }
}
