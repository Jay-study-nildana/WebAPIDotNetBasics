namespace SimpleCalculatorWebAPI.Interfaces
{
    public class MathOperationsOne : IMathOperations
    {
        public double Add(double firstnumber, double secondnumber)
        {
            return firstnumber + secondnumber;
        }

        public double Div(double firstnumber, double secondnumber)
        {
            return (firstnumber / secondnumber);
        }

        public double Mul(double firstnumber, double secondnumber)
        {
            return firstnumber * secondnumber;
        }

        public double Sub(double firstnumber, double secondnumber)
        {
            return firstnumber - secondnumber;
        }
    }
}
