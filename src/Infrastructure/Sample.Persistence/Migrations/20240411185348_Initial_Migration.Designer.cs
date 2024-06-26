﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sample.Persistence;

#nullable disable

namespace Sample.Persistence.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    [Migration("20240411185348_Initial_Migration")]
    partial class Initial_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sample.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Sample.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Admin1Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Admin2Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CountryId1")
                        .HasColumnType("integer");

                    b.Property<string>("GeonameId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CountryId1");

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CurrencyType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsStateRegistrationFree")
                        .HasColumnType("boolean");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentClientId")
                        .HasColumnType("integer");

                    b.Property<string>("RegisteredNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StateRegistration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ISOCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContinentIsoCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryIsoCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GeonameId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name_enUS")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name_esES")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name_ptBR")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name_ptPT")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContinentIsoCode");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Sample.Domain.Entities.InvoicingAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("InvoicingInfoId")
                        .HasColumnType("integer");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PostlCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("InvoicingInfoId")
                        .IsUnique();

                    b.ToTable("InvoicingAddress");
                });

            modelBuilder.Entity("Sample.Domain.Entities.InvoicingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int>("ClientIdParentLink")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegisteredNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("InvoicingInfo");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character(6)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Sample.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Admin1Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CountryId1")
                        .HasColumnType("integer");

                    b.Property<string>("GeonameId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId1");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Address", b =>
                {
                    b.HasOne("Sample.Domain.Entities.Client", "Client")
                        .WithOne("Address")
                        .HasForeignKey("Sample.Domain.Entities.Address", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Sample.Domain.Entities.City", b =>
                {
                    b.HasOne("Sample.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sample.Domain.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Client", b =>
                {
                    b.HasOne("Sample.Domain.Entities.Client", "ParentClient")
                        .WithMany("ChildrenChain")
                        .HasForeignKey("ParentClientId");

                    b.Navigation("ParentClient");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Contact", b =>
                {
                    b.HasOne("Sample.Domain.Entities.Client", null)
                        .WithMany("Contacts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sample.Domain.Entities.Department", null)
                        .WithMany("Contacts")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sample.Domain.Entities.Country", b =>
                {
                    b.HasOne("Sample.Domain.Entities.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentIsoCode")
                        .HasPrincipalKey("ISOCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("Sample.Domain.Entities.InvoicingAddress", b =>
                {
                    b.HasOne("Sample.Domain.Entities.Client", "Client")
                        .WithOne("InvoicingAddress")
                        .HasForeignKey("Sample.Domain.Entities.InvoicingAddress", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sample.Domain.Entities.InvoicingInfo", "InvoicingInfo")
                        .WithOne("InvoicingAddress")
                        .HasForeignKey("Sample.Domain.Entities.InvoicingAddress", "InvoicingInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("InvoicingInfo");
                });

            modelBuilder.Entity("Sample.Domain.Entities.InvoicingInfo", b =>
                {
                    b.HasOne("Sample.Domain.Entities.Client", "Client")
                        .WithOne("InvoicingInfo")
                        .HasForeignKey("Sample.Domain.Entities.InvoicingInfo", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Sample.Domain.Entities.State", b =>
                {
                    b.HasOne("Sample.Domain.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Client", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("ChildrenChain");

                    b.Navigation("Contacts");

                    b.Navigation("InvoicingAddress")
                        .IsRequired();

                    b.Navigation("InvoicingInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("Sample.Domain.Entities.Continent", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Sample.Domain.Entities.Department", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Sample.Domain.Entities.InvoicingInfo", b =>
                {
                    b.Navigation("InvoicingAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("Sample.Domain.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
