using System;
using System.Collections.Generic;
using System.Text;

namespace Novir.PetFinder.Core.Dto.Users
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public int Country { get; set; }
        public int City { get; set; }
        public int District { get; set; }

    }
}
