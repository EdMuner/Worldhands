using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worldhands.Web.Data.Entities
{
    public class Visitor
    {
        public int Id { get; set; }

        public User User { get; set; }
    }
}