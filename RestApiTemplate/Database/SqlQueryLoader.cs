using RestApiTemplate.Database.SqlQuery;
using System.Text.Json;

namespace RestApiTemplate.Database
{
    public class SqlQueryLoader
    {
        private readonly string _filePath;

        public SqlQueryLoader(string filePath)
        {
            _filePath = filePath;
        }

        public SqlDefinition LoadSqlDefinition()
        {
            var jsonString = File.ReadAllText(_filePath);
            try
            {
                var sqlDefinitionsa = JsonSerializer.Deserialize<SqlDefinition>(jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Deserializacija nije uspela: {ex.Message}");
            }
            var sqlDefinitions = JsonSerializer.Deserialize<SqlDefinition>(jsonString);
            return sqlDefinitions;
        }
    }
}
