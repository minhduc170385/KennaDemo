using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {        
        private IMemberRepository _memberRepository;
        public MembersController(IMemberRepository memberRepository)
        {
            this._memberRepository = memberRepository;
        }
        // GET: api/members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return Ok(await _memberRepository.GetMembers());            
        }
        // GET: api/members/5
        [HttpGet("{id}")]
        [ActionName(nameof(GetUserById))]
        public async Task<ActionResult<Member>> GetUserById(int id)
        {
            return await _memberRepository.GetById(id);
        }
        //Post: api/members
        [HttpPost]
        public async Task<ActionResult<Member>> Insert([FromBody] Member member)
        {
            await _memberRepository.Insert(member);           
            return CreatedAtAction(nameof(GetUserById), new { id = member.Id }, member);            
        }
        
        //Put: api/members/2
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Member member)
        {
            if(id != member.Id)
            {
                return BadRequest();
            }
            await _memberRepository.Update(member);
            return NoContent();
        }

        //Put: api/members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> Delete(int id)
        {
            var mem = await _memberRepository.Delete(id);
            if (mem == null)
            {
                return NotFound();
            }
            return mem;
        }
    }
}
