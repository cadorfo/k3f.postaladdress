using Orchard.Data.Migration;
using System;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using K3F.PostalAddress.Models;


namespace K3F.PostalAddress
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("RegionRecord",
                table =>
                    table.Column<int>("Id", c => c.Identity().PrimaryKey())
                    .Column<string>("Name")
                    .Column<int>("Country_Id")
            );

            SchemaBuilder.CreateTable("LocalityRecord",
                table => table.Column<int>("Id", c => c.Identity().PrimaryKey())
                    .Column<string>("Name")
                    .Column<int>("Region_Id"));
            SchemaBuilder.CreateTable("CountryRecord",
                table => table.Column<int>("Id", c => c.Identity().PrimaryKey())
                    .Column<string>("Name"));

            SchemaBuilder.CreateForeignKey(
                "RegionRecord_LocalityRecord_FK",
                "LocalityRecord",
                new String[] { "Region_Id" },
                "RegionRecord",
                new String[] { "Id" });

            SchemaBuilder.CreateForeignKey(
                "CountryRecord_RegionRecord_FK",
                "RegionRecord",
                new String[] { "Country_Id" },
                "CountryRecord",
                new String[] { "Id" });
            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.CreateTable("PostalAddressRecord",
                table => table
                .ContentPartRecord()
                .Column<string>("Name")
                .Column<string>("PostalCode")
                .Column<string>("Street")
                .Column<int>("Locality_Id"));

            SchemaBuilder.CreateForeignKey(
                "PostalAddressRecord_LocalityRecord_FK",
                "PostalAddressRecord",
                new String[] { "Locality_Id" },
                "LocalityRecord",
                new String[] { "Id" });
            ContentDefinitionManager.AlterPartDefinition(
                typeof(PostalAddressPart).Name, cfg => cfg.Attachable());

            return 2;
        }

    }
}

