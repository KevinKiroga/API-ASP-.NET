namespace School.Modules.Student.BO.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        Task CommitAsync();
        void Commit();
        Task ContextClear();
    }
}
