﻿using Newtonsoft.Json;

namespace CalculatorLibrary;

public class Calculator
{
  readonly JsonWriter writer;

  public Calculator()
  {
    StreamWriter logFile = File.CreateText("calculatorlog.json");
    logFile.AutoFlush = true;
    writer = new JsonTextWriter(logFile);
    writer.Formatting = Formatting.Indented;
    writer.WriteStartObject();
    writer.WritePropertyName("Operations");
    writer.WriteStartArray();
  }

  public double DoOperation(double num1, double num2, string op)
  {
    double result = double.NaN;
    writer.WriteStartObject();
    writer.WritePropertyName("Operand1");
    writer.WriteValue(num1);
    writer.WritePropertyName("Operand2");
    writer.WriteValue(num2);
    writer.WritePropertyName("Operation");
    switch (op)
    {
      case "a":
        result = num1 + num2;
        writer.WriteValue("Add");
        break;
      case "s":
        result = num1 - num2;
        writer.WriteValue("Subtract");
        break;
      case "m":
        result = num1 * num2;
        writer.WriteValue("Multiply");
        break;
      case "d":
        if (num2 != 0)
        {
          result = num1 / num2;
          writer.WriteValue("Divide");
        }
        break;
      case "e":
        result = Math.Pow(num1, num2);
        writer.WriteValue("Power");
        break;
      default:
        break;
    }
    writer.WritePropertyName("Result");
    writer.WriteValue(result);
    writer.WriteEndObject();
    return result;
  }

  public double DoOperation(double num1, string op)
  {
    double result = double.NaN;
    writer.WriteStartObject();
    writer.WritePropertyName("Operand1");
    writer.WriteValue(num1);
    writer.WritePropertyName("Operation");
    switch (op)
    {
      case "t":
        result = num1 * 10;
        writer.WriteValue("10x");
        break;
      case "sq":
        result = Math.Sqrt(num1);
        writer.WriteValue("Square Root");
        break;
      case "sin":
        result = Math.Sin(num1);
        writer.WriteValue("Sine");
        break;
      case "c":
        result = Math.Cos(num1);
        writer.WriteValue("Cosine");
        break;
      case "tan":
        result = Math.Tan(num1);
        writer.WriteValue("Tangent");
        break;
      default:
        writer.WriteValue("Invalid Operation");
        break;
    }
    writer.WritePropertyName("Result");
    writer.WriteValue(result);
    writer.WriteEndObject();
    return result;
  }

  public void Finish()
  {
    writer.WriteEndArray();
    writer.WriteEndObject();
    writer.Close();
  }
}