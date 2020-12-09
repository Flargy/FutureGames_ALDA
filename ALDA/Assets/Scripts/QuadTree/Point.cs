namespace Scripts.QuadTree
{
    // Saves the coordinates of each point added to the quad tree
    public class Point
    {
        public float x = 0f;
        public float y = 0f;
        
        // The constructor which creates the points and sets their values
        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}