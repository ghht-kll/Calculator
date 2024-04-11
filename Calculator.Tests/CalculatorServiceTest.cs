using Calculator.Services;

namespace Calculator.Tests;

public class CalculatorServiceTest
{
    [Fact]
    public void AddReturnsCorrectSum()
    {
        var calculatorService = new CalculatorService();

        var result = calculatorService.Add(5, 2);

        Assert.Equal(7, result);
    }

    [Fact]
    public void SubtractReturnsCorrectDifference()
    {
        var calculatorService = new CalculatorService();

        var result = calculatorService.Subtract(5, 2);

        Assert.Equal(3, result);
    }

    [Fact]
    public void MultiplyReturnsCorrectProduct()
    {
        var calculatorService = new CalculatorService();

        var result = calculatorService.Multiply(5, 2);

        Assert.Equal(10, result);
    }

    [Fact]
    public void DivideReturnsCorrectQuotient()
    {
        var calculatorService = new CalculatorService();

        var result = calculatorService.Divide(6, 2);

        Assert.Equal(3, result);
    }

    [Fact]
    public void DivideByZeroThrowsDivideByZeroException()
    {
        var calculatorService = new CalculatorService();

        Assert.Throws<DivideByZeroException>(() => calculatorService.Divide(6, 0));
    }
}