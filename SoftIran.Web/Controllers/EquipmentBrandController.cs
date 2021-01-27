using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentBrand.Query;
using SoftIran.Application.ViewModels.EquipmentBrand.Upsert;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
    [ApiController]
    public class EquipmentBrandController : ControllerBase
    {
        private readonly IEquipmentBrand _service;

        public EquipmentBrandController(IEquipmentBrand service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route("api/equipment/brand/upsert")]
        public async Task<IActionResult> UpsertEquipmentBrand([FromBody] UpsertEquipmentBrandCmd request)
        {
            try
            {
                var result = await _service.UpsertEquipmentBrand(request);
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
        [HttpDelete("api/equipment/brand/{request}")]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteEquipmentBrand(request);
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
        [Route("api/equipment/brand/list ")]
        public async Task<IActionResult> ListEquipmentBrands([FromQuery] EquipmentBrandsQuery request)
        {
            try
            {
                var result = await _service.GetEquipmentBrands(request);
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
        [Route("api/equipment/brand/single ")]
        public async Task<IActionResult> SingleEquipmentBrand([FromQuery] string request)
        {
            try
            {
                var result = await _service.GetEquipmentBrand(request);
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
