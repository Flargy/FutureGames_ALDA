using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.QuadTree
{

    public class Rectangle
    {
        public float centerX = 0f;
        public float centerY = 0f;

        float width = 0f;
        float height = 0f;

        public float HalfWidth => 0.5f * width;
        public float HalfHeight => 0.5f * height;

        public float DoubleWidth => 2f * width;
        public float DoubleHeight => 2f * height;

        public float HalfToWest => centerX - HalfWidth;
        public float HalfToEast => centerX + HalfWidth;

        public float HalfToNorth => centerY + HalfHeight;
        public float HalfToSouth => centerY - HalfHeight;

        public float West => centerX - width;
        public float East => centerX + width;

        public float South => centerY - height;
        public float North => centerY + height;

        public Rectangle NorthEast => new Rectangle(HalfToEast, HalfToNorth, HalfWidth, HalfHeight);
        public Rectangle NorthWest => new Rectangle(HalfToWest, HalfToNorth, HalfWidth, HalfHeight);

        public Rectangle SouthEast => new Rectangle(HalfToEast, HalfToSouth, HalfWidth, HalfHeight);
        public Rectangle SouthWest => new Rectangle(HalfToWest, HalfToSouth, HalfWidth, HalfHeight);
        
        // The constructor for the bounds/rectangle which dictates the area of the quadtree
        public Rectangle(float centerX, float centerY, float width, float height)
        {
            this.centerX = centerX;
            this.centerY = centerY;

            this.width = width;
            this.height = height;
        }
        
        // Returns whether the point is inside the bounds of the rectangle for the quadtree or not.
        // Does this by comparing coordinate positions of the point with the coordinates of the
        // rectangle's edges
        public bool InBounds(Point point)
        {
            return InsideX(point.x) && InsideY(point.y);
        }

        private bool InsideX(float x)
        {
            return x >= West && x <= East;
        }

        private bool InsideY(float y)
        {
            return y >= South && y <= North;
        }
    }
}