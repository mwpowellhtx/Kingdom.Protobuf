﻿// ReSharper disable once IdentifierTypo
namespace Kingdom.Protobuf
{
    /// <summary>
    /// 
    /// </summary>
    /// <inheritdoc cref="DescriptorBase" />
    public class ImportStatement
        : DescriptorBase
            , IProtoBodyItem
    {
        // TODO: TBD: may refactor to base classes...
        private IParentItem _parent;

        IProto IHasParent<IProto>.Parent
        {
            get => _parent as IProto;
            set => _parent = value;
        }

        /// <summary>
        /// Gets or Sets the Modifier.
        /// </summary>
        public ImportModifierKind? Modifier { get; set; }

        /// <summary>
        /// Gets or Sets the Import Path.
        /// </summary>
        public string ImportPath { get; set; }

        /// <inheritdoc />
        public override string ToDescriptorString(IStringRenderingOptions options)
        {
            const string import = nameof(import);

            // TODO: TBD: escape delimit the string...
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (Modifier)
            {
                case null:
                    return $"{import} \"{ImportPath}\";";
                default:
                    return $"{import} {$"{Modifier.Value}".ToLower()} \"{ImportPath}\";";
            }
        }
    }
}
