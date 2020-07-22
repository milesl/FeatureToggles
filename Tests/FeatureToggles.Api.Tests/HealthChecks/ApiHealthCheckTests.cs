namespace FeatureToggles.Api.Tests.HealthChecks
{
    using FeatureToggles.Api.HealthChecks;
    using System;
    using Xunit;
    using Moq;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApiHealthCheckTests
    {
        private readonly ApiHealthCheck _testClass;

        public ApiHealthCheckTests()
        {
            _testClass = new ApiHealthCheck();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new ApiHealthCheck();
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallCheckHealthAsync()
        {
            var context = new HealthCheckContext { Registration = new HealthCheckRegistration("TestValue707812089", new Mock<IHealthCheck>().Object, new HealthStatus?(), new[] { "TestValue635907740", "TestValue1896800030", "TestValue502047708" }) };
            var cancellationToken = new CancellationToken();
            var result = await _testClass.CheckHealthAsync(context, cancellationToken);
            Assert.Equal(HealthStatus.Healthy, result.Status);
        }

        [Fact]
        public void CannotCallCheckHealthAsyncWithNullContext()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CheckHealthAsync(default, new CancellationToken()));
        }
    }
}