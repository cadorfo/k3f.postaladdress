using Orchard.Data.Migration;
using System;


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

    }
}

