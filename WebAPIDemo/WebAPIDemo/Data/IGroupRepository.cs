using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Data
{
    public interface IGroupRepository
    {

        Task<IEnumerable<Group>> Search(string name);
        Task<IEnumerable<Group>> GetGroups();
        Task<Group> GetGroup(int id);
        Task<Group> AddGroup(Group group);
        Task<Group> UpdateGroup(Group group);
        Task DeleteGroup(int id);
    }
}
