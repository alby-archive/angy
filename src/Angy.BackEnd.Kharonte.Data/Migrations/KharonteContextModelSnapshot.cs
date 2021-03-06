// <auto-generated />
using System;
using Angy.BackEnd.Kharonte.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Angy.BackEnd.Kharonte.Data.Migrations
{
    [DbContext(typeof(KharonteContext))]
    partial class KharonteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("Angy.BackEnd.Kharonte.Data.Model.PendingPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Inserted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PendingPhotos");
                });
#pragma warning restore 612, 618
        }
    }
}
