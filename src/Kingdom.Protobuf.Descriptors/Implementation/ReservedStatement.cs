﻿using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once IdentifierTypo
namespace Kingdom.Protobuf
{
    using Collections;
    using static String;

    /// <summary>
    /// 
    /// </summary>
    /// <inheritdoc cref="DescriptorBase" />
    public abstract class ReservedStatement
        : DescriptorBase
            , IReservedStatement
            , IMessageBodyItem
    {
        private IParentItem _parent;

        IMessageBodyParent IHasParent<IMessageBodyParent>.Parent
        {
            get => _parent as IMessageBodyParent;
            set => _parent = value;
        }
    }

    /// <inheritdoc cref="ReservedStatement" />
    public abstract class ReservedStatement<T>
        : ReservedStatement
            , IReservedStatement<T>
        where T : IHasParent<IReservedStatement>
    {
        private IList<T> _items;

        /// <inheritdoc />
        public IList<T> Items
        {
            get => _items ?? (_items = new BidirectionalList<T>(
                       onAdded: x => x.Parent = this, onRemoved: x => x.Parent = null)
                   );
            set
            {
                _items?.Clear();
                _items = new BidirectionalList<T>(value ?? GetRange<T>().ToList()
                    , onAdded: x => x.Parent = this, onRemoved: x => x.Parent = null
                );
            }
        }

        /// <summary>
        /// Renders the <paramref name="item"/>.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract string RenderItem(T item, IStringRenderingOptions options);

        /// <inheritdoc />
        public override string ToDescriptorString(IStringRenderingOptions options)
        {
            string RenderItems() => Join(", ", Items.Select(x => RenderItem(x, options)));
            const string reserved = nameof(reserved);
            return $"{reserved} {RenderItems()};";
        }
    }
}
