﻿// <auto-generated />
using System;
using DaihoWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core_APIOracle.Migrations
{
    [DbContext(typeof(OraDbContext))]
    partial class OraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core_APIOracle.Models.custItemCd", b =>
                {
                    b.Property<string>("ITM_CD")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CST_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("CST_ITM_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("CST_ITM_NM")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ITM_CD");

                    b.ToTable("custItemCds");
                });

            modelBuilder.Entity("Core_APIOracle.Models.MANUFACTURE_PRINT_LABEL", b =>
                {
                    b.Property<string>("PRINT_ID_H")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ITM_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("LOT")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PALLETE_ID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("PRINT_DT")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("PRINT_FLG")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PRINT_LOC")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TOUNYU_ID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PRINT_ID_H");

                    b.ToTable("MANUFACTURE_PRINT_LABEL");
                });

            modelBuilder.Entity("Core_APIOracle.Models.ProductsInfo", b =>
                {
                    b.Property<string>("ITM_CD")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CO_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ITM_NM")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PROD_ITM_GRP_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UNIT_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ITM_CD");

                    b.ToTable("CM_HINMO_ALL");
                });

            modelBuilder.Entity("DaihoWebAPI.Models.HM_TOKUIH_ALL", b =>
                {
                    b.Property<string>("ITM_CD")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CO_CD")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CST_CD")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CST_ITM_CD")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("CST_ITM_NM")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("INS_TS")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("INS_USR_CD")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("INVALID_FLG")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UPD_CNTR")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("UPD_TS")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("UPD_USR_CD")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ITM_CD", "CO_CD", "CST_CD");

                    b.ToTable("HM_TOKUIH_ALL");
                });

            modelBuilder.Entity("DaihoWebAPI.Models.PrintLabel", b =>
                {
                    b.Property<string>("CO_CD")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("BR_NO")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ORD_NO")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ITM_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ITM_NM")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ORD_TYP")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PROD_LOC_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("PROD_ST_SCHD_DT")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("CO_CD", "BR_NO", "ORD_NO");

                    b.ToTable("ST_ORDER_ALL");
                });

            modelBuilder.Entity("DaihoWebAPI.Models.StTounyuAll", b =>
                {
                    b.Property<string>("CO_CD")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("INPT_NO")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("C_ITM_CD")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("INST_NO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("CO_CD", "INPT_NO");

                    b.ToTable("ST_TOUNYU_ALL");
                });

            modelBuilder.Entity("DaihoWebAPI.Models.WmUser", b =>
                {
                    b.Property<string>("USR_ID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CO_CD")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("INVALIDATE_FLG")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<byte[]>("PASSWORD")
                        .IsRequired()
                        .HasColumnType("RAW(2000)");

                    b.HasKey("USR_ID");

                    b.ToTable("WM_USER");
                });
#pragma warning restore 612, 618
        }
    }
}
