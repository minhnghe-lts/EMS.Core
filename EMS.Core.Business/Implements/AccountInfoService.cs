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

        public async Task<GetPageAccountInfoResModel> GetPageAccountInfoAsync(long tenantId, GetPageAccountInfoReqModel input)
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
                    Email = record.Email,
                    Note = record.Note,
                    History = record.History,
                }).ToList();

                var result = new GetPageAccountInfoResModel
                {
                    Data = data,
                    TotalItems = totalItems,
                    PageNo = input.PageNo,
                    PageSize = input.PageSize,
                    TotalPages = (int)(Math.Ceiling((decimal)totalItems / input.PageSize))
                };
                return result; 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AccountInfoResModel> GetAccountInfoByIdAsync(long tenantId, long id)
        {
            try
            {
                var account = _context.Accounts
                    .GetAvailableByTenantIdQueryable(tenantId)
                    .Where(record => record.Id == id && !record.IsDeleted && record.IsActive)
                    .FirstOrDefault();

                if(account == null)
                {
                    throw new ItemNotFoundException();
                }

                var data = new AccountInfoResModel
                {
                    Id = account.Id,
                    Username = account.Username,
                    Email = account.Email,
                    Note = account.Note,
                    History = account.History,
                };

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateAccount(CreateOrEditAccountReqModel input)
        {
            try
            {
                var newAccount = new Account
                {
                    Email = input.Email,
                    Username = input.Username,
                    Password = Utilities.HashPassword(input.Password),
                    Note = input.Note,
                    History = DateTime.Now,
                    EmployeeId = input.EmployeeId,

                    AccountRoles = input.RoleIds.Select(item => new AccountRole
                    {
                        RoleId = item,
                    }).ToList(),
                    AccountPermissions = input.PermissionIds.Select(item => new AccountPermission
                    {
                        PermissionId = item,
                    }).ToList()
                };

                _context.Accounts.Add(newAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditAccount(CreateOrEditAccountReqModel input)
        {
            try
            {
                var account = _context.Accounts
                    .Where(record => record.Id == input.Id && !record.IsDeleted)
                    .FirstOrDefault();

                if(account == null)
                {
                    throw new ItemNotFoundException();
                }

                account.Email = input.Email;
                account.Username = input.Username;
                account.Password = Utilities.HashPassword(input.Password);
                account.Note = input.Note;  
                account.History = DateTime.Now;
                account.EmployeeId = input.EmployeeId;

                var accountRoles = _context.AccountRoles.Where(record => record.AccountId == input.Id).AsEnumerable();
                _context.AccountRoles.RemoveRange(accountRoles);
                account.AccountRoles = input.RoleIds.Select(item => new AccountRole
                {
                    RoleId = item
                }).ToList();

                var accountPermissions = _context.AccountPermissions.Where(record => record.AccountId == input.Id).AsEnumerable();
                _context.AccountPermissions.RemoveRange(accountPermissions);
                account.AccountPermissions = input.PermissionIds.Select(item => new AccountPermission
                {
                    PermissionId = item
                }).ToList();

                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAccount(long id)
        {
            try
            {
                var existingAccount = _context.Accounts.GetAvailableById(id);
                if(existingAccount == null)
                {
                    throw new ItemNotFoundException();
                }
                existingAccount.IsDeleted = true;
                _context.Accounts.Update(existingAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
