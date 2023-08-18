using Dapper;
using DemoApi.Interface;
using DemoApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace DemoApi.DataAccess
{
    public class SubjectDataAccess : ISubjectDataAccess
    {
        private readonly ConnectionStrings connectionStrings;
        public SubjectDataAccess(IOptions<ConnectionStrings> options)
        {
            connectionStrings = options.Value;
        }

        public async Task<FunctionResponse> getSubjectRecord()
        {
            try {
                var constr = connectionStrings.constring;
                using (var connection = new SqlConnection(constr))
                {
                    var query = "select * from subject";
                    var result = connection.Query(query);
                    return new FunctionResponse { result = result };   
                }

            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }public async Task<FunctionResponse> getSubjectDetailsByID(int subjectID)
        {
            try {
                var constr = connectionStrings.constring;
                using (var connection = new SqlConnection(constr))
                {
                    var query = "select * from subject where subjectID=@subjectID";
                    var result = connection.Query(query, new { subjectID = subjectID });
                    return new FunctionResponse { result = result };   
                }

            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
