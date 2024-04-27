var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.StorySuite>("storysuite");

builder.Build().Run();
