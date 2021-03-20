namespace Shapes
{
    public class TriangleArea : IShapeArea
    {
        readonly int _width;
        readonly int _height;
        readonly bool _left;

        public TriangleArea (int width, int height, bool left)
        {
            _width = width;
            _height = height;
            _left = left;
        }

        public bool IsFilled(int x, int y)
        {   
            if (x > _width || y > _height)
                return false;
            if (_left)
                return  x <= y;
            else
                return x > _height - y;
            
        }
    }
}
