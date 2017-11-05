using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace PetSmart.Entities
{
    public static class Helper
    {
        public static void CheckConfigFile() {
            ReadConfigFile(true);
        }

        public static string GetConnectionString(string database = null)
        {
            Internal.MySQLConnString value = GetConfigProperty<Internal.MySQLConnString>("MySQLConnection");
            string connString = string.Format("Server={0};Port={1};Uid={2};Pwd={3};Database={4};", value.Server, value.Port, value.Uid, value.Pwd, string.IsNullOrEmpty(database) ? "PetsHome" : database);
            return connString;
        }

        //NOTE: Shouldn't make this public, Properties can be consumed only in the Helper
        private static T GetConfigProperty<T>(string key) {
            var propertyValue = ReadConfigFile()[key];
            if (propertyValue == null)
                throw new Exception("Property doesnt exist in the Config File");
            return propertyValue.ToObject<T>();
        } 

        //NOTE: Shouldn't make this public, as the complete Config file will be available
        private static JObject ReadConfigFile(bool throwError = false)
        {
            string configJson = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader("C:/PetSmartConfig.json"))
                {
                    configJson = sr.ReadToEnd();
                }
            }
            catch
            {
                if (throwError)
                {
                    throw;
                }
                configJson = "{}";
            }
            JObject jo = JObject.Parse(configJson);
            return jo;
        }
    }
}
