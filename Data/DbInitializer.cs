using AppForTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AppForTestTask.Data
{
	public class DbInitializer
	{
		public static void Initialize(DbForTestTaskContext context)
		{
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

            if (!context.Folders.Any())
			{
                var folders = new Folder[]
                {
                    new Folder { Name = "Creating Digital Images", Path = "/"},
					new Folder { Name = "Resources", Path = "/1/"},
					new Folder { Name = "Primary Sources", Path = "/1/1/"},
					new Folder { Name = "Secondary Sources", Path = "/1/2/"},
					new Folder { Name = "Evidence", Path = "/2/"},
					new Folder { Name = "Graphic Products", Path = "/3/" },
					new Folder { Name = "Process", Path = "/3/1/" },
					new Folder { Name = "Final Product", Path = "/3/2/" },
                };
                context.AddRange(folders);
				context.SaveChanges();
			}
		}
	}
}
