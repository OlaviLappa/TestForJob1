using System;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using FiguresCalculation;
using Circle = FiguresCalculation.Circle;

namespace Unit_tests
{
    public class UnitTest1
    {

        /*“естируем механизм нахождени€ площади треугольника*/
        [Fact]
        public void CalculateTriangle_Triangle_and_resultVal_return_squareFigure()
        {
            ///Arange
            Triangle triangle = new Triangle()
            {
                SideA = 12,
                SideB = 14,
                SideC = 7
            };

            ///Act
            float awaitingResult = (12 + 14 + 7) / 2;

            Figure<Triangle> figure1 = new Figure<Triangle>(triangle);
            int squareTriangleResult = figure1.ResultValue;

            ///Assert
            Assert.Equal(awaitingResult, squareTriangleResult);
        }

        /*“естируем механизм нахождени€ площади круга*/
        [Fact]
        public void CalculateCircle_Circle_and_resultVal_return_squareFigure()
        {
            ///Arange
            Circle circle= new Circle()
            {
                Radius = 12
            };

            ///Act
            const float p = 3.14f;
            float awaitingResult = p * (float)Math.Pow(circle.Radius, 2);

            Figure<Circle> figure2 = new Figure<Circle>(circle);
            int squareCircleResult = figure2.ResultValue;

            ///Assert
            Assert.Equal((int)awaitingResult, squareCircleResult);
        }

        /*“естируем механизм вы€влени€ пр€моугольного треугольника*/
        [Fact]
        public void RectangularTriangle_Triangle_return_boolValue()
        {
            /*“–≈”√ќЋ№Ќ»  Ќ≈ ѕ–яћќ”√ќЋ№Ќџ…*/
            Triangle notRectangularTriangle = new Triangle()
            {
                SideA = 12,
                SideB = 14,
                SideC = 7
            };

            /*“–≈”√ќЋ№Ќ»  ѕ–яћќ”√ќЋ№Ќџ…*/
            Triangle rectangularTriangle = new Triangle()
            {
                SideA = 2f,
                SideB = 2.824f,
                SideC = 2
            };

            Figure<Triangle> figure = new Figure<Triangle>();

            bool isNotRectangularTriangle = false; //метод выдаЄт false в случае, если треугольник не пр€моугольный
            bool isRectangularTriangle = true; //метод выдаЄт true в случае, если треугольник пр€моугольный

            //ѕередаЄм не пр€моугольный треугольник, система должна выдать булевое false
            bool awaitingResult = figure.RectangularTriangle(notRectangularTriangle);
            Assert.Equal(awaitingResult, isNotRectangularTriangle);


            //ѕередаЄм пр€моугольный треугольник, система должна выдать булевое true
            bool awaitingResult2 = figure.RectangularTriangle(rectangularTriangle);
            Assert.Equal(awaitingResult2, isRectangularTriangle);
        }
    }
}
