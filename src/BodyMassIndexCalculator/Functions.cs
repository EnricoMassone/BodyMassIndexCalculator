using static System.Math;

namespace BodyMassIndexCalculator
{
  public static class Functions
  {
    public static double ComputeBodyMassIndex(
      Weight weight,
      Height height)
    {
      if (weight is null)
      {
        throw new ArgumentNullException(nameof(weight));
      }

      if (height is null)
      {
        throw new ArgumentNullException(nameof(height));
      }

      var index = weight.Value / Pow(height.Value, 2);
      return Round(index, 2);
    }

    public static HealthCondition ToHealthCondition(double bmi) =>
      bmi switch
      {
        < 18.5 => HealthCondition.Underweight,
        >= 18.5 and < 25 => HealthCondition.Healthy,
        _ => HealthCondition.Overweight
      };
  }
}
