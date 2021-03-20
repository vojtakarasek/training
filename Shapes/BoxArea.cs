namespace Shapes
{
    public class BoxArea : IShapeArea
    {
        readonly int _width;
        readonly int _height;

        public BoxArea(int width, int height)
        {
            _width = width;
            _height = height;            
        }

        public bool IsFilled(int x, int y)
        {
            return x < _width && y < _height;
        }
    }
}
