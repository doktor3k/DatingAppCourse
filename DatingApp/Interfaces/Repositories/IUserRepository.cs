using DatingApp.DTO;
using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUserNameAsync(string name);

        Task<IEnumerable<MemberDto>> GetMembersAsync();

        Task<MemberDto> GetMemberAsync(string username);
        
    }
}
