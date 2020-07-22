namespace FeatureToggles.Api.Tests.Controllers
{
    using FeatureToggles.Api.Controllers;
    using System;
    using Xunit;
    using Moq;
    using FeatureToggles.Api.Services;
    using FeatureToggles.Api.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TenantOverridesControllerTests
    {
        private TenantOverridesController _testClass;
        private TenantOverridesService _tenantOverridesService;
        private IMapper _mapper;
        private ILogger<TenantOverridesController> _logger;

        public TenantOverridesControllerTests()
        {
            _tenantOverridesService = new TenantOverridesService(new FeatureTogglesContext(new DbContextOptions<FeatureTogglesContext>()), new Mock<ILogger<TenantOverridesService>>().Object);
            _mapper = new Mock<IMapper>().Object;
            _logger = new Mock<ILogger<TenantOverridesController>>().Object;
            _testClass = new TenantOverridesController(_tenantOverridesService, _mapper, _logger);
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new TenantOverridesController(_tenantOverridesService, _mapper, _logger);
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullTenantOverridesService()
        {
            Assert.Throws<ArgumentNullException>(() => new TenantOverridesController(default(TenantOverridesService), new Mock<IMapper>().Object, new Mock<ILogger<TenantOverridesController>>().Object));
        }

        [Fact]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new TenantOverridesController(new TenantOverridesService(new FeatureTogglesContext(new DbContextOptions<FeatureTogglesContext>()), new Mock<ILogger<TenantOverridesService>>().Object), default(IMapper), new Mock<ILogger<TenantOverridesController>>().Object));
        }

        [Fact]
        public void CannotConstructWithNullLogger()
        {
            Assert.Throws<ArgumentNullException>(() => new TenantOverridesController(new TenantOverridesService(new FeatureTogglesContext(new DbContextOptions<FeatureTogglesContext>()), new Mock<ILogger<TenantOverridesService>>().Object), new Mock<IMapper>().Object, default(ILogger<TenantOverridesController>)));
        }

        [Fact]
        public async Task CanCallGetTenantOverridesWithNoParameters()
        {
            var result = await _testClass.GetTenantOverrides();
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public async Task CanCallGetTenantOverridesWithTenantId()
        {
            var tenantId = new Guid("f024992a-72ee-484f-b7d5-62d05b0a9708");
            var result = await _testClass.GetTenantOverrides(tenantId);
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public async Task CanCallPutTenantOverride()
        {
            var tenantId = new Guid("580097d9-37d1-464c-aeea-7954186579a3");
            var tenantOverride = new TenantOverride { TenantId = new Guid("6f18524b-f806-4226-ac4e-1c359d3e5273"), Tenant = new Tenant { Id = new Guid("bf93fdb3-cfcb-486e-8747-a1f0a9825c0d"), Name = "TestValue1720484434", TenantOverrides = new Mock<ICollection<TenantOverride>>().Object }, FeatureId = new Guid("12a222e8-4393-4db8-8cee-9b5e5932c6aa"), Feature = new Feature { Id = new Guid("ac055b76-b4ed-4244-8088-a111ef3d9831"), Name = "TestValue292425254", Enabled = true, ProductId = new Guid("9ff26876-3c7d-435d-9bc5-decbf3ede216"), Product = new Product { Id = new Guid("e4638521-cabd-44fc-b051-982d992a9176"), Name = "TestValue1504302547", Features = new Mock<ICollection<Feature>>().Object }, TenantOverrides = new Mock<ICollection<TenantOverride>>().Object }, Enabled = true };
            var result = await _testClass.PutTenantOverride(tenantId, tenantOverride);
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public void CannotCallPutTenantOverrideWithNullTenantOverride()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PutTenantOverride(new Guid("8f1d2c9d-8b22-4cf1-b18e-5f140800960e"), default(TenantOverride)));
        }

        [Fact]
        public async Task CanCallPostTenantOverride()
        {
            var tenantOverride = new TenantOverride { TenantId = new Guid("a8b8a57e-d75f-4714-9bfc-a03278dd46d0"), Tenant = new Tenant { Id = new Guid("a2dd1dbd-d794-437b-b8b1-e77f7acfda50"), Name = "TestValue660646157", TenantOverrides = new Mock<ICollection<TenantOverride>>().Object }, FeatureId = new Guid("d075d0e7-d247-428a-bac0-aaa29fbd9643"), Feature = new Feature { Id = new Guid("5e845796-55c1-4717-b719-5a5eeef63a2a"), Name = "TestValue1031673991", Enabled = false, ProductId = new Guid("ee6d47c9-7277-4e75-b9d0-8f709b8bd34b"), Product = new Product { Id = new Guid("2d613605-5ef2-4aaa-8a01-cebb7c200020"), Name = "TestValue643275534", Features = new Mock<ICollection<Feature>>().Object }, TenantOverrides = new Mock<ICollection<TenantOverride>>().Object }, Enabled = false };
            var result = await _testClass.PostTenantOverride(tenantOverride);
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public void CannotCallPostTenantOverrideWithNullTenantOverride()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PostTenantOverride(default(TenantOverride)));
        }

        [Fact]
        public async Task CanCallDeleteTenantOverride()
        {
            var tenantId = new Guid("99c9fdaa-3844-48d7-8bbf-4677cd939ecb");
            var featureId = new Guid("5b46600b-51b9-4bf7-9e81-436a0d05c18f");
            var result = await _testClass.DeleteTenantOverride(tenantId, featureId);
            Assert.True(false, "Create or modify test");
        }
    }
}