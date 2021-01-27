using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Identity.Role.Cmd;
using SoftIran.Application.ViewModels.Identity.Role.Query;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service= service;
        }

        #region list

        [HttpGet]
        //[Route("api/[controller]/[action]", Name = "[controller]_[action]")]
       // [Route(MapRoutes.RoleRoute.ListRoles)]
        [Route("v{version:apiVersion}/HelloWorld")]
        public async Task<IActionResult> ListRoles([FromQuery] RolesQuery request)
        {
            try
            {
                var result = await _service.GetRoles(request);
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

        #region upsert
        [HttpPost]
        [Route("api/identity/role/upsert")]
        public async Task<IActionResult> UpsertRole([FromBody] UpsertRoleCmd request)
        {
            try
            {
                var result = await _service.UpsertRole(request);
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
                    //e.Message 
                });
            }
        }
        #endregion

        #region delete
        [HttpDelete("api/role/{request}")]
        public async Task<ActionResult> DeleteRole([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteRole(request);
                return Ok(result);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = "BusinessLogic Error"
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

        #region get  single
        [HttpGet]
        [Route("api/role/{request}")]
        public async Task<IActionResult> SingleRole([FromRoute] string request)
        {
            try
            {
                var result = await _service.GetRole(request);
                return Ok(result);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = "BusinessLogic Error"
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
    }
}
