using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Offish.Cmd;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
     
    [ApiController]
    public class OffishController : ControllerBase
    {
        private readonly IOffishUpsert _service;
        public OffishController(IOffishUpsert service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route("api/offish/upsert/action/register")]
        public async Task<IActionResult> ActionRegister([FromBody] UpsertActionRegisterCmd request)
        {
            try
            {
                var result = await _service.UpsertActionRegister(request);
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
                    //e.Message 
                });
            }
        }
        #endregion




    }
}
