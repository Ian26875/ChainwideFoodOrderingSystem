namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;

public class CqrsOutput : Output
{
    public ExitCode ExitCode { get; set; }

    public string Message { get; set; }
    
    public CqrsOutput() 
    {
       this.ExitCode=ExitCode.Success;
       this.Message = string.Empty;
    }

    public CqrsOutput WithMessage(string message)
    {
        this.Message = message;
        return this;
    }

    public static CqrsOutput Succeed()
    {
        return new CqrsOutput
        {
            ExitCode = ExitCode.Success
        };
    }
    
    public static CqrsOutput Fail()
    {
        return new CqrsOutput
        {
            ExitCode = ExitCode.Failure
        };
    }
}