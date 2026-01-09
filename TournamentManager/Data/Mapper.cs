using System.Data;

namespace TournamentManager.Data
{
    public static class Mapper
    {
        public static Task<List<T>> MapAsync<T>(DataTable dataTable) where T : class
        {
            return Task.Run(() =>
            {
                var columnNames = dataTable.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();

                var properties = typeof(T).GetProperties();

                return dataTable.AsEnumerable().Select(row =>
                {
                    var objT = Activator.CreateInstance<T>();

                    // PropertyInfo in PropertyInfo[]
                    foreach (var pro in properties) 
                    {
                        if (columnNames.Contains(pro.Name))
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                    }

                    return objT;
                }).ToList();
            });
        }
    }
}
