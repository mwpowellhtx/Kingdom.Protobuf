﻿// ReSharper disable once IdentifierTypo
namespace Kingdom.Protobuf
{
    /// <inheritdoc cref="ICanRenderString"/>
    public interface IPackageStatement : IDescriptor
    {
        /// <summary>
        /// Gets or Sets the PackagePath.
        /// </summary>
        IdentifierPath PackagePath { get; set; }
    }
}
