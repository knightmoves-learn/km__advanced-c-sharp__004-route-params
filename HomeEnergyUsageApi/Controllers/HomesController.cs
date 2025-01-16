using Microsoft.AspNetCore.Mvc;

namespace HomeEnergyUsageApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomesController : ControllerBase
    {
        private static List<Home> homesList = new List<Home>() {
            new Home("Kim", "204 Maple Hill Road", "Atlanta", 4923),
            new Home("Garcia", "West 7th Street", "Tuscon", 3521),
            new Home("Connor", "332 Birchwood Circle", "Miami", 2576)};

        [HttpGet]
        public IEnumerable<Home> Get()
        {
            return homesList;
        }

        [HttpGet("{ownerLastName}")]

        public Home FindByLastName(string lastNameParam)
        {
            foreach (var home in homesList)
            {
                if (home.ownerLastName.Equals(lastNameParam))
                {
                    return home;
                }
            }
            return null;
        }


        [HttpPost]
        public Home Post([FromBody] Home home)
        {
            homesList.Add(home);
            return home;
        }



    }

}
