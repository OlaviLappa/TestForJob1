using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresCalculation.SQL_request
{
    class SelectData
    {
        string sqlRequest = "SELECT categoryProd.Id, " +
        "categoryProd.Name, " +
        "categoryProd.nameProdId, " +
        "nameProd.Name as ProdName" +
        "FROM phones categoryProd" +
        "JOIN phones nameProd ON categoryProd.nameProdId = nameProd.id;";
    }
}