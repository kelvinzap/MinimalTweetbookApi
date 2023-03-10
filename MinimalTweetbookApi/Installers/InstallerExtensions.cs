namespace MinimalTweetbookApi.Installers;

public static class InstallerExtensions
{
    public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
    {
        var installers = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller)
                .IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false })
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();
        
        installers.ForEach(x => x.InstallServices(configuration, services));
    }
}