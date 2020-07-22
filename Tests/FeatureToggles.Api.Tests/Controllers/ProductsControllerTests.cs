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

    public class ProductsControllerTests
    {
        private ProductsController _testClass;
        private IProductsService _productService;
        private IMapper _mapper;
        private ILogger<ProductsController> _logger;

        public ProductsControllerTests()
        {
            _productService = new Mock<IProductsService>().Object;
            _mapper = new Mock<IMapper>().Object;
            _logger = new Mock<ILogger<ProductsController>>().Object;
            _testClass = new ProductsController(_productService, _mapper, _logger);
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new ProductsController(_productService, _mapper, _logger);
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullProductService()
        {
            Assert.Throws<ArgumentNullException>(() => new ProductsController(default(IProductsService), new Mock<IMapper>().Object, new Mock<ILogger<ProductsController>>().Object));
        }

        [Fact]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new ProductsController(new Mock<IProductsService>().Object, default(IMapper), new Mock<ILogger<ProductsController>>().Object));
        }

        [Fact]
        public void CannotConstructWithNullLogger()
        {
            Assert.Throws<ArgumentNullException>(() => new ProductsController(new Mock<IProductsService>().Object, new Mock<IMapper>().Object, default(ILogger<ProductsController>)));
        }

        [Fact]
        public async Task CanCallGetProducts()
        {
            var result = await _testClass.GetProducts();
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public async Task CanCallGetProduct()
        {
            var id = new Guid("abc6b984-d1ba-4f0b-961f-5ecd937d772e");
            var result = await _testClass.GetProduct(id);
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public async Task CanCallPutProduct()
        {
            var id = new Guid("8c2368f9-3c68-42b1-8b18-b8f787e80570");
            var product = new ProductViewModel { Id = new Guid("f444fe6b-db9b-4eaf-b3a0-87d8f504dfa6"), Name = "TestValue484984954", Features = new Mock<ICollection<FeatureViewModel>>().Object };
            var result = await _testClass.PutProduct(id, product);
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public void CannotCallPutProductWithNullProduct()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PutProduct(new Guid("2ca4d60b-6afb-4fc0-8104-39bdf374282b"), default(ProductViewModel)));
        }

        [Fact]
        public async Task CanCallPostProduct()
        {
            var product = new ProductViewModel { Id = new Guid("5eddd243-46df-47c5-a204-d1612b4382b0"), Name = "TestValue888537358", Features = new Mock<ICollection<FeatureViewModel>>().Object };
            var result = await _testClass.PostProduct(product);
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public void CannotCallPostProductWithNullProduct()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.PostProduct(default(ProductViewModel)));
        }

        [Fact]
        public async Task CanCallDeleteProduct()
        {
            var id = new Guid("d9f3aa25-610e-441f-8589-5f32216d8fc2");
            var result = await _testClass.DeleteProduct(id);
            Assert.True(false, "Create or modify test");
        }
    }
}