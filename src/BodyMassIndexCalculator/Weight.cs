namespace BodyMassIndexCalculator
{
  public sealed record Weight
  {
    public double Value { get; }

    public Weight(double value)
    {
      if (!IsValid(value))
      {
        throw new ArgumentException($"{value} is not a valid weight in kilograms", nameof(value));
      }

      this.Value = value;

      static bool IsValid(double value) => value > 0;
    }
  }
}
