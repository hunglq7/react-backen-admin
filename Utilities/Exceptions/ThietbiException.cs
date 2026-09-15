namespace WebApi.Utilities.Exceptions
{
    public class ThietbiException:Exception
    {
        public ThietbiException()
        {

        }
        public ThietbiException(string message) : base(message) { }
        public ThietbiException(string message,Exception inner):base(message, inner) { }
    }
}
