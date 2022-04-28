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

        /*��������� �������� ���������� ������� ������������*/
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

        /*��������� �������� ���������� ������� �����*/
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

        /*��������� �������� ��������� �������������� ������������*/
        [Fact]
        public void RectangularTriangle_Triangle_return_boolValue()
        {
            /*����������� �� �������������*/
            Triangle notRectangularTriangle = new Triangle()
            {
                SideA = 12,
                SideB = 14,
                SideC = 7
            };

            /*����������� �������������*/
            Triangle rectangularTriangle = new Triangle()
            {
                SideA = 2f,
                SideB = 2.824f,
                SideC = 2
            };

            Figure<Triangle> figure = new Figure<Triangle>();

            bool isNotRectangularTriangle = false; //����� ����� false � ������, ���� ����������� �� �������������
            bool isRectangularTriangle = true; //����� ����� true � ������, ���� ����������� �������������

            //������� �� ������������� �����������, ������� ������ ������ ������� false
            bool awaitingResult = figure.RectangularTriangle(notRectangularTriangle);
            Assert.Equal(awaitingResult, isNotRectangularTriangle);


            //������� ������������� �����������, ������� ������ ������ ������� true
            bool awaitingResult2 = figure.RectangularTriangle(rectangularTriangle);
            Assert.Equal(awaitingResult2, isRectangularTriangle);
        }
    }
}
