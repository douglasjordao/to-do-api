namespace Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException()
        : base()
        {
        }

        public RecordNotFoundException(string errorMessage)
        : base(errorMessage)
        {
        }
    }
}