using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMGym.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembershipSubscriptions_MembershipPlans_MembershipPlanPlanId",
                table: "MembershipSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_MembershipSubscriptions_MembershipPlanPlanId",
                table: "MembershipSubscriptions");

            migrationBuilder.DropColumn(
                name: "MembershipPlanPlanId",
                table: "MembershipSubscriptions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembershipSubscriptions_PlanId",
                table: "MembershipSubscriptions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_UserId",
                table: "Members",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MembershipSubscriptions_MembershipPlans_PlanId",
                table: "MembershipSubscriptions",
                column: "PlanId",
                principalTable: "MembershipPlans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Users_UserId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_MembershipSubscriptions_MembershipPlans_PlanId",
                table: "MembershipSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_MembershipSubscriptions_PlanId",
                table: "MembershipSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Members_UserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "MembershipPlanPlanId",
                table: "MembershipSubscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembershipSubscriptions_MembershipPlanPlanId",
                table: "MembershipSubscriptions",
                column: "MembershipPlanPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_MembershipSubscriptions_MembershipPlans_MembershipPlanPlanId",
                table: "MembershipSubscriptions",
                column: "MembershipPlanPlanId",
                principalTable: "MembershipPlans",
                principalColumn: "PlanId");
        }
    }
}
