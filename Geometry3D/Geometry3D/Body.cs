using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3D
{
    public class Body
    {
        public Vector3 Position { get; }

        protected Body(Vector3 position)
        {
            Position = position;
        }

        public bool ContainsPoint(Vector3 point)
        {
            if (this is Ball ball)
            {
                var vector = point - Position;
                var length2 = vector.GetLength2();
                return length2 <= ball.Radius * ball.Radius;
            }

            if (this is RectangularCuboid cuboid)
            {
                var minPoint = new Vector3(
                    Position.X - cuboid.SizeX / 2,
                    Position.Y - cuboid.SizeY / 2,
                    Position.Z - cuboid.SizeZ / 2);
                var maxPoint = new Vector3(
                    Position.X + cuboid.SizeX / 2,
                    Position.Y + cuboid.SizeY / 2,
                    Position.Z + cuboid.SizeZ / 2);

                return point >= minPoint && point <= maxPoint;
            }

            if (this is Cylinder cylinder)
            {
                var vectorX = point.X - Position.X;
                var vectorY = point.Y - Position.Y;
                var length2 = vectorX * vectorX + vectorY * vectorY;
                var minZ = Position.Z - cylinder.SizeZ / 2;
                var maxZ = minZ + cylinder.SizeZ;

                return length2 <= cylinder.Radius * cylinder.Radius && point.Z >= minZ && point.Z <= maxZ;
            }

            if (this is CompoundBody compound)
            {
                return compound.Parts.Any(body => body.ContainsPoint(point));
            }

            throw new NotImplementedException("Unknown body!");
        }

        public RectangularCuboid GetBoundingBox()
        {
            throw new NotImplementedException("TODO");
        }
    }

}
