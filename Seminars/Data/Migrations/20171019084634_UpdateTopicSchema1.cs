using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Seminars.Data.Migrations
{
    public partial class UpdateTopicSchema1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessTrainingTopic_Topics_NameId",
                table: "BusinessTrainingTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_KeynoteTopic_Topics_NameId",
                table: "KeynoteTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialization_Topics_NameId",
                table: "Specialization");

            migrationBuilder.DropIndex(
                name: "IX_Specialization_NameId",
                table: "Specialization");

            migrationBuilder.DropIndex(
                name: "IX_KeynoteTopic_NameId",
                table: "KeynoteTopic");

            migrationBuilder.DropIndex(
                name: "IX_BusinessTrainingTopic_NameId",
                table: "BusinessTrainingTopic");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "Specialization");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "KeynoteTopic");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "BusinessTrainingTopic");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Specialization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeakerId",
                table: "Specialization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "Specialization",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "KeynoteTopic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeakerId",
                table: "KeynoteTopic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "KeynoteTopic",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BusinessTrainingTopic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeakerId",
                table: "BusinessTrainingTopic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "BusinessTrainingTopic",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Specialization");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "Specialization");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Specialization");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "KeynoteTopic");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "KeynoteTopic");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "KeynoteTopic");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BusinessTrainingTopic");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "BusinessTrainingTopic");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "BusinessTrainingTopic");

            migrationBuilder.AddColumn<Guid>(
                name: "NameId",
                table: "Specialization",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NameId",
                table: "KeynoteTopic",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NameId",
                table: "BusinessTrainingTopic",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_NameId",
                table: "Specialization",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_KeynoteTopic_NameId",
                table: "KeynoteTopic",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTrainingTopic_NameId",
                table: "BusinessTrainingTopic",
                column: "NameId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessTrainingTopic_Topics_NameId",
                table: "BusinessTrainingTopic",
                column: "NameId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KeynoteTopic_Topics_NameId",
                table: "KeynoteTopic",
                column: "NameId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialization_Topics_NameId",
                table: "Specialization",
                column: "NameId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
