using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[Roles] (Name) VALUES ('Administrator'),('User')
                INSERT INTO [dbo].[Users] (Username, Password, RoleId) VALUES ('alice', 'alice', 1), ('bob', 'bob', 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                TRUNCATE TABLE [dbo].[Users]
                TRUNCATE TABLE [dbo].[Roles]");
        }
    }
}
