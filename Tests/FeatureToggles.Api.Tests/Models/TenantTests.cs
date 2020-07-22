namespace FeatureToggles.Api.Tests.Models
{
    using FeatureToggles.Api.Models;
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;

    public class TenantTests
    {
        private readonly Tenant _testClass;

        public TenantTests()
        {
            _testClass = new Tenant();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new Tenant();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            var testValue = new Guid("8d783d98-5421-4158-95db-5612e8823a2d");
            _testClass.Id = testValue;
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            var testValue = "TestValue1369685517";
            _testClass.Name = testValue;
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetTenantOverrides()
        {
            var testValue = new Mock<List<TenantOverride>>().Object;
            _testClass.TenantOverrides = testValue;
            Assert.Equal(testValue, _testClass.TenantOverrides);
        }
    }
}