namespace FeatureToggles.Api.Tests.ViewModels
{
    using FeatureToggles.Api.ViewModels;
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;

    public class TenantOverrideViewModelTests
    {
        private readonly TenantOverrideViewModel _testClass;

        public TenantOverrideViewModelTests()
        {
            _testClass = new TenantOverrideViewModel();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new TenantOverrideViewModel();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetTenantId()
        {
            var testValue = new Guid("3b889219-5a06-425d-95f6-63e160971934");
            _testClass.TenantId = testValue;
            Assert.Equal(testValue, _testClass.TenantId);
        }

        [Fact]
        public void CanSetAndGetTenant()
        {
            var testValue = new TenantViewModel { Id = new Guid("b122e1db-92fa-4976-9451-03c9e0a6c82f"), Name = "TestValue512117265", TenantOverrides = new Mock<ICollection<TenantOverrideViewModel>>().Object };
            _testClass.Tenant = testValue;
            Assert.Equal(testValue, _testClass.Tenant);
        }

        [Fact]
        public void CanSetAndGetFeatureId()
        {
            var testValue = new Guid("c56d9530-923d-4009-b7a3-86f8db15824c");
            _testClass.FeatureId = testValue;
            Assert.Equal(testValue, _testClass.FeatureId);
        }

        [Fact]
        public void CanSetAndGetFeature()
        {
            var testValue = new FeatureViewModel { Id = new Guid("013d949a-c30f-4ee8-8d79-45373dc69712"), Name = "TestValue195833786", Enabled = false, ProductId = new Guid("82b0f022-4f8c-4b11-9795-1373fb562f2f"), TenantOverrides = new Mock<ICollection<TenantOverrideViewModel>>().Object };
            _testClass.Feature = testValue;
            Assert.Equal(testValue, _testClass.Feature);
        }

        [Fact]
        public void CanSetAndGetEnabled()
        {
            var testValue = true;
            _testClass.Enabled = testValue;
            Assert.Equal(testValue, _testClass.Enabled);
        }
    }
}