using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentType.Query;
using SoftIran.Application.ViewModels.EquipmentType.Upsert;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
    [ApiController]
    public class EquipmentTypeController : ControllerBase
    {
        private readonly IEquipmentType _service;
        public EquipmentTypeController(IEquipmentType service)
        {
            _service = service;
        }


        #region upsert
        [HttpPost]
        [Route("api/equipment/type/upsert")]
        public async Task<IActionResult> UpsertEquipment([FromBody] UpsertEquipmentTypeCmd request)
        {
            try
            {
                var result = await _service.UpsertEquipmentType(request);
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

        #region delete
        [HttpDelete("api/equipment/type/{request}")]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteEquipmentType(request);
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

        #region list

        [HttpGet]
        [Route("api/equipment/type/list")]
        public async Task<IActionResult> ListEquipmentTypes([FromQuery] EquipmentTypesQuery request)
        {
            try
            {
                var result = await _service.GetEquipmentTypes(request);
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
        [Route("api/equipment/type/single")]
        public async Task<IActionResult> SingleEquipmentType([FromQuery] string request)
        {
            try
            {
                var result = await _service.GetEquipmentType(request);
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
