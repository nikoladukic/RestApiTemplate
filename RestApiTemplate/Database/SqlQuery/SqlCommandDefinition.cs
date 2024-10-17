namespace RestApiTemplate.Database.SqlQuery
{
    public class SqlCommandDefinition
    {
        public string CommandText { get; set; }
        public int CommandType { get; set; }
        public int CommandTimeout { get; set; }
        public List<SqlParameterDefinition> Parameters { get; set; }
    }
}
