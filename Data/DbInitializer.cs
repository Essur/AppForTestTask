using AppForTestTask.Models;

namespace AppForTestTask.Data
{
	public class DbInitializer
	{
		private readonly DbForTestTaskContext _context;

        public DbInitializer(DbForTestTaskContext context)
        {
            _context = context;
        }

        public void Initialize()
		{
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();

            if (!_context.Folders.Any())
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
                _context.AddRange(folders);
				_context.SaveChanges();
			}
		}
	}
}
