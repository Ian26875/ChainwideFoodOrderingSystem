namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs;

public class CqrsOutput<T> : CqrsOutput
{
    public T Id { get; set; }


    public static CqrsOutput<T> Succeed()
    {
        return new CqrsOutput<T>
        {
            ExitCode = ExitCode.Success
        };
    }

    public static CqrsOutput<T> Fail()
    {
        return new CqrsOutput<T>
        {
            ExitCode = ExitCode.Failure
        };
    }
    
    public CqrsOutput<T> WithId(T id)
    {
        this.Id = id;
        return this;
    }
}