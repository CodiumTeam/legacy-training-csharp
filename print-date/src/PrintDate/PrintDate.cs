namespace PrintDate;

public class PrintDate
{
    private readonly Calendar _calendar;
    private readonly Printer _printer;

    public PrintDate(Calendar calendar, Printer printer)
    {
        _calendar = calendar;
        _printer = printer;
    }

    public void PrintCurrentDate()
    {
        var line = _calendar.Today().ToString();
        _printer.PrintLine(line);
    }
}
