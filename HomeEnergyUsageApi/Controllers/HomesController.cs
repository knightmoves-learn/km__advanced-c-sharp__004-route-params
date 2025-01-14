using Microsoft.AspNetCore.Mvc;

namespace HomeEnergyUsageApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomesController : ControllerBase
    {
        private static List<Home> homes = new List<Home>() {
            new Home("Kim", "204 Maple Hill Road", "Atlanta", 4923),
            new Home("Garcia", "West 7th Street", "Tuscon", 3521),
            new Home("Connor", "332 Birchwood Circle", "Miami", 2576)};

        private Home notFound = new Home("Nobody", "000 Nowhere Ave", "No Owner Was Found", 0);

        [HttpGet]
        public IEnumerable<Home> Get()
        {
            return homes;
        }

        [HttpGet("{ownerLastName}")]
        public object FindByLastName(string ownerLastName)
        {
            var homeFound = false;
            foreach (var home in homes)
            {
                if(home.ownerLastName.Equals(ownerLastName))
                {
                    homeFound = true;
                    return home;
                }
            }
            if(homeFound == false)
            {
                return notFound;
            }
            else return null;
        }

        [HttpPost]
        public Home Post([FromBody] Home home)
        {
            homes.Add(home);
            return home;
        }
    }

}
