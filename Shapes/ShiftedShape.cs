namespace Shapes
{
    public class ShiftedShape : IShapeArea
    {
        readonly IShapeArea _shape;
        readonly int _offsetX;
        readonly int _offsetY;

        public ShiftedShape(IShapeArea shape, int offsetX, int offsetY)
        {
            _shape = shape;
            _offsetX = offsetX;
            _offsetY = offsetY;
        }

        public bool IsFilled(int x, int y)
        {
            var shapeX = x - _offsetX;
            var shapeY = y - _offsetY;
            if (shapeX < 0 || shapeY < 0)
                return false;
            else
                return _shape.IsFilled(shapeX, shapeY);
        }
    }
}
