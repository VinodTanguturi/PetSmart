using PetSmart.Entities;
using System.Linq;

namespace PetSmart.DAL
{
    public class SQLConnection
    {
        public static void Verify() {
            string value = DALHelper.Query<string>(sql: "SELECT 'PetSmart'", commandType: System.Data.CommandType.Text, database: "Test").FirstOrDefault();
        }
    }
}
