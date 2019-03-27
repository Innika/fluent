using FluentTests.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace FluentTests.Tests
{
    class DrawingTests : BaseTest
    {
        [Test]
        public void DrawMultipleShapesTest()
        {
            var shapes = new List<Shape>()
            {
                new Shape(x:240, y: 140),
                new Shape(x:230, y:180, fillColor:"#e7e767", strokeColor: "#eb1a1a"),
                new Shape(x: 30, y:18, fillColor:"#0bd50b", strokeColor: "#6767e7", strokeWidth:14),
                new Shape(x: 500, y:-240, fillColor:"#ffffff", strokeColor: "#ebeb1a", strokeWidth:2),
                new Shape(x: 200, y:100, fillColor:"#41e841", opacityValue: 0.5)
            };

            canvasPage.DrawLine(shapes[0].X, shapes[0].Y);

            canvasPage.SelectFillColor(shapes[1].FillColor);
            canvasPage.SelectStrokeColor(shapes[1].StrokeColor);
            canvasPage.DrawEllipse(shapes[1].X, shapes[1].Y);

            canvasPage.SelectFillColor(shapes[2].FillColor);
            canvasPage.SelectStrokeColor(shapes[2].StrokeColor);
            canvasPage.SetStrokeWidth(shapes[2].StrokeWidth);
            canvasPage.DrawEllipse(shapes[2].X, shapes[2].Y);

            canvasPage.SelectFillColor(shapes[3].FillColor);
            canvasPage.SelectStrokeColor(shapes[3].StrokeColor);
            canvasPage.SetStrokeWidth(shapes[3].StrokeWidth);
            canvasPage.DrawEllipse(shapes[3].X, shapes[3].Y);

            canvasPage.SelectFillColor(shapes[4].FillColor);
            canvasPage.SetOpacity(shapes[4].OpacityValue);
            canvasPage.DrawEllipse(shapes[4].X, shapes[4].Y);


            var actualShapes = canvasPage.GetShapes();

            Assert.Multiple(() => {
                Assert.AreEqual(shapes.Count, actualShapes.Count);

                //default values for the first shape
                Assert.AreEqual(actualShapes[0].FillColor, "#4a90d6");
                Assert.AreEqual(actualShapes[0].StrokeColor, "#222222");
                Assert.AreEqual(actualShapes[0].OpacityValue, 1);
                Assert.AreEqual(actualShapes[0].StrokeWidth, 2);
                       
                //changed Fill and Stroke colors. Opacity and Stroke Witdth are still default
                Assert.AreEqual(actualShapes[1].FillColor, shapes[1].FillColor);
                Assert.AreEqual(actualShapes[1].StrokeColor, shapes[1].StrokeColor);
                Assert.AreEqual(actualShapes[1].OpacityValue, 1);
                Assert.AreEqual(actualShapes[1].StrokeWidth, 2);
                       
                Assert.AreEqual(actualShapes[2].FillColor, shapes[2].FillColor);
                Assert.AreEqual(actualShapes[2].StrokeColor, shapes[2].StrokeColor);
                Assert.AreEqual(actualShapes[2].OpacityValue, 1);   //still default
                Assert.AreEqual(actualShapes[2].StrokeWidth, shapes[2].StrokeWidth);
                       
                Assert.AreEqual(actualShapes[3].FillColor, shapes[3].FillColor);
                Assert.AreEqual(actualShapes[3].StrokeColor, shapes[3].StrokeColor);
                Assert.AreEqual(actualShapes[3].OpacityValue, 1);   //still default
                Assert.AreEqual(actualShapes[3].StrokeWidth, shapes[3].StrokeWidth);
                       
                //change Fill color and Opacity. Stroke color and width weren't changed after previous shape
                Assert.AreEqual(actualShapes[4].FillColor, shapes[4].FillColor);
                Assert.AreEqual(actualShapes[4].StrokeColor, shapes[3].StrokeColor); 
                Assert.AreEqual(actualShapes[4].OpacityValue, shapes[4].OpacityValue);
                Assert.AreEqual(actualShapes[4].StrokeWidth, shapes[3].StrokeWidth);
            });

        }
    }
}
