using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMGym.Migrations
{
    /// <inheritdoc />
    public partial class AddMembershipSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembershipSubscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    MembershipPlanPlanId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipSubscriptions", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_MembershipSubscriptions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembershipSubscriptions_MembershipPlans_MembershipPlanPlanId",
                        column: x => x.MembershipPlanPlanId,
                        principalTable: "MembershipPlans",
                        principalColumn: "PlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembershipSubscriptions_MemberId",
                table: "MembershipSubscriptions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipSubscriptions_MembershipPlanPlanId",
                table: "MembershipSubscriptions",
                column: "MembershipPlanPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembershipSubscriptions");
        }
    }
}
