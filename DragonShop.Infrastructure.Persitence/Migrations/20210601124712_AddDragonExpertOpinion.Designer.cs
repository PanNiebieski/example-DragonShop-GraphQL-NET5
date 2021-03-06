// <auto-generated />
using System;
using DragonShop.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DragonShop.Infrastructure.Persitence.Migrations
{
    [DbContext(typeof(DragonShopDbContext))]
    [Migration("20210601124712_AddDragonExpertOpinion")]
    partial class AddDragonExpertOpinion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("DragonShop.Domain.Dragon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Breath")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Color")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CrewCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("DiameterMeters")
                        .HasColumnType("REAL");

                    b.Property<bool>("DoneFirstFlight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DryMassKg")
                        .HasColumnType("INTEGER");

                    b.Property<double>("HeightInMeters")
                        .HasColumnType("REAL");

                    b.Property<DateTimeOffset>("IntroducedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrbitDurationYears")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Dragons");
                });

            modelBuilder.Entity("DragonShop.Domain.DragonExpertOpinion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DragonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Review")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DragonId");

                    b.ToTable("DragonExpertOpinion");
                });

            modelBuilder.Entity("DragonShop.Domain.DragonExpertOpinion", b =>
                {
                    b.HasOne("DragonShop.Domain.Dragon", "Dragon")
                        .WithMany()
                        .HasForeignKey("DragonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dragon");
                });
#pragma warning restore 612, 618
        }
    }
}
