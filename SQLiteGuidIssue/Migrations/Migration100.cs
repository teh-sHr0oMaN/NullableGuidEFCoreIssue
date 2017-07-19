using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SQLiteGuidIssue.Model;

namespace SQLiteGuidIssue.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("1.0.0")]
    public class Migration100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Blogs",
                table => new
                {
                    BlogId = table.Column<Guid>(),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table => table.PrimaryKey("PK_Blog", x => x.BlogId));

            migrationBuilder.CreateTable("Posts",
                table => new
                {
                    PostId = table.Column<Guid>(),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    BlogId = table.Column<Guid>(),
                    CopiedFromPostId = table.Column<Guid>(nullable: true),
                },
                constraints:
                table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey("FK_Post_BlogID", x => x.BlogId, "Blogs", "BlogId");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Posts");
            migrationBuilder.DropTable("Blogs");
        }
    }
}
