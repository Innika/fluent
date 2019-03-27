namespace FluentTests.Models
{
    public class Shape
    {
        public int X, Y;
        public string FillColor, StrokeColor;
        public double OpacityValue;
        public int StrokeWidth;

        // TODO add coordinates prop

        public Shape(int x = 0, int y = 0, string fillColor = null,
            string strokeColor = null, double opacityValue = 1, int strokeWidth = 1)
        {
            X = x;
            Y = y;

            FillColor = fillColor;
            StrokeColor = strokeColor;
            OpacityValue = opacityValue;
            StrokeWidth = strokeWidth;
        }
    }
}
