using Moq;
using NSubstitute;
using PrintDate;

namespace KataPrintDate.Tests
{
    public class PrintDateTest
    {
        [Fact]
        public void prints_the_current_date_with_nsubstitute()
        {
            var printer = Substitute.For<IPrinter>();
            var calendar = Substitute.For<ICalendar>();
            calendar.Today().Returns(new DateTime(2024, 01, 02));
            var printDate = new PrintDate.PrintDate(calendar, printer);

            printDate.PrintCurrentDate();

            printer.Received().PrintLine("2/1/2024 0:00:00");
        }
        
        [Fact]
        public void prints_the_current_date_with_moq()
        {
            var printer = new Mock<IPrinter>();
            var calendar = new Mock<ICalendar>();
            calendar.Setup(c => c.Today()).Returns(new DateTime(2024, 01, 02));
            var printDate = new PrintDate.PrintDate(calendar.Object, printer.Object);

            printDate.PrintCurrentDate();

            printer.Verify(p => p.PrintLine("2/1/2024 0:00:00"));
        }
        
        [Fact]
        public void prints_the_current_date_without_library()
        {
            var printer = new PrinterSpy();
            var calendar = new CalendarStub(new DateTime(2024, 01, 02));
            var printDate = new PrintDate.PrintDate(calendar, printer);

            printDate.PrintCurrentDate();

            Assert.Equal("2/1/2024 0:00:00", printer.PrintedLine);
        }
    }

    public class CalendarStub : ICalendar
    {
        private DateTime _dateTime;

        public CalendarStub(DateTime today)
        {
            _dateTime = today;
        }

        public DateTime Today()
        {
            return _dateTime;
        }
    }

    public class PrinterSpy : IPrinter
    {
        public void PrintLine(string line)
        {
            PrintedLine = line;
        }

        public string PrintedLine { get; set; }
    }
}
