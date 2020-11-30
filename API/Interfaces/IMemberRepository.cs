using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;


namespace API.Interfaces
{
    public interface IMemberRepository 
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetById(int Id);
        Task<Member> Insert(Member member);
        Task<Member> Delete(int Id);
        Task<Member> Update(Member member);
        

        
    }
}
