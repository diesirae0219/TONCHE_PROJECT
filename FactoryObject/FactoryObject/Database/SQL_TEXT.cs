using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FactoryObject.Database
{
    public class SQL_TEXT
    {

        public static string Q_CHECK_PW = @"SELECT *  FROM  tbaemploy AS t WHERE   (emplno = ':empl') and upper(PW)=upper(':password') ";
        
    

    }
}
