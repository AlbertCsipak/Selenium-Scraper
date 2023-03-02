using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbitrator2
{
    public class Odds
    {
		public string BookmakerName { get; set; }
		public double OddsHome { get; set; }
		public double OddsDraw { get; set; }
		public double OddsAway { get; set; }
		public Odds()
		{
			BookmakerName = string.Empty;
			OddsHome = 0;
			OddsDraw = 0;
			OddsAway = 0;
		}
	}
}
