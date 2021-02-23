using Dapper;
using LBSample.Configuration;
using LBSample.Entity.Models;
using LBSample.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Linq;

namespace LBSample.Repository.Concrete
{
    public class TestRepository : BaseRepository<SampleTable, int>, ITestRepository
    {
        private ConnectionStringsConfiguration conn = null;
        public TestRepository(SampleDBContext _dbcontext, IOptions<ConnectionStringsConfiguration> connStringConfig) : base(_dbcontext)
        {
            conn = connStringConfig.Value;
        }

        public SampleTable GetFirst()
        {
            return context.FirstOrDefault();
        }

        public SampleTable GetbyId(int id)
        {
            SampleTable retVal = null;
            string qry = @"SELECT * FROM SampleTable WHERE ColumnOne = @id";
            using (SqlConnection sqlConnection = new SqlConnection(conn.DefaultConnection))
            {
                retVal = sqlConnection.QueryFirstOrDefault<SampleTable>(qry, new { id = id });
            }

            return retVal;
        }
    }
}
