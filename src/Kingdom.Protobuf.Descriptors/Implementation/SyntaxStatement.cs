﻿// ReSharper disable once IdentifierTypo
namespace Kingdom.Protobuf
{
    using static Characters;
    using static SyntaxKind;
    using static WhiteSpaceAndCommentOption;

    // TODO: TBD: we could call this an ISyntaxStatement just for consistency, but we will leave this alone for the time being...
    /// <inheritdoc cref="DescriptorBase" />
    public class SyntaxStatement : DescriptorBase, ISyntaxStatement
    {
        /// <inheritdoc />
        public ProtoDescriptor Parent { get; set; }

        /// <summary>
        /// Gets or Sets the Syntax.
        /// </summary>
        public SyntaxKind Syntax { get; set; } = Proto2;

        /// <inheritdoc />
        public override string ToDescriptorString(IStringRenderingOptions options)
        {
            const string syntax = nameof(syntax);

            string GetComments(params WhiteSpaceAndCommentOption[] masks)
                => RenderMaskedComments(options.WhiteSpaceAndCommentRendering, masks);

            return $"{GetComments(MultiLineComment)}"
                   + $" {syntax} "
                   + $"{GetComments(MultiLineComment)}"
                   + $" {EqualSign} "
                   + $"{GetComments(MultiLineComment)}"
                   + $" '{nameof(Proto2).ToLower()}' "
                   + $"{GetComments(MultiLineComment)}"
                   + $" {SemiColon}"
                   + $"{GetComments(MultiLineComment)} {GetComments(SingleLineComment)}"
                ;
        }
    }
}