﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyExchangerApp.Domain.Contexts;

namespace MoneyExchangerApp.Repositories.Migrations
{
    [DbContext(typeof(CurrencyExchangerDbContext))]
    partial class CurrencyExchangerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MoneyExchangerApp.Domain.Entities.ExchangeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("FromAmount")
                        .HasColumnType("float");

                    b.Property<string>("FromCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ToAmount")
                        .HasColumnType("float");

                    b.Property<string>("ToCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExchangeEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
