using System.Collections.Generic;
using UnityEngine;

namespace Scripts.QuadTree
{
    public class QuadTree 
    {
        Rectangle boundary = null;
        List<Point> points = new List<Point>();

        int capacity = 0;
        bool divided = false;

        QuadTree northEast = null;
        QuadTree northWest = null;
        QuadTree southEast = null;
        QuadTree southWest = null;
        
        // Removed "addedBeforeDivide" as it wasn't used for anything
        
        // A constructor for creating a new quadtree. Takes an area/rectangle and a capacity of points
        public QuadTree(Rectangle rectangle, int capacity)
        {
            boundary = rectangle;
            this.capacity = capacity;
        }
        
        // Tries to insert a point into the quadTree, the tree will then see if the point is within its .
        // If the point is within bounds and the max capacity before division hasn't been reached it
        // will place the point into the quadtree. Once the max capacity has been reached the tree will
        // divide itself into 4 equal portions that becomes new quadtrees.
        // If a point is placed after the division it will do a form of recursive call to one of the new
        // quadtrees from the division based on the points position.
        public bool Insert(Point point)
        {
            if (boundary.InBounds(point) == false)
            {
                return false;
            }

            if (points.Count < capacity)
            {
                points.Add(point);
                return true;
            }

            if (points.Count >= capacity)
            {   // Removed "points.Clear()" from here as that caused the code to place another 3 points
                // into the quadtree which had already reached its capacity. This made it take 3 more points
                // to get into the new trees from the division.
                if (divided == false)
                {
                    Subdivide();
                }
                if (northEast.Insert(point) == true)
                {
                    return true;
                }
                else if (northWest.Insert(point) == true)
                {
                    return true;
                }
                else if (southEast.Insert(point) == true)
                {
                    return true;
                }
                else if (southWest.Insert(point) == true)
                {
                    return true;
                }
                
            }
            return false;
        }
        
        // Creates 4 new quadtrees of equal size and sets "divided" to true so that the quadtree can't
        // divide itself further.
        private void Subdivide()
        {
            northEast = new QuadTree(boundary.NorthEast, capacity);
            northWest = new QuadTree(boundary.NorthWest, capacity);

            southEast = new QuadTree(boundary.SouthEast, capacity);
            southWest = new QuadTree(boundary.SouthWest, capacity);

            divided = true;
        }
        
        // Creates borders for the quadtree and updates the visuals for all quadtrees
        public void Show(Texture2D texture)
        {
            for (float x = boundary.West; x < boundary.East; x += 1f)
            {
                texture.SetPixel((int)x, (int)boundary.South, Color.red);
                texture.SetPixel((int)x, (int)boundary.North, Color.green);
            }
            
            for (float y = boundary.South; y < boundary.North; y += 1f)
            {
                texture.SetPixel((int)boundary.West, (int)y, Color.blue);
                texture.SetPixel((int)boundary.East, (int)y, Color.grey);
            }

            if (divided == true)
            {
                northEast.Show(texture);
                northWest.Show(texture);

                southEast.Show(texture);
                southWest.Show(texture);
            }
            for (int i = 0; i < points.Count; i++)
            {
                texture.SetPixel((int)points[i].x, (int)points[i].y, Color.white);
            }
        }

    }
}