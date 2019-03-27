using FluentTests.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace FluentTests.Pages
{
    public class CanvasPage : BasePage
    {
        public CanvasPage(IWebDriver driver) : base(driver) { }

        public List<Shape> GetShapes()
        {
            var shapes = new List<Shape>();

            List<IWebElement> shapeElements = CurrentLayer.FindElements(By.CssSelector("*")).ToList();
            shapeElements.Remove(shapeElements.First());

            shapeElements.ForEach(el => shapes.Add(new Shape(
                fillColor: el.GetAttribute("fill"),
                strokeColor: el.GetAttribute("stroke"),
                opacityValue: double.Parse(el.GetAttribute("opacity")),
                strokeWidth: int.Parse(el.GetAttribute("stroke-width")))));

            return shapes;
        }

        public void DrawLine(int x, int y)
        {
            if (IsShapeOptionSelected(LineTool) == false)
                LineTool.Click();
            DragAndDropOnCanvas(x, y);
        }

        public void DrawEllipse(int x, int y)
        {
            if (IsShapeOptionSelected(EllipseTool) == false)
                EllipseTool.Click();
            DragAndDropOnCanvas(x, y);
        }

        private void DragAndDropOnCanvas(int x, int y)
        {
            Actions ac = new Actions(driver);
            ac.DragAndDropToOffset(Canvas, x, y);
            ac.Build().Perform();
        }

        private bool IsShapeOptionSelected(IWebElement element)
        {
            return element.GetAttribute("class").Contains("current");
        }

        public void SelectFillColor(string colorCode)
        {
            ColorFillCircle(colorCode).Click();
        }

        public void SelectStrokeColor(string colorCode)
        {
            ColorStrokeCircle(colorCode).Click();
        }

        public void SetStrokeWidth(int widthValue)
        {
            StrokeWidthInput.Clear();
            StrokeWidthInput.SendKeys(widthValue.ToString());
        }

        public void SetOpacity(double opacityValue)
        {
            OpacityInput.Clear();
            OpacityInput.SendKeys(opacityValue.ToString());
        }

        #region Elements

        public IWebElement LineTool => driver.FindElement(By.Id("tool_line"));

        public IWebElement FreeLineTool => driver.FindElement(By.Id("tool_fhpath")); 

        public IWebElement RectangleTool => driver.FindElement(By.Id("tool_rect"));

        public IWebElement EllipseTool => driver.FindElement(By.Id("tool_ellipse")); 

        public IWebElement Canvas => driver.FindElement(By.ClassName("zoom-view"));

        public IWebElement CurrentLayer => driver.FindElement(By.ClassName("currentLayer"));

        public IWebElement ColorFillCircle(string colorCode) => driver.FindElement(
            By.CssSelector($".palette_item circle[fill='{colorCode}']"));

        public IWebElement ColorStrokeCircle(string colorCode) => driver.FindElement(
            By.CssSelector($".palette_item circle[stroke='{colorCode}']")).FindElement(By.XPath(".."));

        public IWebElement StrokeWidthInput => driver.FindElement(By.CssSelector("input[title='Stroke Width']"));

        public IWebElement OpacityInput => driver.FindElement(By.CssSelector("input[data-attr='opacity']"));

        #endregion
    }
}
