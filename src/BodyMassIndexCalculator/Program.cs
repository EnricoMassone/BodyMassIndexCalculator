using System.Globalization;
using static BodyMassIndexCalculator.Functions;

namespace BodyMassIndexCalculator
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      Run(ReadInputFromUser, WriteToConsole);
    }

    public static void Run(Func<string, double> reader, Action<HealthCondition> writer)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader));
      }

      if (writer is null)
      {
        throw new ArgumentNullException(nameof(writer));
      }

      var height = reader("Please enter your height in meters");
      var weight = reader("Please enter your weight in kilograms");

      var bodyMassIndex = ComputeBodyMassIndex(
        new Weight(weight),
        new Height(height)
      );

      var healthCondition = ToHealthCondition(bodyMassIndex);

      writer(healthCondition);
    }

    private static double ReadInputFromUser(string prompt)
    {
      Console.WriteLine(prompt);
      var value = Console.ReadLine() ?? string.Empty;
      return double.Parse(value, CultureInfo.CurrentCulture);
    }

    private static void WriteToConsole(HealthCondition healthCondition) =>
      Console.WriteLine($"Your current condition is: {healthCondition}");
  }
}