namespace pc2.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}