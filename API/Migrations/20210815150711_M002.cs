using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class M002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTweet");

            migrationBuilder.AddColumn<Guid>(
                name: "TweetId",
                table: "tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tags_TweetId",
                table: "tags",
                column: "TweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_tags_tweets_TweetId",
                table: "tags",
                column: "TweetId",
                principalTable: "tweets",
                principalColumn: "TweetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tags_tweets_TweetId",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "IX_tags_TweetId",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "TweetId",
                table: "tags");

            migrationBuilder.CreateTable(
                name: "TagTweet",
                columns: table => new
                {
                    TagsTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TweetsTweetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTweet", x => new { x.TagsTagId, x.TweetsTweetId });
                    table.ForeignKey(
                        name: "FK_TagTweet_tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTweet_tweets_TweetsTweetId",
                        column: x => x.TweetsTweetId,
                        principalTable: "tweets",
                        principalColumn: "TweetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTweet_TweetsTweetId",
                table: "TagTweet",
                column: "TweetsTweetId");
        }
    }
}
