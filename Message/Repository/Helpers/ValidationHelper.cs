using System.ComponentModel.DataAnnotations;

namespace Notify.Services.MessageAPI.Repository.Helpers
{
	public class ValidationHelper
	{
		public static void ValidateModel(object input)
		{
			ValidationContext validationContext = new(input);
			List<ValidationResult> validationResults = new();
			bool isValid = Validator.TryValidateObject(input, validationContext,validationResults,true);
			if (!isValid)
			{
				throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
			}
		}
	}
}
