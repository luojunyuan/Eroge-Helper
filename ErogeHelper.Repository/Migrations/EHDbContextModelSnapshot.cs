﻿// <auto-generated />
using System;
using ErogeHelper.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ErogeHelper.Repository.Migrations
{
    [DbContext(typeof(EHDbContext))]
    partial class EHDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("ErogeHelper.Repository.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Md5")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("TextSettingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TextSettingId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ErogeHelper.Repository.Models.GameName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameName");
                });

            modelBuilder.Entity("ErogeHelper.Repository.Models.Subtitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreationSubtitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DownVote")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("RevisionSubtitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RevisionTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UpVote")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("GameId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ErogeHelper.Repository.Models.TextSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HookCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegExp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("SubThreadContext")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ThreadContext")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UserHook")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TextSetting");
                });

            modelBuilder.Entity("ErogeHelper.Repository.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AccessTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExtraInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomePage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ErogeHelper.Repository.Models.Game", b =>
                {
                    b.HasOne("ErogeHelper.Repository.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErogeHelper.Repository.Models.TextSetting", "TextSetting")
                        .WithMany()
                        .HasForeignKey("TextSettingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("TextSetting");
                });

            modelBuilder.Entity("ErogeHelper.Repository.Models.GameName", b =>
                {
                    b.HasOne("ErogeHelper.Repository.Models.Game", null)
                        .WithMany("Names")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ErogeHelper.Repository.Models.Subtitle", b =>
                {
                    b.HasOne("ErogeHelper.Repository.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErogeHelper.Repository.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ErogeHelper.Repository.Models.Context", "Context", b1 =>
                        {
                            b1.Property<int>("SubtitleId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<long>("Hash")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Size")
                                .HasColumnType("INTEGER");

                            b1.HasKey("SubtitleId");

                            b1.ToTable("Comments");

                            b1.WithOwner()
                                .HasForeignKey("SubtitleId");
                        });

                    b.Navigation("Context")
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("ErogeHelper.Repository.Models.Game", b =>
                {
                    b.Navigation("Names");
                });
#pragma warning restore 612, 618
        }
    }
}