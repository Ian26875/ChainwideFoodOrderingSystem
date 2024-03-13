using System.ComponentModel.DataAnnotations;

namespace ChainwideFoodOrderingSystem.SeedWork.UseCase;

/// <summary>
/// The self validatable class
/// </summary>
public abstract class SelfValidating
{
    /// <summary>
    /// Ensures the valid
    /// </summary>
    protected void ValidateSelf()
    {
        var validationContext = new ValidationContext(this);

        Validator.ValidateObject(this, validationContext);
    }
}