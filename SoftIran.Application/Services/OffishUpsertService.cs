using Microsoft.EntityFrameworkCore;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Offish.Cmd;
using SoftIran.DataLayer.Models.Context;
using SoftIran.DataLayer.Models.Entities;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services
{
    public class OffishUpsertService : IOffishUpsert
    {
        private readonly AppDBContext _context;
        public OffishUpsertService(AppDBContext context)
        {
            _context = context;
        }

        #region  ActionCancel
        public Task<Response> UpsertActionCancel(UpsertActionCancelCmd request)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ActionEquipmentDelivery
        public Task<Response> UpsertActionEquipmentDelivery(UpsertActionEquipmentDeliveryCmd request)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region ActionEquipmentRetake
        public Task<Response> UpsertActionEquipmentRetake(UpsertActionEquipmentRetakeCmd request)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region  ActionRegister
        public async Task<Response> UpsertActionRegister(UpsertActionRegisterCmd request)
        {
            if (!string.IsNullOrEmpty(request.OffishId))
            {
                var item = await _context.Offishes.SingleOrDefaultAsync(z => z.Id == request.OffishId);

                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                item.PGMId = request.PgmId;
                item.CategoryId = request.CategoryId;
                item.StartDate = request.StartDate;
                item.StartTime = request.StartTime;
                item.EndDate = request.EndDate;
                item.EndTime = request.EndTime;
                //avamel
                var offishusers = _context.OffishUsers.Where(x => x.OffishId == request.OffishId);
                _context.OffishUsers.RemoveRange(offishusers);
                foreach (var avamel in request.Avamel)
                {
                    var employee = new OffishUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId=avamel.UserId,
                        RoleId=avamel.RoleId,
                        OffishId=request.OffishId
                    };
                    await _context.OffishUsers.AddAsync(employee);
                }

                ///
                _context.Offishes.Update(item);
              

            }
            else
            {
                var item = new Offish
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = request.CategoryId,
                    StartDate = request.StartDate,
                    StartTime = request.StartTime,
                    EndDate = request.EndDate,
                    EndTime = request.EndTime

                };
               await  _context.Offishes.AddAsync(item);


                //avamel
                var offishusers = _context.OffishUsers.Where(x => x.OffishId == request.OffishId);
                _context.OffishUsers.RemoveRange(offishusers);
                foreach (var avamel in request.Avamel)
                {
                    var employee = new OffishUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = avamel.UserId,
                        RoleId = avamel.RoleId,
                        OffishId = request.OffishId
                    };
                    await _context.OffishUsers.AddAsync(employee);
                }




            }

            await _context.SaveChangesAsync();

            return new Response
            {
                Status = true,
                Message = "success"
            };

        }
        #endregion


        #region  ActionReject
        public async Task<Response> UpsertActionReject(UpsertActionRejectCmd request)
        {
            if (!string.IsNullOrEmpty(request.OffishId))
            {
                var item = await _context.Offishes.SingleOrDefaultAsync(z => z.Id == request.OffishId);

                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }

                // item.ActoinId = Guid.NewGuid().ToString();
                // item.PGMId=request.
                throw new BusinessLogicException("رکوردی یافت نشد");
            }
            throw new BusinessLogicException("رکوردی یافت نشد");
        }
        #endregion


    }
}
