using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresCalculation
{
    sealed class InfoPanel
    {
        private static readonly string _firstSystemMessage = "Добро пожаловать в систему!";
        public static void ShowFirstSystemMessage() => Console.WriteLine(_firstSystemMessage);

    }

}
