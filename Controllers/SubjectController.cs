using DemoApi.DataAccess;
using DemoApi.Interface;
using DemoApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    public class SubjectController : Controller
    {
        private ISubjectDataAccess subjectDataAccess;
       public SubjectController(ISubjectDataAccess _subjectDataAccess) { 
         this.subjectDataAccess = _subjectDataAccess;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/getSubjectRecord")]
        public async Task<IActionResult> getSubjectRecord()
        {
            try
            {
                FunctionResponse result = await subjectDataAccess.getSubjectRecord();
                if (result.status=="ok")
                {
                    return new OkObjectResult(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/getSubjectDetailsByID")]
        public async Task<IActionResult> getSubjectDetailsByID(int subjectID)
        {
            try
            {
                FunctionResponse result = await subjectDataAccess.getSubjectDetailsByID(subjectID);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
