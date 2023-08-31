using CodingTracker;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddDbContext<CodingTrackerContext>()
    
    .AddTransient<UserValidation>()
    .AddTransient<UserInterface>()
    .AddTransient<CodingTrackerRepository>()
    .AddTransient<Controller>()
    .BuildServiceProvider();

var controller = serviceProvider.GetRequiredService<Controller>();

DatabaseInitializer.InitializeDatabase();
controller.Run();