using FluentMigrator;
namespace RentAPI.Migrations
{
    [Migration(0)]
    public class M0_initAccounTable : Migration
    {
        public override void Up()
        {
            Create.Table("accounts")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("password").AsString(255).NotNullable().WithDefaultValue("")
                .WithColumn("ballance").AsInt64().NotNullable().WithDefaultValue(0)
                .WithColumn("role").AsString(255).NotNullable().WithDefaultValue("client")
                .WithColumn("refresh_token").AsString(255).NotNullable().WithDefaultValue("");
        }
        public override void Down()
        {
            Delete.Table("accounts");
        }
    }
}
