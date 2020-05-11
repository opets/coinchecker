namespace CC.Base.Configuration
{
    public interface IConfigurationProvider
    {
        string AuthToken { get; }

        string BaseUrl { get; }

        string[] ExcludeCurrencies { get; }
    }
}