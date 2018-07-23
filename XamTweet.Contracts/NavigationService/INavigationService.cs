namespace XamTweet.Contracts
{
    public interface INavigationService
    {
        void LoadMainView<T>() where T : class, IViewModel;
    }
}