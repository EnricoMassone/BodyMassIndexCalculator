namespace BodyMassIndexCalculator
{
  public sealed record Height
  {
    public double Value { get; }

    public Height(double value)
    {
      if (!IsValid(value))
      {
        throw new ArgumentException($"{value} is not a valid height in meters", nameof(value));
      }

      this.Value = value;

      static bool IsValid(double value) => value > 0 && value < 3;
    }
  }
}
