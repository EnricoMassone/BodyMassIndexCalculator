using static BodyMassIndexCalculator.Functions;

namespace BodyMassIndexCalculator.UnitTests
{
  public sealed class FunctionsTest
  {
    [Test]
    public void ComputeBodyMassIndex_Throws_ArgumentNullException_When_Weight_Is_Null()
    {
      // ARRANGE
      var height = new Height(1.80);

      // ACT
      var exception = Assert.Throws<ArgumentNullException>(
        () => ComputeBodyMassIndex(null!, height)
      );

      // ASSERT
      Assert.That(exception.ParamName, Is.EqualTo("weight"));
    }

    [Test]
    public void ComputeBodyMassIndex_Throws_ArgumentNullException_When_Height_Is_Null()
    {
      // ARRANGE
      var weight = new Weight(70);

      // ACT
      var exception = Assert.Throws<ArgumentNullException>(
        () => ComputeBodyMassIndex(weight, null!)
      );

      // ASSERT
      Assert.That(exception.ParamName, Is.EqualTo("height"));
    }

    [TestCaseSource(nameof(GetTestCasesForComputeBodyMassIndex))]
    public void ComputeBodyMassIndex_Computes_Body_Mass_Index(Weight weight, Height height, double expected)
    {
      // ACT
      var result = ComputeBodyMassIndex(weight, height);

      // ASSERT
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(GetTestCasesForToHealthCondition))]
    public void ToHealthCondition_Converts_Body_Mass_Index_To_Health_Condition(double bmi, HealthCondition expected)
    {
      // ACT
      var result = ToHealthCondition(bmi);

      // ASSERT
      Assert.That(result, Is.EqualTo(expected));
    }

    private static IEnumerable<object[]> GetTestCasesForComputeBodyMassIndex()
    {
      yield return new object[] { new Weight(70), new Height(1.80), 21.60 };
      yield return new object[] { new Weight(80), new Height(1.20), 55.56 };
      yield return new object[] { new Weight(50), new Height(1.80), 15.43 };
    }

    private static IEnumerable<object[]> GetTestCasesForToHealthCondition()
    {
      yield return new object[] { 13, HealthCondition.Underweight };
      yield return new object[] { 18.4, HealthCondition.Underweight };
      yield return new object[] { 18.5, HealthCondition.Healthy };
      yield return new object[] { 20, HealthCondition.Healthy };
      yield return new object[] { 24.9, HealthCondition.Healthy };
      yield return new object[] { 25, HealthCondition.Overweight };
      yield return new object[] { 26, HealthCondition.Overweight };
      yield return new object[] { 30, HealthCondition.Overweight };
    }
  }
}