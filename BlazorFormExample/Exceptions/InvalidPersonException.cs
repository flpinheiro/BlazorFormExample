namespace BlazorFormExample.Exceptions
{
    public class InvalidPersonException : Exception
    {
        public InvalidPersonException() : base("Invalid person data, impossible to submit")
        {
            
        }
    }
}
