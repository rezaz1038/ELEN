using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentPlace.Query;
using SoftIran.Application.ViewModels.EquipmentPlace.Upsert;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
    [ApiController]
    public class EquipmentPlaceController : ControllerBase
    {
        private readonly IEquipmentPlace _service;
        public EquipmentPlaceController(IEquipmentPlace service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route("api/equipment/place/upsert")]
        public async Task<IActionResult> UpsertEquipment([FromBody] UpsertEquipmentPlaceCmd request)
        {
            try
            {
                var result = await _service.UpsertEquipmentPlace(request);
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
        [HttpDelete("api/equipment/place/{request}")]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteEquipmentPlace(request);
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
        [Route("api/equipment/place/list ")]
        public async Task<IActionResult> ListEquipmentPlaces([FromQuery] EquipmentPlacesQuery request)
        {
            try
            {
                var result = await _service.GetEquipmentPlaces(request);
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
        [Route("api/equipment/place/single ")]
        public async Task<IActionResult> SingleEquipmentPlace([FromQuery] string request)
        {
            try
            {
                var result = await _service.GetEquipmentPlace(request);
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
