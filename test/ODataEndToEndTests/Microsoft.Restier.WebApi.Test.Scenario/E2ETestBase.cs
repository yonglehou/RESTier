﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using Microsoft.OData.Client;

namespace Microsoft.Restier.WebApi.Test.Scenario
{
    /// <summary>
    /// Summary description for E2ETestBase
    /// </summary>
    public class E2ETestBase<TDSC> where TDSC : DataServiceContext
    {
        protected Uri ServiceBaseUri { get; set; }
        public TDSC TestClientContext;
        public E2ETestBase(Uri serviceBaseUri)
        {
            this.ServiceBaseUri = serviceBaseUri;
            TestClientContext = Activator.CreateInstance(typeof(TDSC), this.ServiceBaseUri) as TDSC;
            ResetDataSource();
        }

        private void ResetDataSource()
        {
            this.TestClientContext.Execute(new Uri("/ResetDataSource", UriKind.Relative), "POST");
        }
    }
}
