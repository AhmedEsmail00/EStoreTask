using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreTask.Migrations
{
    public partial class AssignAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into [security].[UserRoles] (UserId,RoleId) Select 'da8567b1-ac43-4452-aa1a-d9daa37b848c',Id from [security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [security].[UserRoles] where UserId='da8567b1-ac43-4452-aa1a-d9daa37b848c'");
        }
    }
}
