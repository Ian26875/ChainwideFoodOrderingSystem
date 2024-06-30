namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;

public class CqrsOutput : Output
{
    public CqrsOutput()
    {
        ExitCode = ExitCode.Success;
        Message = string.Empty;
    }

    public ExitCode ExitCode { get; protected set; }

    public string Message { get; protected set; }

    public CqrsOutput WithMessage(string message)
    {
        Message = message;
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