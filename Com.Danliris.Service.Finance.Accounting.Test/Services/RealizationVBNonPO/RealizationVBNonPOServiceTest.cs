﻿using Com.Danliris.Service.Finance.Accounting.Lib;
using Com.Danliris.Service.Finance.Accounting.Lib.BusinessLogic.Services.RealizationVBNonPO;
using Com.Danliris.Service.Finance.Accounting.Lib.Models.VbNonPORequest;
using Com.Danliris.Service.Finance.Accounting.Lib.Services.HttpClientService;
using Com.Danliris.Service.Finance.Accounting.Lib.Services.IdentityService;
using Com.Danliris.Service.Finance.Accounting.Test.DataUtils.RealizationVBNonPO;
using Com.Danliris.Service.Finance.Accounting.Test.Helpers;
using Com.Danliris.Service.Finance.Accounting.WebApi.Controllers.v1.RealizationVBNonPO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.Danliris.Service.Finance.Accounting.Test.Services.RealizationVBNonPO
{
    public class RealizationVBNonPOServiceTest
    {
        private const string ENTITY = "RealizationVbs";

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return string.Concat(sf.GetMethod().Name, "_", ENTITY);
        }

        private FinanceDbContext GetDbContext(string testName)
        {
            DbContextOptionsBuilder<FinanceDbContext> optionsBuilder = new DbContextOptionsBuilder<FinanceDbContext>();
            optionsBuilder
                .UseInMemoryDatabase(testName)
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            FinanceDbContext dbContext = new FinanceDbContext(optionsBuilder.Options);

            return dbContext;
        }

        private Mock<IServiceProvider> GetServiceProviderMock()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(IIdentityService)))
                .Returns(new IdentityService() { Token = "Token", Username = "Test", TimezoneOffset = 7 });


            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Validate_All_Null_Data()
        {
            var viewModel = new RealizationVbNonPOViewModel();

            Assert.True(viewModel.Validate(null).Count() > 0);
        }

        [Fact]
        public void Should_Success_Validate_All_Null_ObjectProperty()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var viewModel = dataUtil.GetNewViewModelFalse();

            Assert.True(viewModel.Validate(null).Count() > 0);
        }

        [Fact]
        public void Should_Success_Validate_All_Null_ObjectProperty2()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var viewModel = dataUtil.GetNewViewModelFalse2();

            Assert.True(viewModel.Validate(null).Count() > 0);
        }

        //[Fact]
        //public void Should_Success_Validate_Date_Failed_ObjectProperty()
        //{
        //    var dbContext = GetDbContext(GetCurrentMethod());
        //    var serviceProviderMock = GetServiceProviderMock();
        //    var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
        //    var dataUtil = new RealizationVBNonPODataUtil(service);
        //    var viewModel = dataUtil.GetNewViewModelDateFalse();

        //    Assert.True(viewModel.Validate(null).Count() > 0);
        //}

        //[Fact]
        //public void Should_Success_Validate_Date_Success_ObjectProperty()
        //{
        //    var dbContext = GetDbContext(GetCurrentMethod());
        //    var serviceProviderMock = GetServiceProviderMock();
        //    var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
        //    var dataUtil = new RealizationVBNonPODataUtil(service);
        //    var viewModel = dataUtil.GetNewViewModelDateTrue();

        //    Assert.True(viewModel.Validate(null).Count() > 0);
        //}

        [Fact]
        public async Task Should_Success_Create_Model()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var modelToCreate = dataUtil.GetNewData();
            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();
            var viewmodel = dataUtil.GetNewViewModel();
            var result = await service.CreateAsync(modelToCreate, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Create_Model2()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var modelToCreate = dataUtil.GetNewData();
            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();
            var viewmodel = dataUtil.GetNewViewModel2();
            var result = await service.CreateAsync(modelToCreate, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Create_Model3()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var modelToCreate = dataUtil.GetNewData();
            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();
            var viewmodel = dataUtil.GetNewViewModel3();
            var result = await service.CreateAsync(modelToCreate, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Create_Model4()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var modelToCreate = dataUtil.GetNewData();
            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();
            var viewmodel = dataUtil.GetNewViewModel4();
            var result = await service.CreateAsync(modelToCreate, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Create_Model5()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var modelToCreate = dataUtil.GetNewData();
            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();
            var viewmodel = dataUtil.GetNewViewModel5();
            var result = await service.CreateAsync(modelToCreate, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Mapping()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var modelToCreate = dataUtil.GetNewData();
            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();
            var viewmodel = dataUtil.GetNewViewModel5();
            var viewmodel1 = dataUtil.GetNewViewModel6();
            await service.CreateAsync(modelToCreate, viewmodel);

            var result = await service.MappingData(viewmodel1);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Update_Model()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            //var modelToUpdate = await dataUtil.GetCreatedData();
            var viewmodel = dataUtil.GetNewViewModel();
            viewmodel.Items.Add(new VbNonPORequestDetailViewModel()
            {
                DateDetail = DateTimeOffset.Now,
                Amount = 123,
                Remark = "Remark",
                isGetPPn = true
            });

            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();

            var result = await service.UpdateAsync(viewmodel.Id, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Update_Model2()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var viewmodel = dataUtil.GetNewViewModel();
            viewmodel.Items.Add(new VbNonPORequestDetailViewModel()
            {
                DateDetail = DateTimeOffset.Now,
                Amount = 123,
                Remark = "Remark",
                isGetPPn = false
            });

            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();

            var result = await service.UpdateAsync(viewmodel.Id, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Update_Model3()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var viewmodel = dataUtil.GetNewViewModelNew();
            viewmodel.Items.Add(new VbNonPORequestDetailViewModel()
            {
                DateDetail = DateTimeOffset.Now,
                Amount = 0,
                Remark = "Remark",
                isGetPPn = false
            });

            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();

            var result = await service.UpdateAsync(viewmodel.Id, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Update_Model4()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var viewmodel = dataUtil.GetNewViewModelNew();
            viewmodel.Items.Add(new VbNonPORequestDetailViewModel()
            {
                DateDetail = DateTimeOffset.Now,
                Amount = -1000,
                Remark = "Remark",
                isGetPPn = false
            });

            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();

            var result = await service.UpdateAsync(viewmodel.Id, viewmodel);

            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task Should_Success_Update_Model5()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var viewmodel = dataUtil.GetNewViewModelNew();
            viewmodel.Items.Add(new VbNonPORequestDetailViewModel()
            {
                DateDetail = DateTimeOffset.Now,
                Amount = -1000,
                Remark = "Remark",
                isGetPPn = false
            });

            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();

            var viewmodel1 = dataUtil.GetNewViewModel6();

            await service.MappingData(viewmodel1);

            var result = await service.UpdateAsync(viewmodel.Id, viewmodel);

            Assert.NotEqual(0, result);
        }

        //[Fact]
        //public async Task Should_Success_Update_Model6()
        //{
        //    var dbContext = GetDbContext(GetCurrentMethod());
        //    var serviceProviderMock = GetServiceProviderMock();
        //    var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
        //    var dataUtil = new RealizationVBNonPODataUtil(service);
        //    var viewmodel = dataUtil.GetNewViewModelNew();
        //    viewmodel.Items.Add(new VbNonPORequestDetailViewModel()
        //    {
        //        DateDetail = DateTimeOffset.Now,
        //        Amount = 1000,
        //        Remark = "Remark",
        //        isGetPPn = false
        //    });

        //    var dataRequestVb = dataUtil.GetDataRequestVB();
        //    dbContext.VbRequests.Add(dataRequestVb);
        //    dbContext.SaveChanges();

        //    var viewmodel1 = dataUtil.GetNewViewModel6();

        //    await service.MappingData(viewmodel1);

        //    var result = await service.UpdateAsync(viewmodel.Id, viewmodel);

        //    Assert.NotEqual(0, result);
        //}

        [Fact]
        public async Task Should_Success_UpdateAsync_When_Data_Exist()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var modelToCreate = dataUtil.GetNewData();
            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();
            var viewmodel = dataUtil.GetNewViewModel5();

            var viewmodelnew = dataUtil.GetNewViewModelNew1();
            viewmodelnew.Items.Add(new VbNonPORequestDetailViewModel()
            {
                DateDetail = DateTimeOffset.Now,
                Amount = 1000,
                Remark = "Remark",
                isGetPPn = false
            });

            var viewmodel1 = dataUtil.GetNewViewModel6();
            await service.CreateAsync(modelToCreate, viewmodel);

            await service.MappingData(viewmodel1);
            var result = await service.UpdateAsync(modelToCreate.Id, viewmodelnew);

            Assert.NotEqual(0, result);
        }

        //[Fact]
        //public async Task Should_Success_UpdateAsync_When_Data_NoExist()
        //{
        //    var dbContext = GetDbContext(GetCurrentMethod());
        //    var serviceProviderMock = GetServiceProviderMock();
        //    var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
        //    var dataUtil = new RealizationVBNonPODataUtil(service);
        //    var modelToCreate = dataUtil.GetNewData();
        //    var dataRequestVb = dataUtil.GetDataRequestVB();
        //    dbContext.VbRequests.Add(dataRequestVb);
        //    dbContext.SaveChanges();
        //    dbContext.VbRequestsDetails.Add(new VbRequestDetailModel());
        //    dbContext.SaveChanges();
        //    var viewmodel = dataUtil.GetNewViewModel5();

        //    var viewmodelnew = dataUtil.GetNewViewModelNew1();
        //    viewmodelnew.Items.Add(new VbNonPORequestDetailViewModel()
        //    {
        //        DateDetail = DateTimeOffset.Now,
        //        Amount = 1000,
        //        Remark = "Remark",
        //        isGetPPn = false
        //    });

        //    var viewmodel1 = dataUtil.GetNewViewModel6();
        //    await service.CreateAsync(modelToCreate, viewmodel);

        //    await service.MappingData(viewmodel1);
        //    viewmodel.Id = 1;
        //    var result = await service.UpdateAsync(modelToCreate.Id, viewmodel);

        //    Assert.NotEqual(0, result);
        //}


        [Fact]
        public async Task Should_Success_Read_Data()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            await dataUtil.GetCreatedData();

            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();

            var result = service.Read(1, 10, "{}", new List<string>(), "", "{}");

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Should_Success_Read_ById()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();
            var data = await dataUtil.GetCreatedData();
            var result = await service.ReadByIdAsync2(data.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Success_Delete_ById()
        {
            var dbContext = GetDbContext(GetCurrentMethod());
            var serviceProviderMock = GetServiceProviderMock();
            var service = new RealizationVbNonPOService(dbContext, serviceProviderMock.Object);
            var dataUtil = new RealizationVBNonPODataUtil(service);
            var data = await dataUtil.GetCreatedData();

            var dataRequestVb = dataUtil.GetDataRequestVB();
            dbContext.VbRequests.Add(dataRequestVb);
            dbContext.SaveChanges();

            var result = await service.DeleteAsync(data.Id);

            Assert.NotEqual(0, result);
        }
    }
}