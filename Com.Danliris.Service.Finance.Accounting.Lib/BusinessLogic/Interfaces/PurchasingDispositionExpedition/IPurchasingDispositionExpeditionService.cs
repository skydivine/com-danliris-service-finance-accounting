﻿using Com.Danliris.Service.Finance.Accounting.Lib.Models.PurchasingDispositionExpedition;
using Com.Danliris.Service.Finance.Accounting.Lib.Utilities;
using Com.Danliris.Service.Finance.Accounting.Lib.Utilities.BaseInterface;
using Com.Danliris.Service.Finance.Accounting.Lib.ViewModels.IntegrationViewModel;
using Com.Danliris.Service.Finance.Accounting.Lib.ViewModels.PurchasingDispositionAcceptance;
using Com.Danliris.Service.Finance.Accounting.Lib.ViewModels.PurchasingDispositionReport;
using Com.Danliris.Service.Finance.Accounting.Lib.ViewModels.PurchasingDispositionVerification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Finance.Accounting.Lib.BusinessLogic.Interfaces.PurchasingDispositionExpedition
{
    public interface IPurchasingDispositionExpeditionService : IBaseService<PurchasingDispositionExpeditionModel>
    {
        Task<int> PurchasingDispositionAcceptance(PurchasingDispositionAcceptanceViewModel data);
        Task<int> DeletePurchasingDispositionAcceptance(int id);
        Task<int> PurchasingDispositionVerification(PurchasingDispositionVerificationViewModel data);
        ReadResponse<PurchasingDispositionReportViewModel> GetReport(int page, int size, string order, string filter, DateTimeOffset? dateFrom, DateTimeOffset? dateTo, int offSet);
        MemoryStream GenerateExcel(int page, int size, string order, string filter, DateTimeOffset? dateFrom, DateTimeOffset? dateTo, int offSet);
    }
}
