using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.Data.Migrations
{
    public partial class ImageRowAddedToStaffTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocialMedia3",
                table: "Staff",
                newName: "TwitterLink");

            migrationBuilder.RenameColumn(
                name: "SocialMedia2",
                table: "Staff",
                newName: "StaffImage");

            migrationBuilder.RenameColumn(
                name: "SocialMedia1",
                table: "Staff",
                newName: "InstagramLink");

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "TwitterLink",
                table: "Staff",
                newName: "SocialMedia3");

            migrationBuilder.RenameColumn(
                name: "StaffImage",
                table: "Staff",
                newName: "SocialMedia2");

            migrationBuilder.RenameColumn(
                name: "InstagramLink",
                table: "Staff",
                newName: "SocialMedia1");
        }
    }
}
