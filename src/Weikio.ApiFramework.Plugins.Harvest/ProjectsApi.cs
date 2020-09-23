using System.Collections.Generic;
using System.Threading.Tasks;
using Adafy.Harvest.Netstandard;
using Adafy.Harvest.Netstandard.Models;

namespace Weikio.ApiFramework.Plugins.Harvest
{
    public class ProjectsApi
    {
        public HarvestOptions Configuration { get; set; }

        public async Task<List<Project>> GetProjects()
        {
            var client = new HarvestRestClient(Configuration.HarvestCompany, Configuration.HarvestUser, Configuration.HarvestUserPassword);

            var result = await client.ListProjectsAsync();

            return new List<Project>(result);
        }
    }
}
