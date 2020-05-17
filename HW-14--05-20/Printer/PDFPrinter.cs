using HW_14__05_20.Interfaces;
using HW_14__05_20.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_14__05_20.Printer
{
    class PDFPrinter : IPrinterText, IPrinterPerson
    {
        public void PrintPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void PrintText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
