using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Reply> Replies { get; set; }
		public DbSet<ForumUser> ForumUsers { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<TagAssociate> TagsAssociates { get; set; }
		public DbSet<Topic> Topics { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//    modelBuilder.Entity<User>().HasData(
		//        new User
		//        {
		//            CreatedDate = DateTime.Now,
		//            //Id = "1",
		//            ScreenName = "user1",
		//        },
		//        new User
		//        {
		//            CreatedDate = DateTime.Now,
		//            //Id = "2",
		//            ScreenName = "user2",
		//        },
		//        new User
		//        {
		//            CreatedDate = DateTime.Now,
		//            //Id = "3",
		//            ScreenName = "user3",
		//        }

		//       );


		//    modelBuilder.Entity<Topic>().HasData(
		//        new Topic
		//        {
		//            Description = "Once upon a time....",
		//            TopicId = 1,
		//            Title = "First topic......something intelligent",
		//            AuthorUserId = "1",
		//        },

		//         new Topic
		//         {
		//             Description = "Sometime in future....",
		//             TopicId = 2,
		//             Title = "Second topic......something about future",
		//             AuthorUserId = "2",
		//         },
		//          new Topic
		//          {
		//              Description = "AI will make developers absolete",
		//              TopicId = 3,
		//              Title = "AI will make developers absolete",
		//              AuthorUserId = "3",
		//          },
		//           new Topic
		//           {
		//               Description = "AI will not make developers absolete",
		//               TopicId = 4,
		//               Title = "AI will not make developers absolete",
		//               AuthorUserId = "1",
		//           }

		//        );


		//    modelBuilder.Entity<Reply>().HasData(
		//        new Reply
		//        {
		//            ReplyId = 1,
		//            TopicId = 1,
		//            Content = "blha blha blah.....",
		//            ReplyUserId= "1",
		//            CreatedOn = DateTime.Now,
		//            UpdatedOn = DateTime.Now,
		//        },
		//          new Reply
		//          {
		//              ReplyId = 2,
		//              TopicId = 1,
		//              Content = "blha blha blah...more blah blah..",
		//              ReplyUserId = "3",
		//              CreatedOn = DateTime.Now,
		//              UpdatedOn = DateTime.Now,
		//          }

		//        );

		//    modelBuilder.Entity<Tag>().HasData(
		//        new Tag
		//        {
		//            Id = 1,
		//            Name = "AI",
		//        },

		//         new Tag
		//         {
		//             Id = 2,
		//             Name = "off-topic",
		//         }



		//        );

		//    modelBuilder.Entity<TagAssociate>().HasData(
		//        new TagAssociate
		//        {
		//            TagAssociateId = 1,
		//            TagId = 2,
		//            TopicId = 3
		//        },
		//         new TagAssociate
		//         {
		//             TagAssociateId = 2,
		//             TagId = 1,
		//             TopicId = 1
		//         }

		//        );


		//}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			var superAdminRoleId = "7f0cc8f7-c021-4d4f-98b5-ee363d02682c";
			var userRoleId = "1d26c5ff-823e-48b9-b4ed-69aaff9e9e1f";

			//Seed Roles (SuperAdmin, Normal User)
			var roles = new List<IdentityRole>()
			{
				new IdentityRole()
				{
					Name = "SuperAdmin",
					NormalizedName = "SuperAdmin",
					Id = superAdminRoleId,
					ConcurrencyStamp = superAdminRoleId

				},
				 new IdentityRole()
				{
					Name = "Normie",
					NormalizedName = "Normie",
					Id = userRoleId,
					ConcurrencyStamp = userRoleId

				},

			};
			builder.Entity<IdentityRole>().HasData(roles);


			var superAdminId = "b6123536-7a89-4abd-a837-e85d170ae581";
			//Seed Super Admin User
			var superAdminUser = new IdentityUser()
			{
				Id = superAdminId,
				UserName = "SuperAdmin@forum.com",
				NormalizedUserName = "superadmin@forum.com".ToUpper()
			};

			superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "secretPass101");

			builder.Entity<IdentityUser>().HasData(superAdminUser);

			var superAdminRoles = new List<IdentityUserRole<string>>()
			{
				new IdentityUserRole<string>()
				{
					RoleId = superAdminRoleId,
					UserId = superAdminId
				},
				new IdentityUserRole<string>()
				{
					RoleId = userRoleId,
					UserId = superAdminId
				}

			};

			//Add roles to Super Admin User
			builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

		}

	}
}