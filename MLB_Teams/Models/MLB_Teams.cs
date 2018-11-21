using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MLB_Teams.Models
{
    public class MLBTeam
    {
        [Key]
        public int TeamID { get; set; }
        public int FirstYear { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string StadiumName { get; set; }
    }
    public class MLB_TeamsDBContext : DbContext
    {
        public DbSet<MLBTeam> MLB_Teams { get; set; }
    }
}