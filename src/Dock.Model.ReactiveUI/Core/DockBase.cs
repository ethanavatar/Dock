﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System.Collections.Generic;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Dock.Model
{
    /// <summary>
    /// Dock base class.
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class DockBase : DockableBase, IDock
    {
        private INavigateAdapter _navigateAdapter;
        private IList<IDockable> _visible;
        private IList<IDockable> _hidden;
        private IList<IDockable> _pinned;
        private IDockable _currentDockable;
        private IDockable _defaultDockable;
        private IDockable _focusedDockable;
        private double _proportion = double.NaN;
        private bool _isCollapsable = true;
        private bool _isActive;
        private IList<IDockWindow> _windows;
        private IFactory _factory;

        /// <summary>
        /// Initializes new instance of the <see cref="DockBase"/> class.
        /// </summary>
        public DockBase()
        {
            _navigateAdapter = new NavigateAdapter(this);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IList<IDockable> Visible
        {
            get => _visible;
            set => this.RaiseAndSetIfChanged(ref _visible, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IList<IDockable> Hidden
        {
            get => _hidden;
            set => this.RaiseAndSetIfChanged(ref _hidden, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IList<IDockable> Pinned
        {
            get => _pinned;
            set => this.RaiseAndSetIfChanged(ref _pinned, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IDockable CurrentDockable
        {
            get => _currentDockable;
            set
            {
                this.RaiseAndSetIfChanged(ref _currentDockable, value);
                this.RaisePropertyChanged(nameof(CanGoBack));
                this.RaisePropertyChanged(nameof(CanGoForward));
                _factory?.SetFocusedDockable(this, value);
            }
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IDockable DefaultDockable
        {
            get => _defaultDockable;
            set => this.RaiseAndSetIfChanged(ref _defaultDockable, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IDockable FocusedDockable
        {
            get => _focusedDockable;
            set => this.RaiseAndSetIfChanged(ref _focusedDockable, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public double Proportion
        {
            get => _proportion;
            set => this.RaiseAndSetIfChanged(ref _proportion, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public bool IsActive
        {
            get => _isActive;
            set => this.RaiseAndSetIfChanged(ref _isActive, value);
        }

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public bool IsCollapsable
        {
            get => _isCollapsable;
            set => this.RaiseAndSetIfChanged(ref _isCollapsable, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public bool CanGoBack => _navigateAdapter?.CanGoBack ?? false;

        /// <inheritdoc/>
        [IgnoreDataMember]
        public bool CanGoForward => _navigateAdapter?.CanGoForward ?? false;

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public IList<IDockWindow> Windows
        {
            get => _windows;
            set => this.RaiseAndSetIfChanged(ref _windows, value);
        }

        /// <inheritdoc/>
        [IgnoreDataMember]
        public IFactory Factory
        {
            get => _factory;
            set => this.RaiseAndSetIfChanged(ref _factory, value);
        }

        /// <inheritdoc/>
        public virtual void GoBack()
        {
            _navigateAdapter?.GoBack();
        }

        /// <inheritdoc/>
        public virtual void GoForward()
        {
            _navigateAdapter?.GoForward();
        }

        /// <inheritdoc/>
        public virtual void Navigate(object root)
        {
            _navigateAdapter?.Navigate(root, true);
        }

        /// <inheritdoc/>
        public virtual void ShowWindows()
        {
            _navigateAdapter?.ShowWindows();
        }

        /// <inheritdoc/>
        public virtual void ExitWindows()
        {
            _navigateAdapter?.ExitWindows();
        }

        /// <inheritdoc/>
        public virtual void Close()
        {
            _navigateAdapter?.Close();
        }
    }
}