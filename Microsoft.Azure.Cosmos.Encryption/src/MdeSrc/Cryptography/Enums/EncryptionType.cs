//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

// This file isn't generated, but this comment is necessary to exclude it from StyleCop analysis.
// <auto-generated/>

namespace Microsoft.Data.Encryption.Cryptography
{
    /// <summary>
    /// The type of data encryption.
    /// </summary>
    /// <remarks>
    /// The three encryption types are Plaintext Deterministic and Randomized. Plaintext unencrypted data. 
    /// Deterministic encryption always generates the same encrypted value for any given plain text value. 
    /// Randomized encryption uses a method that encrypts data in a less predictable manner. Randomized encryption is more secure.
    /// </remarks>
    internal enum EncryptionType
    {
        /// <summary>
        /// Plaintext unencrypted data.
        /// </summary>
        Plaintext,

        /// <summary>
        /// Deterministic encryption always generates the same encrypted value for any given plain text value.
        /// </summary>
        Deterministic,

        /// <summary>
        /// Randomized encryption uses a method that encrypts data in a less predictable manner. Randomized encryption is more secure.
        /// </summary>
        Randomized
    }
}
