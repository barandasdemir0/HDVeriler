using HD_Veriler.Models;
using Microsoft.EntityFrameworkCore;

namespace HD_Veriler.Helpers
{
	public class DbContextHelper
	{
		public static HDVerilerContext CreateContext()
		{
			var options = new DbContextOptionsBuilder<HDVerilerContext>()
				.UseSqlServer("HDVeriConnection")
				.Options;

			return new HDVerilerContext(options);
		}
	}
}
