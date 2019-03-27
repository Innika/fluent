using FluentAssertions;
using FluentTests.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace FluentTests.Tests
{
    class DrawingTests : BaseTest
    {
        List<Shape> shapes = new List<Shape>()
            {
                new Shape(x: 240, y: 140),
                new Shape(x: 230, y: 180, fillColor: "#e7e767", strokeColor: "#eb1a1a" ),
                new Shape(x: 30, y: 18, fillColor: "#0bd50b", strokeColor: "#6767e7", strokeWidth: 14 ),
                new Shape(x: 500, y: -240, fillColor: "#ffffff", strokeColor: "#ebeb1a", strokeWidth: 3 ),
                new Shape(x: 200, y: 100, fillColor: "#41e841", opacityValue: 0.5 )
            };

        [Test]
        public void DrawMultipleShapesTest()
        {
            canvasPage.DrawLine(shapes[0].X, shapes[0].Y)

                .SelectFillColor(shapes[1].FillColor)
                .SelectStrokeColor(shapes[1].StrokeColor)
                .DrawEllipse(shapes[1].X, shapes[1].Y)

                .SelectFillColor(shapes[2].FillColor)
                .SelectStrokeColor(shapes[2].StrokeColor)
                .SetStrokeWidth(shapes[2].StrokeWidth)
                .DrawEllipse(shapes[2].X, shapes[2].Y)

                .SelectFillColor(shapes[3].FillColor)
                .SelectStrokeColor(shapes[3].StrokeColor)
                .SetStrokeWidth(shapes[3].StrokeWidth)
                .DrawEllipse(shapes[3].X, shapes[3].Y)

                .SelectFillColor(shapes[4].FillColor)
                .SetOpacity(shapes[4].OpacityValue)
                .DrawEllipse(shapes[4].X, shapes[4].Y);

            shapes[4].StrokeColor = shapes[3].StrokeColor;
            shapes[4].StrokeWidth = shapes[3].StrokeWidth;

            var actualShapes = canvasPage.GetShapes();


            shapes.Count.Should().Equals(actualShapes.Count);

            actualShapes.Should()
                .HaveCount(5)
                .And.BeEquivalentTo(shapes,
                    options => options.Excluding(sh => sh.X)
                    .Excluding(sh => sh.Y));
        }
    }
}
