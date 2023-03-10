using MinimalTweetbookApi.Repositories;

namespace MinimalTweetbookApi.Installers;

public class EndpointsInstaller : IInstaller
{
    public void InstallServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<IPostRepository, PostRepository>();
    }
}