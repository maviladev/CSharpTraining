using System;
using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IProjectsRepository
    {
        List<ProjectDTO> GetProjects();        
    }

	public class ProjectsRepository : IProjectsRepository
	{
		public ProjectsRepository()
		{
		}

        public List<ProjectDTO> GetProjects()
        {
            return new List<ProjectDTO>()
        {
            new ProjectDTO
            {
                Title = "Amazon",
                Desciption = "Description Amazon",
                Link = "https://amazon.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            },
            new ProjectDTO
            {
                Title = "Google",
                Desciption = "Description google",
                Link = "https://google.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            },
            new ProjectDTO
            {
                Title = "Reddit",
                Desciption = "Description reddit",
                Link = "https://reddit.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            },
            new ProjectDTO
            {
                Title = "Facebook",
                Desciption = "Description facebook",
                Link = "https://facebook.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            },
            new ProjectDTO
            {
                Title = "Steam",
                Desciption = "Description steam",
                Link = "https://steam.com",
                ImageURL = "https://www.google.com/logos/doodles/2018/first-day-of-school-2018-5501569482096640-2x.png"
            }
        };
        }
    }
}

