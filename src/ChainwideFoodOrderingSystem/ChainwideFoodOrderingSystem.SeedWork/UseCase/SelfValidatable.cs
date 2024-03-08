using System.ComponentModel.DataAnnotations;

namespace ChainwideFoodOrderingSystem.SeedWork.UseCase;

/// <summary>
/// The self validatable class
/// </summary>
public abstract class SelfValidatable
{
    /// <summary>
    /// Ensures the valid
    /// </summary>
    protected void EnsureValid()
    {
        var validationContext = new ValidationContext(this);

        Validator.ValidateObject(this, validationContext);
    }
}