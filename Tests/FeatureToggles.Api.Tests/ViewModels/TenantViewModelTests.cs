namespace FeatureToggles.Api.Tests.ViewModels
{
    using FeatureToggles.Api.ViewModels;
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;

    public class TenantViewModelTests
    {
        private readonly TenantViewModel _testClass;

        public TenantViewModelTests()
        {
            _testClass = new TenantViewModel();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new TenantViewModel();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            var testValue = new Guid("16edc4cb-b45d-40be-a37b-1727a26ab070");
            _testClass.Id = testValue;
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            var testValue = "TestValue1234941268";
            _testClass.Name = testValue;
            Assert.Equal(testValue, _testClass.Name);
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