var builder = DistributedApplication.CreateBuilder(args);

#pragma warning disable ASPIRECERTIFICATES001
var keycloak = builder.AddKeycloak("keycloak", 6001)
    .WithoutHttpsCertificate()
    .WithDataVolume("keycloak-data");
#pragma warning restore ASPIRECERTIFICATES001

builder.Build().Run();

