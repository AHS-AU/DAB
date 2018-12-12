﻿// <auto-generated />
using System;
using E18I4DABH4Gr4.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E18I4DABH4Gr4.Migrations
{
    [DbContext(typeof(TraderContext))]
    partial class TraderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E18I4DABH4Gr4.Models.Trader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConsumerId");

                    b.Property<string>("KWhTransferred");

                    b.Property<string>("ProducerId");

                    b.Property<DateTime>("TransferDate");

                    b.HasKey("Id");

                    b.ToTable("Traders");
                });
#pragma warning restore 612, 618
        }
    }
}