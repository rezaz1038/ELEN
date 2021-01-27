using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Equipment.Query;
using SoftIran.Application.ViewModels.Equipment.Upsert;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipment _service;

        public EquipmentController(IEquipment service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route("api/equipment/upsert")]
        public async Task<IActionResult> UpsertEquipment ([FromBody] UpsertEquipmentCmd request)
        {
            try
            {
                var result = await _service.UpsertEquipment(request);
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
        [HttpDelete("api/equipment/{request}")]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteEquipment(request);
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
        [Route("api/equipment/list ")]
        public async Task<IActionResult> ListEquipmentBrands([FromQuery] EquipmentsQuery request)
        {
            try
            {
                var result = await _service.GetEquipments(request);
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
                    //Message = ErrorMessages.UnkownError
                    Message = e.Message
                });
            }





        }
        #endregion

        #region get  single
        [HttpGet]
        [Route("api/equipment/single ")]
        public async Task<IActionResult> SingleEquipment([FromQuery] string request)
        {
            try
            {
                var result = await _service.GetEquipment(request);
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
