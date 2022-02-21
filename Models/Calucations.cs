namespace AllSpice.Models
{
  public static class Calculations
  {
    public static int Add(int val1, int val2)
    {
      return val1 + val2;
    }

    // method overloading
    public static double Add(double val1, double val2)
    {
      return val1 + val2;
    }

    public static float Add(float val1, float val2)
    {
      return val1 + val2;
    }

    public static double Add(double val1, double val2, double val3)
    {
      return val1 + val2 + val3;
    }

  }


}