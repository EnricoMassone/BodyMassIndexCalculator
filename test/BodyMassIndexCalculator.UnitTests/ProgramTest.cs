using static BodyMassIndexCalculator.Program;

namespace BodyMassIndexCalculator.UnitTests
{
  [TestFixture]
  public sealed class ProgramTest
  {
    [Test]
    public void Run_Throws_ArgumentNullException_When_Reader_Is_Null()
    {
      // ARRANGE
      var writer = (HealthCondition _) => { };

      // ACT
      var exception = Assert.Throws<ArgumentNullException>(
        () => Run(null!, writer)
      );

      // ASSERT
      Assert.That(exception.ParamName, Is.EqualTo("reader"));
    }

    [Test]
    public void Run_Throws_ArgumentNullException_When_Writer_Is_Null()
    {
      // ARRANGE
      var reader = (string _) => 42d;

      // ACT
      var exception = Assert.Throws<ArgumentNullException>(
        () => Run(reader, null!)
      );

      // ASSERT
      Assert.That(exception.ParamName, Is.EqualTo("writer"));
    }

    [Test]
    public void Run_Executes_Expected_Sequence_Of_Invocations()
    {
      // ARRANGE
      var numberOfReaderInvocations = 0;
      var result = HealthCondition.Underweight;
      const double heightInMeters = 1.87d;
      const double weightInKilograms = 80d;
      var userPrompts = new List<string>();

      var reader = (string prompt) =>
      {
        // track the invocation
        numberOfReaderInvocations++;

        // collect the user prompt
        userPrompts.Add(prompt);

        // return a double value
        return prompt.Contains("height", StringComparison.Ordinal) ?
          heightInMeters :
          weightInKilograms;
      };

      var writer = (HealthCondition healthCondition) =>
      {
        result = healthCondition;
      };

      // ACT
      Run(reader, writer);

      // ASSERT
      Assert.That(numberOfReaderInvocations, Is.EqualTo(2));

      CollectionAssert.AreEquivalent(
        new List<string>
        {
          "Please enter your height in meters",
          "Please enter your weight in kilograms"
        },
        userPrompts
      );

      Assert.That(result, Is.EqualTo(HealthCondition.Healthy));
    }
  }
}
