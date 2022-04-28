using System;

namespace FiguresCalculation
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Вывод информационных полей*/
            InfoPanel.ShowFirstSystemMessage();

            Circle circle = new Circle() //Создаём экземпляр класса Circle (круг)
            {
                Radius = 13
            };

            Triangle triangle = new Triangle() //Создаём экземпляр класса Triangle (треугольник (подобрал параметры, которые соответсвуют прямоугольному треугольнику, система выдает true))
            {
                SideA = 2f,
                SideB = 2.824f,
                SideC = 2
            };

            /*Создание экземпляров класса, параметризирование их типами фигур и автоматический расчёт площади
            при добавлении параметров в конструкторы*/
            Figure<Triangle> triangle1 = new Figure<Triangle>(triangle);
            Figure<Circle> circle1 = new Figure<Circle>(circle);

            /*Выводим оба результата на консоль*/
            Console.WriteLine($"Площадь треугольника - {triangle1.ResultValue}");
            Console.WriteLine($"Площадь круга - {circle1.ResultValue}");

            /*Есть также возможность создать неперегруженный конструктор и вызвать на экземпляре класса тот метод,
             который необходим сейчас*/

            /*Рассчитываем площадь Круга*/
            Figure<Circle> figure1 = new Figure<Circle>();
            int resultCalculate1;
            figure1.CalculateCircle(circle, out resultCalculate1);

            /*Рассчитываем площадь Треугольника*/
            Figure<Triangle> figure2 = new Figure<Triangle>();
            int resultCalculate2;
            figure2.CalculateTriangle(triangle, out resultCalculate2);

            /*Проверка треугольника на равность сторон (доп. механизм)*/
            bool resTriangle = figure2.EqualSidesTriangle(triangle);

            /*Проверка треугольника (на то, что он является прямоугольным)*/
            bool resTriangle2 = figure2.RectangularTriangle(triangle);


            /*ДОБАВЛЕНИЕ НОВОЙ ФИГУРЫ
             * 
              Идея заключается в том, что мы реализуем интерфейс IFigarable<Т>,
              этот интерфейс содержит единственный метод CalculateAnotherFigure<AnotherFigure>(Quad anotherFigure, out int _resultVal),
              мы реализуем в нём логику и просто вызываем на том же самом объекте во внешнем коде
             */

            /*Квадрат*/
            Quad quad = new Quad()
            {
                SideA = 10,
                SideB = 10,
                SideC = 10,
                SideD = 10,
            };

            int sqiareFigure1 = 0;

            quad.CalculateAnotherFigure<Quad>(quad, out sqiareFigure1);

            /*Трапеция*/
            Trapezoid trap = new Trapezoid()
            {
                SideA = 4,
                SideB = 10,
                SideC = 5,
                SideD = 6,
            };

            int sqiareFigure2 = 0;

            trap.CalculateAnotherFigure<Trapezoid>(trap, out sqiareFigure2);
        }
    }

    /*ПРИМЕРЫ РАБОТЫ С НОВЫМИ ФИГУРАМИ:*/

    /*Создание класса для новой фигуры Quad*/
    class Quad : IFigarable<Quad>
    {
        public float SideA { get; set; }
        public float SideB { get; set; }
        public float SideC { get; set; }
        public float SideD { get; set; }

        public void CalculateAnotherFigure<AnotherFigure>(Quad anotherFigure, out int _resultVal)
        {
            _resultVal = 1;

            /*Здесь описывается логика расчёта площади для указанной в сигнатуре метода фигуре*/
        }
    }

    /*Создание класса для новой фигуры Trapezoid*/
    class Trapezoid : IFigarable<Trapezoid>
    {
        public float SideA { get; set; }
        public float SideB { get; set; }
        public float SideC { get; set; }
        public float SideD { get; set; }

        public void CalculateAnotherFigure<AnotherFigure>(Trapezoid anotherFigure, out int _resultVal)
        {
            _resultVal = 2;

            /*Здесь описывается логика расчёта площади для указанной в сигнатуре метода фигуре*/
        }
    }
}
