namespace BodyMassIndexCalculator.UnitTests
{
  public class Tests
  {
    [Test]
    public void Test1()
    {
      var height = new Height(34);

      var a = height.Equals(new Height(34));
    }
  }
}