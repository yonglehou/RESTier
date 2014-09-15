﻿using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Data.Domain.Submit
{
    /// <summary>
    /// Represents a service that can prepare a change set.
    /// </summary>
    /// <remarks>
    /// This is a singleton hook point that should be
    /// implemented by an underlying data provider.
    /// </remarks>
    public interface IChangeSetPreparer
    {
        /// <summary>
        /// Asynchronously prepares a change set for submission.
        /// </summary>
        /// <param name="context">
        /// The submit context.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <remarks>
        /// Preparing a change set involves creating new entity objects for
        /// new data, loading entities that are pending update or delete from
        /// to get current server values, and using a data provider mechanism
        /// to locally apply the supplied changes to the loaded entities.
        /// </remarks>
        Task PrepareAsync(SubmitContext context,
            CancellationToken cancellationToken);
    }
}