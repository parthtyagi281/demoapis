using Dapper;
using DemoApi.Interface;
using DemoApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace DemoApi.DataAccess
{
    public class StudentDataAccess : IStudentDataAccess
    {
        private readonly ConnectionStrings connectionStrings;
        public StudentDataAccess(IOptions<ConnectionStrings> options)
        {
            connectionStrings = options.Value;
        }

        public async Task<FunctionResponse> getStudentRecord()
        {
            try
            {
                var constr = connectionStrings.constring;
                using(var connection = new SqlConnection(constr))
                {
                    var query = "select * from student";
                    var result = connection.Query(query);
                    if (result.ToList().Count() > 0)
                    {
                        return new FunctionResponse { status="ok",result = result };
                    }
                    else
                    {
                        return new FunctionResponse { status = "error", message = "No Data available" };
                    }
                }
            }catch(Exception ex) {
                throw new Exception(ex.Message);    
            }
        }

        public async Task<FunctionResponse> getStudentDetailsByID(int StudentID)
        {
            try
            {
                var constr = connectionStrings.constring;
                using (var connection = new SqlConnection(constr))
                {
                    var query = "select * from student where StudentID=@StudentID";
                    var result = connection.Query(query, new { StudentID = StudentID });
                    if (result.ToList().Count() > 0)
                    {
                        return new FunctionResponse { result = result };
                    }
                    else
                    {
                      return  new FunctionResponse {status="error",message="No Data available" };
                    }
                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<FunctionResponse> addStudent(StudentModel studentModel)
        {
            try
            {
                var constr = connectionStrings.constring;
                using (var connection = new SqlConnection(constr))
                {
                    //var query = "select * from student where rollno =@rollno and studentclass=@studentclass";
                    //var result = connection.Query(query, new { rollno = studentModel.rollno, studentclass = studentModel.studentclass });
                    //if (result.ToList().Count() > 0)
                    //{
                    //    return new FunctionResponse { status = "error", message = "Roll No duplicate" };
                    //}
                    //else
                    //{
                    //    var insertquery = "INSERT into student(studentname,rollno,studentclass,fathername,mothername)values(@studentname,@rollno,@studentclass,@fathername,@mothername)";
                    //    var insertresult = connection.Query(insertquery, studentModel);
                    //    return new FunctionResponse { status = "success", message = "Data insert successfully" };
                    //}
                    var parameter = new DynamicParameters();
                    parameter.Add("@studentname",studentModel.studentname);
                    parameter.Add("@rollno", studentModel.rollno);
                    parameter.Add("@studentclass", studentModel.studentclass);
                    parameter.Add("@fathername", studentModel.fathername);
                    parameter.Add("@mothername", studentModel.mothername);
                    parameter.Add("@Result", null, dbType: DbType.String, ParameterDirection.Output, 200);
                    var result = await connection.ExecuteAsync("AddStudentData", parameter, null, null, commandType: CommandType.StoredProcedure);
                    var _result = parameter.Get<string>("@Result");
                    if(_result== "success")
                    {
                        return new FunctionResponse { status = "success", message = "Data insert successfully" };
                    }
                    else {
                        return new FunctionResponse { status = "error", message = "Data insert unsuccessful" };
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
