using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
	public abstract class ReportMaker
	{
		public abstract string MakeCaption(string caption);
		public abstract string BeginList();
		public abstract string MakeItem(string valueType, string entry);
		public abstract string EndList();
		public abstract object MakeStatistics(IEnumerable<double> data);
		public abstract string Caption { get; }
		public string MakeReport(IEnumerable<Measurement> measurements)
		{
			var data = measurements.ToList();
			var result = new StringBuilder();
			result.Append(MakeCaption(Caption));
			result.Append(BeginList());
			result.Append(MakeItem("Temperature", MakeStatistics(data.Select(z => z.Temperature)).ToString()));
			result.Append(MakeItem("Humidity", MakeStatistics(data.Select(z => z.Humidity)).ToString()));
			result.Append(EndList());
			return result.ToString();
		}
	}
}
