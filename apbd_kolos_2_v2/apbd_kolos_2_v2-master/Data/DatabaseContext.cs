using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_kolos_2_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolos_2_v2.Data
{
    public class DatabaseContext : DbContext
    {
        #nullable disable
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        
        public void DbSeed(ModelBuilder mb)
        {
            mb.Entity<Organization>().HasData(
                new Organization { OrganizationId = 1, OrganizationName = "Organization 1" },
                new Organization { OrganizationId = 2, OrganizationName = "Organization 2" },
                new Organization { OrganizationId = 3, OrganizationName = "Organization 3" }
            );

            mb.Entity<Member>().HasData(
                new Member { MemberId = 1, MemberName = "Member 1", MemberSurname = "Last Name 1", MemberNickName = "Nick Name 1", OrganizationId = 1 },
                new Member { MemberId = 2, MemberName = "Member 2", MemberSurname = "Last Name 2", MemberNickName = "Nick Name 2", OrganizationId = 2 },
                new Member { MemberId = 3, MemberName = "Member 3", MemberSurname = "Last Name 3", MemberNickName = null, OrganizationId = 3 }
            );

            mb.Entity<Team>().HasData(
                new Team { TeamId = 1, TeamName = "Team 1", TeamDescription = "Team 1 description", OrganizationId = 1 },
                new Team { TeamId = 2, TeamName = "Team 2", TeamDescription = "Team 2 description", OrganizationId = 1 },
                new Team { TeamId = 3, TeamName = "Team 3", TeamDescription = "Team 3 description", OrganizationId = 2 }
            );

            mb.Entity<Membership>().HasData(
                new Membership { MemberId = 1, TeamId = 1, MembershipSince = DateTime.Now - TimeSpan.FromDays(1) },
                new Membership { MemberId = 2, TeamId = 1, MembershipSince = DateTime.Now - TimeSpan.FromDays(2) },
                new Membership { MemberId = 3, TeamId = 2, MembershipSince = DateTime.Now - TimeSpan.FromDays(3) }
            );

            mb.Entity<Models.File>().HasData(
                new Models.File { TeamId = 1, FileId = 1, FileName = "File 1", FileExtension = "pdf" },
                new Models.File { TeamId = 2, FileId = 2, FileName = "File 2", FileExtension = "zip" },
                new Models.File { TeamId = 3, FileId = 3, FileName = "File 3", FileExtension = "docx" }
            );
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // set up composite keys
            mb.Entity<Membership>().HasKey(m => new { m.MemberId, m.TeamId });
            mb.Entity<Models.File>().HasKey(f => new { f.FileId, f.TeamId });
            // seed db
            DbSeed(mb);   
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Models.File> Files { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}