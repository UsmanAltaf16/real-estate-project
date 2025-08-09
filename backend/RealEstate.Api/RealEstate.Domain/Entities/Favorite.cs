using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class Favorite
    {
        public int UserId { get; set; }
        public int PropertyId { get; set; }
        public User User { get; set; } = default!;
        public Property Property { get; set; } = default!;
    }
}
