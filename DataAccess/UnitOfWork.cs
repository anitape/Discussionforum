using DataAccess.Data;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;  //dependency injection of Data Source

		public UnitOfWork(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		private IGenericRepository<Topic> _Topic;
		private IGenericRepository<ForumUser> _ForumUser;
		private IGenericRepository<Reply> _Reply;

		public IGenericRepository<Topic> Topic
		{
			get
			{

				if (_Topic == null)
				{
					_Topic = new GenericRepository<Topic>(_dbContext);
				}

				return _Topic;
			}

		}

		public IGenericRepository<ForumUser> ForumUser
		{
			get
			{

				if (_ForumUser == null)
				{
					_ForumUser = new GenericRepository<ForumUser>(_dbContext);
				}

				return _ForumUser;
			}
		}

		public IGenericRepository<Reply> Reply
		{
			get
			{

				if (_Reply == null)
				{
					_Reply = new GenericRepository<Reply>(_dbContext);
				}

				return _Reply;
			}
		}

		IGenericRepository<Topic> IUnitOfWork.Topic => throw new NotImplementedException();
		IGenericRepository<ForumUser> IUnitOfWork.ForumUser => throw new NotImplementedException();
		IGenericRepository<Reply> IUnitOfWork.Reply => throw new NotImplementedException();

		//ADD ADDITIONAL METHODS FOR EACH MODEL (similar to Category) HERE

		public int Commit()
		{
			return _dbContext.SaveChanges();
		}

		public async Task<int> CommitAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}

		//additional method added for garbage disposal

		public void Dispose()
		{
			_dbContext.Dispose();
		}

		int IUnitOfWork.Commit()
		{
			throw new NotImplementedException();
		}

		Task<int> IUnitOfWork.CommitAsync()
		{
			throw new NotImplementedException();
		}


	}
}