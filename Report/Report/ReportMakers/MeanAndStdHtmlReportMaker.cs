using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
	public class MeanAndStdHtmlReportMaker : ReportMaker
	{
		public override string Caption
		{
			get
			{
				return "Mean and Std";
			}
		}

		public override string MakeCaption(string caption)
		{
			return $"<h1>{caption}</h1>";
		}

		public override string BeginList()
		{
			return "<ul>";
		}

		public override string EndList()
		{
			return "</ul>";
		}

		public override string MakeItem(string valueType, string entry)
		{
			return $"<li><b>{valueType}</b>: {entry}";
		}

		public override object MakeStatistics(IEnumerable<double> data)
		{
			var list = data.ToList();
			var mean = list.Average();
			var std = Math.Sqrt(list.Select(z => Math.Pow(z - mean, 2)).Sum() / (list.Count - 1));

			return new MeanAndStd
			{
				Mean = mean,
				Std = std
			};
		}
	}
}
