using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Implements
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BasePaginationResModel<AccountResModel>> GetPageAccountAsync(long tenantId, GetPageAccountReqModel input)
        {
            try
            {
                var query = _context.Accounts.GetAvailableByTenantIdQueryable(tenantId);
                query = query.OrderBy(record => record.Username);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new AccountResModel
                {
                    Id = record.Id,
                    Username = record.Username,
                    Email = record.Email,
                    Note = record.Note,
                    History = record.History,
                }).ToList();

                var result = new BasePaginationResModel<AccountResModel>
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

        public async Task<AccountResModel> GetAccountByIdAsync(long tenantId, long id)
        {
            try
            {
                var account = _context.Accounts
                    .GetAvailableByTenantIdQueryable(tenantId)
                    .Where(record => record.Id == id && record.IsActive)
                    .FirstOrDefault();

                var data = new AccountResModel
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

                    AccountRoles = input.RoleIds.Select(itemId => new AccountRole
                    {
                        RoleId = itemId,
                    }).ToList(),
                    AccountPermissions = input.PermissionIds.Select(itemId => new AccountPermission
                    {
                        PermissionId = itemId,
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

        public async Task EditAccount(long id, CreateOrEditAccountReqModel input)
        {
            try
            {
                var account = _context.Accounts
                    .Where(record => record.Id == id && !record.IsDeleted)
                    .FirstOrDefault();

                if(account == null)
                {
                    throw new ItemNotFoundException();
                }

                var accountRoles = _context.AccountRoles.Where(record => record.AccountId == id).AsEnumerable();
                _context.AccountRoles.RemoveRange(accountRoles);
                account.AccountRoles = input.RoleIds.Select(itemId => new AccountRole
                {
                    RoleId = itemId
                }).ToList();

                var accountPermissions = _context.AccountPermissions.Where(record => record.AccountId == id).AsEnumerable();
                _context.AccountPermissions.RemoveRange(accountPermissions);
                account.AccountPermissions = input.PermissionIds.Select(itemId => new AccountPermission
                {
                    PermissionId = itemId
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
