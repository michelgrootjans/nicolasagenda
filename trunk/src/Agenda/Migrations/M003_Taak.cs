using System;
using System.Data;
using Migrator.Framework;

namespace Agendas.Migrations
{
    [Migration(003)]
    public class M003_Taak : Migration
    {
        public const string TableName = "Taak";

        public override void Up()
        {
            Database.AddTable(TableName,
                              new Column("Id", DbType.Int64, ColumnProperty.PrimaryKeyWithIdentity),
                              new Column("Dag_Id", DbType.Int32, ColumnProperty.ForeignKey),
                              new Column("Vak", DbType.String, ColumnProperty.None),
                              new Column("Inhoud", DbType.String, ColumnProperty.None)
                );
        }

        public override void Down()
        {
            Database.RemoveTable(TableName);
        }
    }
}