using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
	public interface IUnitOfWork
	{
		public IGenericRepository<Topic> Topic { get; }
		public IGenericRepository<ForumUser> ForumUser { get; }
		public IGenericRepository<Reply> Reply { get; }

		//ADD other Models/Tables here as you create them

		//save changes to the data source

		int Commit();

		Task<int> CommitAsync();

	}
}