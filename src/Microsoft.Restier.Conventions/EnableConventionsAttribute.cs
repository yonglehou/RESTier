﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using Microsoft.Restier.Core;

namespace Microsoft.Restier.Conventions
{
    /// <summary>
    /// Specifies that code-based conventions will be enabled for a domain.
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EnableConventionsAttribute : DomainParticipantAttribute
    {
        /// <inheritdoc/>
        public override void Configure(
            DomainConfiguration configuration,
            Type type)
        {
            configuration.EnableConventions(type);
        }

        /// <inheritdoc/>
        public override void Initialize(
            DomainContext context,
            Type type, object instance)
        {
            Ensure.NotNull(context);
            Ensure.NotNull(type);
            context.SetProperty(type.AssemblyQualifiedName, instance);
        }
    }
}
