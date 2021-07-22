using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Data
{
    public class GroupRepository : IGroupRepository
    {
        readonly AppDbContext _db;
        public GroupRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Group> AddGroup(Group group)
        {
            var result= await _db.Groups.AddAsync(group);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteGroup(int id)
        {
            var result = await _db.Groups.FirstOrDefaultAsync(g => g.GroupID == id);
            if(result!=null)
            {
                _db.Groups.Remove(result);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Group> GetGroup(int id)
        {
            return await _db.Groups.FirstOrDefaultAsync(g => g.GroupID == id);
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await _db.Groups.ToListAsync();
        }

        public async Task<IEnumerable<Group>> Search(string name)
        {
            IQueryable<Group> q = _db.Groups;

            if(!string.IsNullOrEmpty(name))
            {
                q = q.Where(g => g.Name.Contains(name));
            }

            return await q.ToListAsync();
        }

        public async Task<Group> UpdateGroup(Group group)
        {
            var result = await _db.Groups.FirstOrDefaultAsync(g => g.GroupID == group.GroupID);
            if (result != null)
            {
                result.Name = group.Name;


                _db.Groups.Update(result);
                await _db.SaveChangesAsync();
            }

            return result;
        }
    }
}
