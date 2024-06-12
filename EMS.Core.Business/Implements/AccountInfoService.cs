using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Implements
{
    public class AccountInfoService : IAccountInfoService
    {
        private readonly AppDbContext _context;

        public AccountInfoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetPageAccountInfoResModel> GetPageAccountInfoAsync(long tenantId, BasePaginationReqModel input)
        {
            try
            {
                var query = _context.Accounts.GetAvailableByTenantIdQueryable(tenantId);
                query = query.OrderBy(record => record.Username);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new AccountInfoResModel
                {
                    Id = record.Id,
                    Username = record.Username,
                }).ToList();

                var result = new GetPageAccountInfoResModel
                {
                    Data = data,
                    TotalItems = totalItems,
                    PageNo = input.PageNo,
                    PageSize = input.PageSize,
                    TotalPages = (int)(Math.Floor((decimal)totalItems / input.PageSize))
                };
                return result; 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
