using AssignmentAgiblocks.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AssignmentAgiblocks_xUnit_Tests
{
    public class CustomerControllerTest
    {
        private ServiceProvider _serviceProvider;
        static readonly string dummyContentData = $"CounterPartID, Name, IsBuyer, IsSeller, Phone, Fax{Environment.NewLine}B10001,Test Company 1,Yes,No,3165656667,319889808";

        public CustomerControllerTest()
        {
            _serviceProvider = new ServiceProviderTest().ServiceProvider;
        }

        public IFormFile MockFile()
        {
            var fileMock = new Mock<IFormFile>();
            var fileName = "test.csv";
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(dummyContentData);
            writer.Flush();
            memoryStream.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(memoryStream);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(memoryStream.Length);

            return fileMock.Object;
        }

        [Fact]
        public async Task Upload_File_Single()
        {
            //Arrange 
            var customerService = _serviceProvider.GetService<ICustomerService>();
            var file = MockFile();

            //Act
            await customerService.UploadFile(file);
            var customers = await customerService.GetAllCustomers();

            //Assert
            Assert.Single(customers);
        }

        [Fact]
        public async Task Remove_By_Id_FirstOrDefault()
        {
            //Arrange
            var customerService = _serviceProvider.GetService<ICustomerService>();
            var file = MockFile();
            await customerService.UploadFile(file);
            var customers = await _serviceProvider.GetService<ICustomerService>().GetAllCustomers();

            //Act
            await customerService.RemoveCustomer(customers.FirstOrDefault().CustomerId);
            customers = await _serviceProvider.GetService<ICustomerService>().GetAllCustomers();
            //Assert
            Assert.Empty(customers);
        }
    }
}
