namespace ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Query;

public interface IProjection<in TInput, TOutput>
{
    Task<TOutput> QueryAsync(TInput input);
}