namespace WereldbouwerAPI.Repositories
{
    public class Repository
    {
        private string sqlConnectionString;
        public Repository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }
    }
}
