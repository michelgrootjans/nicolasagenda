using System.Data;
using Migrator.Framework;

namespace Agendas.Migrations
{
    [Migration(004)]
    public class M004_Taak : Migration
    {
        private Column newColumn;

        public M004_Taak()
        {
            newColumn = new Column("IsAf", DbType.Boolean, false);
        }

        private const string tableName = M003_Taak.TableName;

        public override void Up()
        {
            Database.AddColumn(tableName, newColumn);
        }

        public override void Down()
        {
            Database.RemoveColumn(tableName, newColumn.Name);
        }
    }
}