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

    [TestCaseSource(nameof(GetTestCases))]
    public void ComputeBodyMassIndex_Computes_Body_Mass_Index(Weight weight, Height height, double expected)
    {
      // ACT
      var result = ComputeBodyMassIndex(weight, height);

      // ASSERT
      Assert.That(result, Is.EqualTo(expected));
    }

    public static IEnumerable<object[]> GetTestCases()
    {
      yield return new object[] { new Weight(70), new Height(1.80), 21.60 };
      yield return new object[] { new Weight(80), new Height(1.20), 55.56 };
      yield return new object[] { new Weight(50), new Height(1.80), 15.43 };
    }
  }
}