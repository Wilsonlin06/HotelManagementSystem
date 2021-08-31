﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(HMSDbContext))]
    [Migration("20210830173643_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ADDRESS");

                    b.Property<decimal?>("Advance")
                        .HasColumnType("money")
                        .HasColumnName("ADVANCE");

                    b.Property<int?>("BookingDays")
                        .HasColumnType("int");

                    b.Property<string>("CName")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CNAME");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CHECKIN");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(40)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("PHONE");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("ROOMNO");

                    b.Property<int?>("TotlePERSONS")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("RTCODE");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ApplicationCore.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RTDesc")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("RTDESC");

                    b.Property<decimal?>("Rent")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("money")
                        .HasColumnName("AMOUNT");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("ROOMNO");

                    b.Property<string>("SDesc")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("SDESC");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique()
                        .HasFilter("[ROOMNO] IS NOT NULL");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Customer", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Room", "Rooms")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Room", b =>
                {
                    b.HasOne("ApplicationCore.Entities.RoomType", "RoomTypes")
                        .WithMany()
                        .HasForeignKey("RoomTypeId");

                    b.Navigation("RoomTypes");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Service", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Room", null)
                        .WithOne("Services")
                        .HasForeignKey("ApplicationCore.Entities.Service", "RoomId");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Room", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
