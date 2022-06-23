using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_kolos_2_v2.Models;
using apbd_kolos_2_v2.Data;

namespace apbd_kolos_2_v2.Services
{
    public interface IMemberService
    {
        public Task<Member> GetMember(int memberId);
        public Task<bool> MemberExists(int memberId);
    }
}