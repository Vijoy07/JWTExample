﻿// <auto-generated />
using System;
using JWTExample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JWTExample.Migrations
{
    [DbContext(typeof(AuthDBContext))]
    [Migration("20210127104451_test1")]
    partial class test1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("JWTExample.Models.Details", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MOTHER_UUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TODO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UUID");

                    b.ToTable("todo");
                });

            modelBuilder.Entity("JWTExample.UserCredentials", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UUID");

                    b.ToTable("credentials");
                });
#pragma warning restore 612, 618
        }
    }
}