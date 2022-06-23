﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apbd_kolos_2_v2.Data;

#nullable disable

namespace apbd_kolos_2_v2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220621092237_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("apbd_kolos_2_v2.Models.File", b =>
                {
                    b.Property<int>("FileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileExtension")
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("FileSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("FileId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            FileId = 1,
                            TeamId = 1,
                            FileExtension = "pdf",
                            FileName = "File 1",
                            FileSize = 0
                        },
                        new
                        {
                            FileId = 2,
                            TeamId = 2,
                            FileExtension = "zip",
                            FileName = "File 2",
                            FileSize = 0
                        },
                        new
                        {
                            FileId = 3,
                            TeamId = 3,
                            FileExtension = "docx",
                            FileName = "File 3",
                            FileSize = 0
                        });
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MemberName")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("MemberNickName")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("MemberSurname")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MemberId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            MemberName = "Member 1",
                            MemberNickName = "Nick Name 1",
                            MemberSurname = "Last Name 1",
                            OrganizationId = 1
                        },
                        new
                        {
                            MemberId = 2,
                            MemberName = "Member 2",
                            MemberNickName = "Nick Name 2",
                            MemberSurname = "Last Name 2",
                            OrganizationId = 2
                        },
                        new
                        {
                            MemberId = 3,
                            MemberName = "Member 3",
                            MemberSurname = "Last Name 3",
                            OrganizationId = 3
                        });
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.Membership", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("MembershipSince")
                        .HasColumnType("TEXT");

                    b.HasKey("MemberId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Memberships");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            TeamId = 1,
                            MembershipSince = new DateTime(2022, 6, 20, 11, 22, 36, 674, DateTimeKind.Local).AddTicks(2470)
                        },
                        new
                        {
                            MemberId = 2,
                            TeamId = 1,
                            MembershipSince = new DateTime(2022, 6, 19, 11, 22, 36, 674, DateTimeKind.Local).AddTicks(2540)
                        },
                        new
                        {
                            MemberId = 3,
                            TeamId = 2,
                            MembershipSince = new DateTime(2022, 6, 18, 11, 22, 36, 674, DateTimeKind.Local).AddTicks(2550)
                        });
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrganizationDomain")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizationName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            OrganizationId = 1,
                            OrganizationName = "Organization 1"
                        },
                        new
                        {
                            OrganizationId = 2,
                            OrganizationName = "Organization 2"
                        },
                        new
                        {
                            OrganizationId = 3,
                            OrganizationName = "Organization 3"
                        });
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamDescription")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            OrganizationId = 1,
                            TeamDescription = "Team 1 description",
                            TeamName = "Team 1"
                        },
                        new
                        {
                            TeamId = 2,
                            OrganizationId = 1,
                            TeamDescription = "Team 2 description",
                            TeamName = "Team 2"
                        },
                        new
                        {
                            TeamId = 3,
                            OrganizationId = 2,
                            TeamDescription = "Team 3 description",
                            TeamName = "Team 3"
                        });
                });

            modelBuilder.Entity("MemberTeam", b =>
                {
                    b.Property<int>("MembersMemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MembersMemberId", "TeamsTeamId");

                    b.HasIndex("TeamsTeamId");

                    b.ToTable("MemberTeam");
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.File", b =>
                {
                    b.HasOne("apbd_kolos_2_v2.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.Member", b =>
                {
                    b.HasOne("apbd_kolos_2_v2.Models.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.Membership", b =>
                {
                    b.HasOne("apbd_kolos_2_v2.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apbd_kolos_2_v2.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.Team", b =>
                {
                    b.HasOne("apbd_kolos_2_v2.Models.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("MemberTeam", b =>
                {
                    b.HasOne("apbd_kolos_2_v2.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apbd_kolos_2_v2.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apbd_kolos_2_v2.Models.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
