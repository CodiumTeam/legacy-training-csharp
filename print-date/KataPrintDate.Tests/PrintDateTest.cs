using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;

namespace KataPrintDate.Tests
{
    public class PrintDateTest
    {
        [Fact]
        public void think_a_good_name_and_change_it()
        {
            var printDate = new PrintDate();

            printDate.PrintCurrentDate();

            // I don't know how to test it 
        }
    }
}
