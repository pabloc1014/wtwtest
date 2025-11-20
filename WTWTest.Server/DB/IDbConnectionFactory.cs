using System.Data;

namespace WTWTest.Server.DB
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
