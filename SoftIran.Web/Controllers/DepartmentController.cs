using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Department.Query;
using SoftIran.Application.ViewModels.Department.Upsert;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("2.0")]
    
   
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _service;

        public DepartmentController(IDepartment service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route("v1/api/department/upsert")]
        public async Task<IActionResult> UpsertDepartment([FromBody] UpsertDepartmentCmd request)
        {
            try
            {
                var result = await _service.UpsertDepartment(request);
                return Ok(result);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ex.Message
                });

            }
            catch (Exception e)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ErrorMessages.UnkownError
                });
            }
 

        }
        #endregion

        #region list

        [HttpGet]
        [Route(MapRoutes.DepartmentRoute.List)]
        public async Task<IActionResult> ListDepartments([FromQuery] DepartmentsQuery request)
        {
            if (request != null)
            {
                var result = await _service.GetDepartments(request);
                return Ok(result);
            }

            return BadRequest();

        }
        #endregion

        #region get department
        [HttpGet]
        [Route("api/department/single ")]
        public async Task<IActionResult> SingleDepartment([FromQuery] string request)
        {
            if (request != null)
            {
                var result = await _service.GetDepartment(request);
                return Ok(result);
            }

            return BadRequest();

        }
        #endregion

        #region delete
        [HttpDelete("api/department/{request}")]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            if (request != null)
            {
                var result = await _service.DeleteDepartment(request);
                return Ok(result);
            }

            return BadRequest();
        }
        #endregion

    }
}
