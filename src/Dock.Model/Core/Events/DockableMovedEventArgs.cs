﻿/*
 * Dock A docking layout system.
 * Copyright (C) 2023  Wiesław Šoltés
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Affero General Public License for more details.
 *
 * You should have received a copy of the GNU Affero General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
using System;

namespace Dock.Model.Core.Events;

/// <summary>
/// Dockable moved event args.
/// </summary>
public class DockableMovedEventArgs : EventArgs
{
    /// <summary>
    /// Gets moved dockable.
    /// </summary>
    public IDockable? Dockable { get; }

    /// <summary>
    /// Initializes new instance of the <see cref="DockableMovedEventArgs"/> class.
    /// </summary>
    /// <param name="dockable">The moved dockable.</param>
    public DockableMovedEventArgs(IDockable? dockable)
    {
        Dockable = dockable;
    }
}
