using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_kolos_2_v2.Data;

namespace apbd_kolos_2_v2.Services
{
    public class MemberService : IMemberService
    {
        private readonly DatabaseContext _context;
        public MemberService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> MemberExists(int memberId)
        {
            return await _context.Members.FindAsync(memberId) != null;
        }

        public async Task<Models.Member> GetMember(int memberId)
        {
            var member = await _context.Members.FindAsync(memberId);
            if (member == null)
            {
                throw new Exception("Member not found"); // fallback protection against null ref
            }
            return member;
        }
    }
}