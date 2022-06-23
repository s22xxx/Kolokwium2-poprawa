using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_kolos_2_v2.Data;
using apbd_kolos_2_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolos_2_v2.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly DatabaseContext _context;

        public OrganizationService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Organization> GetOrganization(int orgId)
        {
            var org = await _context.Organizations.Include(o => o.Members).Include(o => o.Teams).FirstOrDefaultAsync(o => o.OrganizationId == orgId);

            if (org == null)
            {
                throw new Exception("Organization not found"); // fallback protection against null ref
            }

            return org;
        }

        public async Task<bool> MemberPartOfOrg(int orgId, int memberId)
        {
            var org = await GetOrganization(orgId);
            var member = await _context.Members.FindAsync(memberId); // how to use member service here?

            if (member == null)
            {
                throw new Exception("Member not found"); // fallback protection against null ref
            }

            return org.Members.Any(m => m.MemberId == memberId);
        }
    }
}