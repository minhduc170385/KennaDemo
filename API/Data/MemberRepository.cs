using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MemberRepository : IMemberRepository // Repositories<Member>,
    {
        private readonly DataContext _context;
        public MemberRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Member> GetById(int Id)
        {
            return await _context.Members.FindAsync(Id);
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }
        public async Task<Member> Insert(Member member)
        {            
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }
        

        public async Task<Member> Delete(int Id)
        {
            Member member = await _context.Members.FindAsync(Id);            
            if(member==null)
            {
                return member;
            }
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return member;
        }        

        

        public async Task<Member> Update(Member member)
        {
            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return member;
        }

        //-----------------------------------------------

        //public async Task<Member> GetMemberByIdAsync(int id)
        //{
        //    return await _context.Members.FindAsync(id);
        //}

        //public async Task<IEnumerable<Member>> GetMembersAsync()
        //{
        //    return await _context.Members.ToListAsync();
        //}

        //public async Task<bool> SaveAllAsync()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public void Update(Member member)
        //{
        //    _context.Entry(member).State = EntityState.Modified;
        //}
    }
}
