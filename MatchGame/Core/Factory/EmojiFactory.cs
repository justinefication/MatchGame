/*
 * Matcherate It! - an AvaloniaUI port of Head First C#'s Animal Matching
 * Game in Linux.
 * Copyright (C) 2025 Justine Ang
 *
 * File: EmojiFactory.cs
 * Purpose: Provides an abstract method that all Factory classes can implement
 * to create a specific product of type IEmoji.
 */

namespace MatchGame.Core.Factory;

public abstract class EmojiFactory
{
    public abstract IEmoji CreateEmoji();
}