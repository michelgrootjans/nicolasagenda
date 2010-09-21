using System.Data;
using Migrator.Framework;

namespace Agendas.Migrations
{
    [Migration(002)]
    public class M002_LesUur : Migration
    {
        private const string tableName = "LesUur";

        public override void Up()
        {
            Database.AddTable(tableName,
                              new Column("Id", DbType.Int64, ColumnProperty.PrimaryKeyWithIdentity),
                              new Column("Dag_Id", DbType.Int32, ColumnProperty.ForeignKey),
                              new Column("Uur", DbType.Int32, ColumnProperty.None),
                              new Column("Naam", DbType.String, ColumnProperty.None),
                              new Column("Inhoud", DbType.String, ColumnProperty.None)
                );
        }

        public override void Down()
        {
            Database.RemoveTable(tableName);
        }
    }
}