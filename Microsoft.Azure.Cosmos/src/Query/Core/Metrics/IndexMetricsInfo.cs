﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace Microsoft.Azure.Cosmos.Query.Core.Metrics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Azure.Cosmos.Core;
    using Microsoft.Azure.Cosmos.Core.Utf8;
    using Newtonsoft.Json;

    /// <summary>
    /// Query index utilization metrics in the Azure Cosmos database service.
    /// </summary>
#if INTERNAL
#pragma warning disable SA1600
#pragma warning disable CS1591
    public
#else
    internal
#endif
    sealed class IndexMetricsInfo
    {
        public static readonly IndexMetricsInfo Empty = new IndexMetricsInfo(
            utilizedEntity: null,
            potentialEntity: null);

        /// <summary>
        /// Initializes a new instance of the Index Metrics class.
        /// </summary>
        /// <param name="utilizedEntity">The utilized indexes</param>
        /// <param name="potentialEntity">The potential indexes</param>
        [JsonConstructor]
        public IndexMetricsInfo(
             IndexMetricsInfoEntity utilizedEntity,
             IndexMetricsInfoEntity potentialEntity)
        {
            this.UtilizedEntity = utilizedEntity ?? IndexMetricsInfoEntity.Empty;
            this.PotentialEntity = potentialEntity ?? IndexMetricsInfoEntity.Empty;
        }

        [JsonProperty("Utilized")]
        public IndexMetricsInfoEntity UtilizedEntity { get; }
        [JsonProperty("Potential")]
        public IndexMetricsInfoEntity PotentialEntity { get; }
        /// <summary>
        /// Gets or Sets the resulting index advice from the back end advice.
        /// </summary>
        /// <value>
        /// The backend response for Index Metrics V2, after being URL decoded
        /// </value>
        public string ResponseText { get; set; }

        /// <summary>
        /// Creates a new IndexMetricsInfo from the backend delimited string.
        /// </summary>
        /// <param name="delimitedString">The backend delimited string to deserialize from.</param>
        /// <param name="result">The parsed index utilization info</param>
        /// <returns>A new IndexMetricsInfo from the backend delimited string.</returns>
        internal static bool TryCreateFromString(string delimitedString, out IndexMetricsInfo result)
        {
            if (delimitedString == null)
            {
                result = IndexMetricsInfo.Empty;
                return true;
            }

            try
            {
                // Decode and deserialize the response string
                string decodedString = System.Web.HttpUtility.UrlDecode(delimitedString, Encoding.UTF8);

                result = JsonConvert.DeserializeObject<IndexMetricsInfo>(decodedString, new JsonSerializerSettings()
                {
                    // Allowing null values to be resilient to Json structure change
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    // Ignore parsing error encountered in deserialization
                    Error = (sender, parsingErrorEvent) => parsingErrorEvent.ErrorContext.Handled = true
                }) ?? IndexMetricsInfo.Empty;

                // Save the raw decoded response in the IndexMetricsInfo object
                result.ResponseText = decodedString;

                return true;
            }
            catch (JsonException)
            {
                result = IndexMetricsInfo.Empty;
                return false;
            }
        }
    }
}
