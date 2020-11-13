using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class ShapeComparer : IComparer<Shape>
    {
        static Dictionary<string, int> priority = 
            new Dictionary<string, int>();

        static ShapeComparer()
        {
            priority["Circle"] = 0;
            priority["Square"] = 1;
            priority["Rectangle"] = 2;
            priority["Triangle"] = 3;
        }

        public int Compare(Shape x, Shape y)
        {
            var xTypeName = x.GetType().Name;
            var yTypeName = y.GetType().Name;

            if (!priority.ContainsKey(xTypeName))
                if (!priority.ContainsKey(yTypeName))
                    return 0;
                else return 1;
            
            if (!priority.ContainsKey(yTypeName))
                return -1;

            return priority[xTypeName].CompareTo(priority[yTypeName]);
        }
    }
}
