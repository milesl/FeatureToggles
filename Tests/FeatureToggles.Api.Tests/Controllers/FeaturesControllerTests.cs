namespace FeatureToggles.Api.Tests.Controllers
{
    using FeatureToggles.Api.Controllers;
    using System;
    using Xunit;
    using Moq;
    using FeatureToggles.Api.Services.Interfaces;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using FeatureToggles.Api.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FeaturesControllerTests
    {
        private FeaturesController _testClass;
        private IFeaturesService _featuresService;
        private IMapper _mapper;
        private ILogger<FeaturesController> _logger;

        public FeaturesControllerTests()
        {
            _featuresService = new Mock<IFeaturesService>().Object;
            _mapper = new Mock<IMapper>().Object;
            _logger = new Mock<ILogger<FeaturesController>>().Object;
            _testClass = new FeaturesController(_featuresService, _mapper, _logger);
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new FeaturesController(_featuresService, _mapper, _logger);
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullFeaturesService()
        {
            Assert.Throws<ArgumentNullException>(() => new FeaturesController(default(IFeaturesService), new Mock<IMapper>().Object, new Mock<ILogger<FeaturesController>>().Object));
        }

        [Fact]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new FeaturesController(new Mock<IFeaturesService>().Object, default(IMapper), new Mock<ILogger<FeaturesController>>().Object));
        }

        [Fact]
        public void CannotConstructWithNullLogger()
        {
            Assert.Throws<ArgumentNullException>(() => new FeaturesController(new Mock<IFeaturesService>().Object, new Mock<IMapper>().Object, default(ILogger<FeaturesController>)));
        }

        [Fact]
        public async Task CanCallGetFeatures()
        {
            var result = await _testClass.GetFeatures();
            
        }

        [Fact]
        public async Task CanCallGetFeature()
        {
            var id = new Guid("1f85b1ba-67da-4ed3-ab39-9687868adb5d");
            var result = await _testClass.GetFeature(id);
            
        }

        //[Fact]
        //public async Task CanCallPutFeature()
        //{
        //    var id = new Guid("4441cf17-42a2-4a8b-8a77-da7d5719991c");
        //    var feature = new FeatureViewModel { Id = new Guid("4b56c069-e590-432e-b597-569550792baa"), Name = "TestValue142407068", Enabled = true, ProductId = new Guid("f57a0045-ca6e-42bc-a327-b0b26efa47b7"), TenantOverrides = new Mock<ICollection<TenantOverrideViewModel>>().Object };
        //    var result = await _testClass.PutFeature(id, feature);
            
        //}

        [Fact]
        public void CannotCallPutFeatureWithNullFeature()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PutFeature(new Guid("156b36fe-a7cc-4ccd-87d7-a5eedcfaddee"), default(FeatureViewModel)));
        }

        //[Fact]
        //public async Task CanCallPostFeature()
        //{
        //    var feature = new FeatureViewModel { Id = new Guid("fc336433-39ba-4a4b-a63c-77605bf39d4f"), Name = "TestValue1946229377", Enabled = false, ProductId = new Guid("477736f6-3fd5-49cf-ad8b-add7c1989044"), TenantOverrides = new Mock<ICollection<TenantOverrideViewModel>>().Object };
        //    var result = await _testClass.PostFeature(feature);
            
        //}

        [Fact]
        public void CannotCallPostFeatureWithNullFeature()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PostFeature(default(FeatureViewModel)));
        }

        [Fact]
        public async Task CanCallDeleteFeature()
        {
            var id = new Guid("04897e13-8d86-4831-b12b-9008d12d0e96");
            var result = await _testClass.DeleteFeature(id);
            
        }
    }
}