using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppForTestTask.Models
{
	public class Folder
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FolderId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public Folder()
        {
            Name = string.Empty;
            Path = string.Empty;
        }
    }
}
