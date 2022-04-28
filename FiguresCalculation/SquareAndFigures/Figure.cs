using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresCalculation
{
    ///Данный класс применяется в том случае, если у нас есть 2 известные заранее фигуры, которые мы передаём из внешнего кода
    ///для работы с ним нужно создать классы треугольника и круга (уже созданы) и заполнить их свойствами,
    ///которые будут отвечать за их параметры
    
    public class Figure<T> : IFigure
    {
        private T newFigureObject { get; set; }
        private int _resultValue;

        public int ResultValue
        {
            get
            {
                return _resultValue;
            }

            private set { }
        }

        public Figure() { }

        public Figure(T newFigureObject)
        {
            this.newFigureObject = newFigureObject;

            CheckTypeOfFigure();
        }

        /*Проверка типов, данный метод доступен для переопределения, если мы хотим выполнять проверку других типов в классе-наследнике*/
        public virtual void CheckTypeOfFigure()
        {
            if (newFigureObject is Circle)
            {
                Circle circle = newFigureObject as Circle;
                CalculateCircle(circle, out _resultValue);
            }

            if (newFigureObject is Triangle)
            {
                Triangle triangle = newFigureObject as Triangle;
                CalculateTriangle(triangle, out _resultValue);
            }
        }

        //Расчёт площади круга
        public void CalculateCircle(Circle circle, out int resultVal)
        {
            const float p = 3.14f;
            float result = p * (float)Math.Pow(circle.Radius, 2);

            resultVal = (int)result;
        }

        //Расчёт площади треугольника
        public void CalculateTriangle(Triangle triangle, out int resultVal)
        {
            float perimeter = (triangle.SideA + triangle.SideB + triangle.SideC);
            float result = perimeter / 2;

            resultVal = (int)result;
        }

        //Метод, который позволяет определить прямоугольный треугольник
        public bool RectangularTriangle(Triangle triangle)
        {
            bool isRectangularTriangle = false;

            float cosA = ((float)Math.Pow(triangle.SideA, 2) + (float)Math.Pow(triangle.SideC, 2) - (float)Math.Pow(triangle.SideB, 2)) /
                (2 * triangle.SideA * triangle.SideC);

            float cosB = ((float)Math.Pow(triangle.SideA, 2) + (float)Math.Pow(triangle.SideB, 2) - (float)Math.Pow(triangle.SideC, 2)) /
                (2 * triangle.SideA * triangle.SideB);

            float cosY = ((float)Math.Pow(triangle.SideB, 2) + (float)Math.Pow(triangle.SideC, 2) - (float)Math.Pow(triangle.SideA, 2)) /
                (2 * triangle.SideC * triangle.SideB);


            double a = Math.Round(cosA, 2);
            double b = Math.Round(cosB, 2);
            double c = Math.Round(cosY, 2);

            if (a == 0 || b == 0 || c == 0)
            {
                isRectangularTriangle = true;
            }

            else
            {
                isRectangularTriangle = false;
            }

            return isRectangularTriangle;
        }

        //Метод проверки равенства сторон треугольника (сделал как дополнительный механизм в библиотеке)
        public bool EqualSidesTriangle(Triangle triangle)
        {
            bool isEqualsTriangle = false;

            float[] sidesArr = new float[]
            {
                triangle.SideA,
                triangle.SideB,
                triangle.SideC
            };

            float temp = sidesArr[0];
            int correct = 0;

            for (int i = 0; i < sidesArr.Length; i++)
            {
                if(sidesArr[i] == temp)
                {
                    temp = sidesArr[i];
                    correct += 1;

                    if(correct == sidesArr.Length)
                    {
                        isEqualsTriangle = true;
                    }
                }

                else
                {
                    isEqualsTriangle = false;
                    break;
                }
            }

            return isEqualsTriangle;
        }
    }
}
