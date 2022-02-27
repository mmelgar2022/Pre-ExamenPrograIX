using System.Text;

namespace DemoDapperAPI.DML
{
    public class DMLGenerator
    {
        public static string CreateInsertStatement(object Entity, bool skipPrimaryKey = false)
        {
            var insertStatement = "";
            var sbProperties = new StringBuilder();
            var entityName = Entity.GetType().Name;
            var sbColumns = new StringBuilder();
            sbColumns.Append("INSERT INTO " + entityName + " (");
            sbProperties.Append(" VALUES (");
            var coulumnId = 0;
            foreach (var propertInfo in Entity.GetType().GetProperties())
            {
                if (coulumnId != 0)
                {
                    sbColumns.Append(propertInfo.Name + ",");
                    sbProperties.Append("@"+ propertInfo.Name + ",");
                }
                coulumnId++;
            }
            insertStatement = sbColumns.ToString().Substring(0, coulumnId.ToString().Length - 1) + ")" + 
                sbProperties.ToString().Substring(0, sbProperties.ToString().Length - 1) + ")";
            return insertStatement;
        }
        public static string CreateUpdateStatement(object Entity, bool skipPrimaryKey = false)
        {
            var insertStatement = "";
            var sbProperties = new StringBuilder();
            var entityName = Entity.GetType().Name;
            var sbColumns = new StringBuilder();
            sbColumns.Append("UPDATE " + entityName + "SET (");
            sbProperties.Append(" VALUES (");
            var coulumnId = 0;
            foreach (var propertInfo in Entity.GetType().GetProperties())
            {
                if (coulumnId != 0)
                {
                    sbColumns.Append(propertInfo.Name + ",");
                    sbProperties.Append("@"+ propertInfo.Name + ",");
                }
                coulumnId++;
            }
            insertStatement = sbColumns.ToString().Substring(0, coulumnId.ToString().Length - 1) + ") WHERE id= @id" + 
                sbProperties.ToString().Substring(0, sbProperties.ToString().Length - 1) + ")";
            return insertStatement;
        }

    }
}
