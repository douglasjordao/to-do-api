using System.ComponentModel.DataAnnotations;

namespace Utils
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {
            Errors = new List<string>();
        }

        public ValidationException(IList<ValidationResult> validationResults)
            : this()
        {
            foreach (var result in validationResults)
            {
                if (result.ErrorMessage != null)
                {
                    Errors.Add(result.ErrorMessage);
                }
            }
        }

        public ValidationException(IList<string> errors)
        {
            Errors = errors;
        }

        public IList<string> Errors { get; set; }
    }
}