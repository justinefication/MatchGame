/*
 * Matcherate It! - an AvaloniaUI port of Head First C#'s Animal Matching
 * Game in Linux.
 * Copyright (C) 2025 Justine Ang
 *
 * File: IEmoji.cs
 * Purpose: Provide an interface that is common to all object that can be
 * produced by Factories.
 */

using System.Collections.Generic;

namespace MatchGame.Core;

public interface IEmoji
{ 
    List<string> Icons { get; }
}