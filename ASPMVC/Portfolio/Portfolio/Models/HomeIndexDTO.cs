using System;
namespace Portfolio.Models
{
	public class HomeIndexDTO
	{
        public IEnumerable<ProjectDTO>? Projects { get; set; }

        public HomeIndexDTO()
		{
		}
	}
}

