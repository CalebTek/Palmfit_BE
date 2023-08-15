using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmfit.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFileUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Healths_Users_AppUserId",
                table: "Healths");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Users_AppUserId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_AppUserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_AppUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Users_AppUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_AppUserId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_AppUserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Users_AppUserId",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUser");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Wallets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppUserPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referrals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReferralCode = table.Column<string>(type: "text", nullable: false),
                    InvitedUserid = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referrals_AppUser_InvitedUserid",
                        column: x => x.InvitedUserid,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_InvitedUserid",
                table: "Referrals",
                column: "InvitedUserid");

            migrationBuilder.AddForeignKey(
                name: "FK_Healths_AppUser_AppUserId",
                table: "Healths",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_AppUser_AppUserId",
                table: "Invites",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AppUser_AppUserId",
                table: "Notifications",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AppUser_AppUserId",
                table: "Reviews",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_AppUser_AppUserId",
                table: "Settings",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AppUser_AppUserId",
                table: "Subscriptions",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AppUser_AppUserId",
                table: "Transactions",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_AppUser_AppUserId",
                table: "Wallets",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Healths_AppUser_AppUserId",
                table: "Healths");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_AppUser_AppUserId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AppUser_AppUserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AppUser_AppUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_AppUser_AppUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AppUser_AppUserId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AppUser_AppUserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_AppUser_AppUserId",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "AppUserPermissions");

            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.DropTable(
                name: "Referrals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Wallets");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Healths_Users_AppUserId",
                table: "Healths",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Users_AppUserId",
                table: "Invites",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_AppUserId",
                table: "Notifications",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_AppUserId",
                table: "Reviews",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_AppUserId",
                table: "Settings",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_AppUserId",
                table: "Subscriptions",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_AppUserId",
                table: "Transactions",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Users_AppUserId",
                table: "Wallets",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
