﻿// This file is part of Hangfire.
// Copyright © 2013-2014 Sergey Odinokov.
// 
// Hangfire is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3 
// of the License, or any later version.
// 
// Hangfire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with Hangfire. If not, see <http://www.gnu.org/licenses/>.

using System;
using Hangfire.Annotations;
using Hangfire.Client;
using Hangfire.Common;
using Hangfire.States;

namespace Hangfire
{
    /// <summary>
    /// Provides methods for creating all the types of background jobs and 
    /// changing their states.
    /// </summary>
    /// 
    /// <remarks>
    /// <para><i>Background job</i> is a job in a certain state that can be 
    /// processed outside of the process in which it was created.
    /// </para>
    /// </remarks>
    /// 
    /// <seealso cref="BackgroundJobClient"/>
    public interface IBackgroundJobClient
    {
        /// <summary>
        /// Creates a background job based on a given information in a
        /// specified state.
        /// </summary>
        /// 
        /// <param name="job">Job that will be created.</param>
        /// <param name="state">The initial state of the job.</param>
        /// <returns>The unique identifier of the created job.</returns>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="job"/> argument is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="state"/> argument is null.</exception>
        /// <exception cref="CreateJobFailedException">Job creation has been failed due to inner exception.</exception>
        string Create([NotNull] Job job, [NotNull] IState state);

        /// <summary>
        /// Changes state of a job with the given <paramref name="jobId"/> to
        /// the specified one. If <paramref name="fromState"/> value is not null,
        /// state change will be performed only if the current state name of a job equal 
        /// to the given value.
        /// </summary>
        /// 
        /// <param name="jobId">Identifier of job, whose state is being changed.</param>
        /// <param name="state">New state for a job.</param>
        /// <param name="fromState">Current state assertion, or null if unneeded.</param>
        /// <returns>True, if state change succeeded and a job filter did not request another state, otherwise false.</returns>
        bool ChangeState([NotNull] string jobId, [NotNull] IState state, [CanBeNull] string fromState);
    }
}