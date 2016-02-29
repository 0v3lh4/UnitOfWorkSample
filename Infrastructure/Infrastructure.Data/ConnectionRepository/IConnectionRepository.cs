namespace Infrastructure.Data.ConnectionRepository
{
	public interface IConnectionRepository
	{
		string GetConnectionString( string repositoryKey = null );
		void Save( string connectionString, string repositoryKey );
	}
}