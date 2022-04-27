using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresCalculation
{
    interface IFigure
    {
        void CalculateCircle(Circle circle, out int resultVal);
        void CalculateTriangle(Triangle triangle, out int resultVal);
    }
}
