namespace FluentTests.Models
{
    public class Shape
    {
        public int X;
        public int Y;
        public string FillColor, StrokeColor;
        public double OpacityValue;
        public int StrokeWidth;

        public Shape(int x = 0, int y = 0, string fillColor = "#4a90d6",
            string strokeColor = "#222222", double opacityValue = 1, int strokeWidth = 2)
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
