using DemoApi.Interface;
using DemoApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    public class StudentController : Controller
    {
        private IStudentDataAccess studentDataAccess;
        public StudentController(IStudentDataAccess _studentDataAccess)
        {
            this.studentDataAccess = _studentDataAccess;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/getStudentRecord")]
        public async Task<IActionResult> getStudentRecord()
        {
            try
            {
                FunctionResponse result = await studentDataAccess.getStudentRecord();
                if (result.status == "ok")
                {
                    return new OkObjectResult(result);
                }
                else
                {
                    return BadRequest(result);
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/getStudentDetailsByID")]
        public async Task<IActionResult> getStudentDetailsByID(int StudentID)
        {
            try
            {
                FunctionResponse result = await studentDataAccess.getStudentDetailsByID(StudentID);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("api/addStudent")]
        public async Task<IActionResult> addStudent([FromBody]StudentModel studentModel)
        {
            try
            {
                FunctionResponse result = await studentDataAccess.addStudent(studentModel);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
