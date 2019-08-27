﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Avalonia.Markup.Xaml;
using Dock.Model;

namespace Dock.Avalonia.Controls
{
    /// <summary>
    /// Includes a <see cref="IDock"/> object from a URL.
    /// </summary>
    public class LayoutIncludeExtension
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="LayoutIncludeExtension"/> class.
        /// </summary>
        public LayoutIncludeExtension()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutIncludeExtension"/> class.
        /// </summary>
        /// <param name="uriString">The base uri string.</param>
        public LayoutIncludeExtension(string uriString)
        {
            Source = new Uri(uriString);
        }

        private Uri GetContextBaseUri(IServiceProvider serviceProvider)
        {
            return ((IUriContext)(serviceProvider.GetService(typeof(IUriContext)))).BaseUri;
        }

        /// <summary>
        /// Provides a <see cref="IDock"/> value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The new <see cref="IDock"/> instance.</returns>
        public IDock ProvideValue(IServiceProvider serviceProvider)
        {
            var loader = new AvaloniaXamlLoader();
            var baseUri = GetContextBaseUri(serviceProvider);
            return (IDock)loader.Load(Source, baseUri);
        }

        /// <summary>
        /// Gets or sets the source URL.
        /// </summary>
        public Uri Source { get; set; }
    }
}