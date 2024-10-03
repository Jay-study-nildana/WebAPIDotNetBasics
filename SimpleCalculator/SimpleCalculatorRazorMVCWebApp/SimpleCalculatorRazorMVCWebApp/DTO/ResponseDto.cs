namespace SimpleCalculatorRazorMVCWebApp.DTO
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool? Success { get; set; } = true;  //I will assume that, by default, everything went fine.
        public string? Message { get; set; } = ""; //by default, there is nothing to report. 
    }
}
