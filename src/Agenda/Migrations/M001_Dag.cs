using System.Data;
using Migrator.Framework;

namespace Agendas.Migrations
{
    [Migration(001)]
    public class M001_Dag : Migration
    {
        private const string tableName = "Dag";

        public override void Up()
        {
            Database.AddTable(
                tableName,
                new Column("Id", DbType.Int64, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Date", DbType.DateTime, ColumnProperty.NotNull | ColumnProperty.Unique)
                );
        }

        public override void Down()
        {
            Database.RemoveTable(tableName);
        }
    }
}