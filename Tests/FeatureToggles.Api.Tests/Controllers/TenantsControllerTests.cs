namespace FeatureToggles.Api.Tests.Controllers
{
    using FeatureToggles.Api.Controllers;
    using System;
    using Xunit;
    using Moq;
    using FeatureToggles.Api.Services.Interfaces;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using FeatureToggles.Api.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TenantsControllerTests
    {
        private TenantsController _testClass;
        private ITenantsService _tenantService;
        private IMapper _mapper;
        private ILogger<TenantsController> _logger;

        public TenantsControllerTests()
        {
            _tenantService = new Mock<ITenantsService>().Object;
            _mapper = new Mock<IMapper>().Object;
            _logger = new Mock<ILogger<TenantsController>>().Object;
            _testClass = new TenantsController(_tenantService, _mapper, _logger);
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new TenantsController(_tenantService, _mapper, _logger);
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullTenantService()
        {
            Assert.Throws<ArgumentNullException>(() => new TenantsController(default(ITenantsService), new Mock<IMapper>().Object, new Mock<ILogger<TenantsController>>().Object));
        }

        [Fact]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new TenantsController(new Mock<ITenantsService>().Object, default(IMapper), new Mock<ILogger<TenantsController>>().Object));
        }

        [Fact]
        public void CannotConstructWithNullLogger()
        {
            Assert.Throws<ArgumentNullException>(() => new TenantsController(new Mock<ITenantsService>().Object, new Mock<IMapper>().Object, default(ILogger<TenantsController>)));
        }

        [Fact]
        public async Task CanCallGetTenants()
        {
            var result = await _testClass.GetTenants();
            
        }

        [Fact]
        public async Task CanCallGetTenant()
        {
            var id = new Guid("b2511ff3-024d-43e2-817f-15dc28eff5ef");
            var result = await _testClass.GetTenant(id);
            
        }

        [Fact]
        public async Task CanCallPutTenant()
        {
            var id = new Guid("91618e0b-8e33-4b44-b616-757d934d2451");
            var tenant = new Tenant { Id = new Guid("1f71f64b-bcf5-40ad-9ab3-3a5ebee604a6"), Name = "TestValue2141005589", TenantOverrides = new Mock<ICollection<TenantOverride>>().Object };
            var result = await _testClass.PutTenant(id, tenant);
            
        }

        [Fact]
        public void CannotCallPutTenantWithNullTenant()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PutTenant(new Guid("f0b446a2-e0ec-4570-854f-647492d72982"), default(Tenant)));
        }

        //[Fact]
        //public async Task CanCallPostTenant()
        //{
        //    var tenant = new Tenant { Id = new Guid("399dd33f-ecf8-4b23-a721-51654f99bdc4"), Name = "TestValue1854321915", TenantOverrides = new Mock<ICollection<TenantOverride>>().Object };
        //    var result = await _testClass.PostTenant(tenant);
        //}

        [Fact]
        public void CannotCallPostTenantWithNullTenant()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PostTenant(default(Tenant)));
        }

        [Fact]
        public async Task CanCallDeleteTenant()
        {
            var id = new Guid("277c85e8-c393-4c6b-bf64-47bae1083d6d");
            var result = await _testClass.DeleteTenant(id);
            
        }
    }
}