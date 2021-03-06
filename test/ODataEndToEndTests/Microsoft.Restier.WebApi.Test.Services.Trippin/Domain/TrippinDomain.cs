﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using Microsoft.Restier.Conventions;
using Microsoft.Restier.Core;
using Microsoft.Restier.EntityFramework;
using Microsoft.Restier.WebApi.Test.Services.Trippin.Models;

namespace Microsoft.Restier.WebApi.Test.Services.Trippin.Domain
{
    [Test]
    public class TrippinDomain : DbDomain<TrippinModel>
    {
        public TrippinDomain()
            :base()
        {
        }
        public TrippinModel Context { get { return DbContext; } }
        /// <summary>
        /// Implements an action import.
        /// </summary>
        [Action]
        public void ResetDataSource()
        {
            TrippinModel.ResetDataSource();
        }
    }

    public class TestAttribute : DomainParticipantAttribute
    {
        private EnableConventionsAttribute enableConventionsAttribute = new EnableConventionsAttribute();

        public override void Configure(
            DomainConfiguration configuration,
            Type type)
        {
            enableConventionsAttribute.Configure(configuration, type);
            ConventionalActionProvider.ApplyTo(configuration, type);
        }

        public override void Initialize(DomainContext context, Type type, object instance)
        {
            enableConventionsAttribute.Initialize(context, type, instance);
        }
    }
}