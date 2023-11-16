namespace HangFire.Demo.Jobs
{
    public interface IJob
    {
        Task ExecuteAsync();
    }
}
