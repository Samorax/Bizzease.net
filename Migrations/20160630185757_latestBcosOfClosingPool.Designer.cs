using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WebApplication_Webease_.Services.DAL;

namespace webapplicationwebease.Migrations.BPDb
{
    [DbContext(typeof(BPDbContext))]
    [Migration("20160630185757_latestBcosOfClosingPool")]
    partial class latestBcosOfClosingPool
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication_Webease_.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogAuthor")
                        .IsRequired();

                    b.Property<string>("BlogBody")
                        .IsRequired();

                    b.Property<string>("BlogDate");

                    b.Property<string>("BlogSummary")
                        .IsRequired();

                    b.Property<string>("BlogTag")
                        .IsRequired();

                    b.Property<string>("BlogTitle")
                        .IsRequired();

                    b.HasKey("BlogId");
                });

            modelBuilder.Entity("WebApplication_Webease_.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("CommentBody")
                        .IsRequired();

                    b.Property<DateTime>("CommentDate");

                    b.Property<string>("CommenterEmailAddress")
                        .IsRequired();

                    b.Property<string>("CommenterName")
                        .IsRequired();

                    b.HasKey("CommentId");
                });

            modelBuilder.Entity("WebApplication_Webease_.Models.Projects", b =>
                {
                    b.Property<int>("ProjectsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProjectCategory")
                        .IsRequired();

                    b.Property<string>("ProjectDescription")
                        .IsRequired();

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("ProjectPicUrl");

                    b.Property<string>("ProjectSummary")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("ProjectUrl");

                    b.HasKey("ProjectsId");
                });

            modelBuilder.Entity("WebApplication_Webease_.Models.Comment", b =>
                {
                    b.HasOne("WebApplication_Webease_.Models.Blog")
                        .WithMany()
                        .HasForeignKey("BlogId");
                });
        }
    }
}
