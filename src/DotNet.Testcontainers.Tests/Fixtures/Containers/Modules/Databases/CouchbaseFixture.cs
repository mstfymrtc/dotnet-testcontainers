namespace DotNet.Testcontainers.Tests.Fixtures.Containers.Modules.Databases
{
  using System.Threading.Tasks;
  using DotNet.Testcontainers.Containers.Builders;
  using DotNet.Testcontainers.Containers.Configurations.Databases;
  using DotNet.Testcontainers.Containers.Modules.Databases;
  using Xunit;

  public class CouchbaseFixture : ModuleFixture<CouchbaseTestcontainer>, IAsyncLifetime
  {
    public CouchbaseFixture()
      : base(new TestcontainersBuilder<CouchbaseTestcontainer>()
        .WithDatabase(new CouchbaseTestcontainerConfiguration
        {
          Username = "Administrator",
          Password = "password",
          BucketName = "customers",
          ClusterRamSize = "384",
          ClusterIndexRamSize = "256",
          ClusterFtsRamSize = "256",
          ClusterEventingRamSize = "256",
          ClusterAnalyticsRamSize = "1024"
        })
        .WithPortBinding(8091)
        .WithPortBinding(8093)
        .WithPortBinding(11210)
        .Build())
    {
    }

    public Task InitializeAsync()
    {
      return this.Container.StartAsync();
    }

    public Task DisposeAsync()
    {
      return this.Container.DisposeAsync().AsTask();
    }
  }
}
