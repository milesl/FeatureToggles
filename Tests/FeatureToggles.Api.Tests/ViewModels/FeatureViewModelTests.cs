namespace FeatureToggles.Api.Tests.ViewModels
{
    using FeatureToggles.Api.ViewModels;
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;

    public class FeatureViewModelTests
    {
        private readonly FeatureViewModel _testClass;

        public FeatureViewModelTests()
        {
            _testClass = new FeatureViewModel();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new FeatureViewModel();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            var testValue = new Guid("e54142b3-1afb-468c-8a53-81bce30e3ca8");
            _testClass.Id = testValue;
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            var testValue = "TestValue1143276380";
            _testClass.Name = testValue;
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetEnabled()
        {
            var testValue = false;
            _testClass.Enabled = testValue;
            Assert.Equal(testValue, _testClass.Enabled);
        }

        [Fact]
        public void CanSetAndGetProductId()
        {
            var testValue = new Guid("49e623d8-c01e-4fb3-a2f9-c94abce00d45");
            _testClass.ProductId = testValue;
            Assert.Equal(testValue, _testClass.ProductId);
        }

        [Fact]
        public void CanSetAndGetTenantOverrides()
        {
            var testValue = new Mock<List<TenantOverrideViewModel>>().Object;
            _testClass.TenantOverrides = testValue;
            Assert.Equal(testValue, _testClass.TenantOverrides);
        }
    }
}