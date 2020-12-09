using UnityEngine;

namespace Scripts.QuadTree
{
    public class QuadTreeMono : MonoBehaviour
    {
        private int resolution = 256;
        private Renderer myRenderer = null;
        private Texture2D texture = null;
        private QuadTree quadTree = null;
        private Camera myCamera = null;

        [SerializeField] private int capacity = 3;
        // Property of renderer to avoid setting it during start, awake or as a serialized value
        public Renderer MyRenderer 
        {
            get
            {
                if (myRenderer == null)
                {
                    myRenderer = GetComponent<Renderer>();
                }
                return myRenderer;
            }
        }

        // Added the camera as a property lower the cost of finding it through "Camera.main"
        // Now it only does it once instead of each mouse press
        public Camera MyCamera
        {
            get
            {
                if (myCamera == null)
                {
                    myCamera = Camera.main;
                }

                return myCamera;
            }
        }
        private void Update()
        {
            InsertPoint();
        }
        // Sees if the player has pressed the left mouse button or not this frame. If not, return.
        // If the player has pressed it we send a raycast and return if the raycast doesn't hit anything.
        // If the raycast hits the grid we get the position of impact on the texture we hit.
        // We then insert the point into the quadtree and update the texture to show a white dot at the impact.
        private void InsertPoint()
        {
            if (Input.GetMouseButtonDown(0) == false)
            {
                return;
            }

            RaycastHit hit;
            if (Physics.Raycast(MyCamera.ScreenPointToRay(Input.mousePosition), out hit) == false)
            {
                return;
            }

            Vector2 hitUv = hit.textureCoord;
            Vector2 pixelCoord = new Vector2(hitUv.x * texture.width, hitUv.y * texture.height);

            quadTree.Insert(new Point(pixelCoord.x, pixelCoord.y));
            quadTree.Show(texture);
            texture.Apply();
        }

        // Sets starting values and renders borders if there are any
        private void Start()
        {
            texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, false);
            texture.filterMode = FilterMode.Point;

            int size = resolution / 2;
            quadTree = new QuadTree(new Rectangle(size, size, size, size), capacity);

            ClearTexture();
            quadTree.Show(texture);
            MyRenderer.material.mainTexture = texture;

        }
        
        // Clears the current texture and applies a black color instead
        private void ClearTexture()
        {
            Color[] colors = new Color[resolution * resolution];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.black;
            }
            texture.SetPixels(colors);
            texture.Apply();
        }
    }
}