using System;
using System.Drawing;

namespace Untangle
{
    class Edge : Element
    {
        public Edge(Design body, Point location)
        {       
            Body = body;
            Location = location;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Body.Color, Body.Size), GameForm.Vertices[Location.X].Location.X, GameForm.Vertices[Location.X].Location.Y, GameForm.Vertices[Location.Y].Location.X, GameForm.Vertices[Location.Y].Location.Y);
        }

        public bool Equals(Edge other)
        {
            Point InverseLocation = new Point(Location.Y, Location.X);
            return other.Location == Location || other.Location == InverseLocation;
        }

        public override int GetHashCode()
        {
            return GetHashCode();
        }
    }
}