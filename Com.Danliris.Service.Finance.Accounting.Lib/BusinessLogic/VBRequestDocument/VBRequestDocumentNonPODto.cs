﻿using Com.Danliris.Service.Finance.Accounting.Lib.Utilities.BaseClass;
using System;
using System.Collections.Generic;

namespace Com.Danliris.Service.Finance.Accounting.Lib.BusinessLogic.VBRequestDocument
{
    public class VBRequestDocumentNonPODto : BaseViewModel
    {
        public VBRequestDocumentNonPODto()
        {
            Items = new List<VBRequestDocumentNonPOItemDto>();
        }

        public DateTimeOffset? Date { get; set; }
        public DateTimeOffset? RealizationEstimationDate { get; set; }
        public UnitDto SuppliantUnit { get; set; }
        public CurrencyDto Currency { get; set; }
        public decimal? Amount { get; set; }
        public string Purpose { get; set; }

        public List<VBRequestDocumentNonPOItemDto> Items { get; set; }
    }
}