using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_kolos_2_v2.Models;

namespace apbd_kolos_2_v2.Services
{
    public interface IOrganizationService
    {
        public Task<Organization> GetOrganization(int orgId);
        public Task<bool> MemberPartOfOrg(int orgId, int memberId);
    }
}