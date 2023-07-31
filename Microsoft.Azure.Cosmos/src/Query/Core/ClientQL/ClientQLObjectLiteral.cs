﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Azure.Cosmos.Query.Core.ClientQL
{
    internal class ClientQLObjectLiteral : ClientQLLiteral
    {
        public List<ClientQLObjectLiteral> VecProperties { get; set; }
    }
}