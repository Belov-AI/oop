using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
	public class MedianMarkdownReportMaker : ReportMaker
	{
		public override string Caption
		{
			get
			{
				return "Median";
			}
		}

		public override string BeginList()
		{
			return "";
		}

		public override string EndList()
		{
			return "";
		}

		public override string MakeCaption(string caption)
		{
			return $"## {caption}\n\n";
		}

		public override string MakeItem(string valueType, string entry)
		{
			return $" * **{valueType}**: {entry}\n\n";
		}

		public override object MakeStatistics(IEnumerable<double> data)
		{
			var list = data.OrderBy(z => z).ToList();
			if (list.Count % 2 == 0)
				return (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2;

			return list[list.Count / 2];
		}
	}
}
