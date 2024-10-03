namespace SimpleCalculatorWebAPI.Interfaces
{
    public interface IMathOperations
    {
        public double Add(double firstnumber,double secondnumber);
        public double Sub(double firstnumber, double secondnumber);
        public double Mul(double firstnumber, double secondnumber);
        public double Div(double firstnumber, double secondnumber);
    }
}
