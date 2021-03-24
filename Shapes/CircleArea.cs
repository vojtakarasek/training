namespace Shapes
{
    public class CircleArea : IShapeArea
    {
        readonly int _r;
        

        public CircleArea(int r)
        {
            _r = r;
        }

        public bool IsFilled(int x, int y)
        {
            if (x * x + y * y > _r * _r)
                return false;
            else
                return true;
        }
    }
}
