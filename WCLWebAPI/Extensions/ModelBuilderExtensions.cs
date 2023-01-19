using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WCLWebAPI.Server.EF;
using WCLWebAPI.Server.Entities;

namespace WCLWebAPI.Server.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //init AppRole
            var roleId = new Guid("0269FD5C-205D-40E2-8387-50F1852A9632");
            var adminId = new Guid("7706184C-CA4B-4E27-A1ED-09512DDBAA51");
            var editor_roleid = new Guid();
            var editor_role_editor_id = new Guid();
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description = "Administrator",
                    ConcurrencyStamp = new Guid().ToString()
                },
                new AppRole
                {
                    Id = editor_roleid,
                    Name = "Editor",
                    NormalizedName = "EDITOR",
                    Description = "Editor",
                    ConcurrencyStamp = new Guid().ToString()
                }
            );

            //init AppUser
            var hash = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                    new AppUser
                    {
                        Id = adminId,
                        UserName = "nhkphat",
                        NormalizedUserName = "NHKPHAT",
                        Email = "nhkphat@gmail.com",
                        NormalizedEmail = "NHKPHAT@GMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash = hash.HashPassword(null, "Nhkph@t123"),
                        PhoneNumber = "0972532751",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        FirstName = "Phat",
                        LastName = "Nguyen",
                        Dob = new DateTime(1994, 05, 10)

                    },
                    new AppUser
                    {
                        Id = editor_role_editor_id,
                        UserName = "vinhnx",
                        NormalizedUserName = "VINHNX",
                        Email = "vinhnx@gmail.com",
                        NormalizedEmail = "VINHNX@GMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash = hash.HashPassword(null, "Vinhnx@t123"),
                        PhoneNumber = "0935532758",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        FirstName = "Vinh",
                        LastName = "Nguyen",
                        Dob = new DateTime(1990, 02, 15)

                    }
                );

            //init UserRole
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                    new IdentityUserRole<Guid>
                    {
                        RoleId = roleId,
                        UserId = adminId
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = editor_roleid,
                        UserId = editor_role_editor_id
                    }
                );

            //init Department
            modelBuilder.Entity<Department>().HasData(
                    new Department
                    {
                        ID = 1,
                        Name = "IT / IT Dev",
                        EmployeeID = 0,
                        DateCreated = new DateTime(),
                        DateModified = new DateTime()
                    },
                    new Department
                    {
                        ID = 2,
                        Name = "Import",
                        EmployeeID = 0,
                        DateCreated = new DateTime(),
                        DateModified = new DateTime()
                    },
                    new Department
                    {
                        ID = 3,
                        Name = "HR",
                        EmployeeID = 0,
                        DateCreated = new DateTime(),
                        DateModified = new DateTime()
                    },
                    new Department
                    {
                        ID = 4,
                        Name = "Accounting",
                        EmployeeID = 0,
                        DateCreated = new DateTime(),
                        DateModified = new DateTime()
                    },
                    new Department
                    {
                        ID = 5,
                        Name = "Inventory",
                        EmployeeID = 0,
                        DateCreated = new DateTime(),
                        DateModified = new DateTime()
                    }
                );


            //init Employee
            modelBuilder.Entity<Employee>().HasData(
                     new Employee
                     {
                         ID = 1,
                         Name = "Nguyen Xuan Vinh",
                         Email = "vinhnx@gmail.com",
                         Gender = Enums.Gender.Male,
                         DepartmentID = 1
                     },
                     new Employee
                     {
                         ID = 2,
                         Name = "Nguyen Huu Khanh Phat",
                         Email = "nhkphat@gmail.com",
                         Gender = Enums.Gender.Male,
                         DepartmentID = 1
                     },
                     new Employee
                     {
                         ID = 3,
                         Name = "Anni",
                         Email = "anni@gmail.com",
                         Gender = Enums.Gender.Female,
                         DepartmentID = 2
                     },
                     new Employee
                     {
                         ID = 4,
                         Name = "Alice",
                         Email = "alice@gmail.com",
                         Gender = Enums.Gender.Female,
                         DepartmentID = 3
                     }

                 );

        }
    }
}
