﻿namespace Calculator.Services;

public interface ICalculatorService
{
    public double Add(double a, double b);
    public double Subtract(double a, double b);
    public double Multiply(double a, double b);
    public double Divide(double a, double b);
}
