﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static kixBG.Infrastructure.Data.Entities.AdminUser;

namespace kixBG.Infrastructure.Data.SeedDB
{
    internal class AdminUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        private bool seed;
        public IdentityUser AdminUser { get; set; }

        public AdminUserConfiguration(bool _seed)
        {
            seed = _seed;
        }

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            if (seed)
            {
                var hasher = new PasswordHasher<IdentityUser>();

                AdminUser = new IdentityUser()
                {
                    Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                    Email = AdminEmail,
                    NormalizedEmail = AdminEmail.ToUpper(),
                    UserName = AdminEmail,
                    NormalizedUserName = AdminEmail.ToUpper()
                };
                AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");

                builder.HasData(AdminUser);
            }
        }
    }
}
