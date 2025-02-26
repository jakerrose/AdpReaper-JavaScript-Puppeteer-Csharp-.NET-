using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lifewell
{
	// Custom comparer for natural sorting
	public class NaturalStringComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			if (x == y) return 0;
			if (x == null) return -1;
			if (y == null) return 1;

			var regex = new Regex(@"\d+");

			var xMatches = regex.Matches(x);
			var yMatches = regex.Matches(y);

			int maxMatches = Math.Min(xMatches.Count, yMatches.Count);

			for (int i = 0; i < maxMatches; i++)
			{
				int xValue = int.Parse(xMatches[i].Value);
				int yValue = int.Parse(yMatches[i].Value);

				int comparison = xValue.CompareTo(yValue);
				if (comparison != 0) return comparison;
			}

			return x.CompareTo(y);
		}
	}
}
