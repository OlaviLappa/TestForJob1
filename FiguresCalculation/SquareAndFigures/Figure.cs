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
    
    class Figure<T> : IFigure
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

        //Метод проверки на то, является ли треугольник прямоугольным
        public bool RectangularTriangle(Triangle triangle)
        {
            bool isRectangularTriangle;
            float perimeter = triangle.SideA + triangle.SideB + triangle.SideC;
            float result = perimeter / 3;

            if(result != triangle.SideA)
            {
                isRectangularTriangle = false;
            }

            else
            {
                isRectangularTriangle = true;
            }

            return isRectangularTriangle;
        }
    }
}
