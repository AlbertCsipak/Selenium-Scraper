using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbitrator2
{
    public class Match
    {
        public string GID { get { return NameHome + NameAway; } }
        public string NameHome { get; set; }
        public string NameAway { get; set; }
        public List<Odds> Odds { get; set; }
		public Match()
        {
            NameHome = string.Empty;
            NameAway = string.Empty;
            Odds = new List<Odds>();
        }
    }
}
