/*
 * Matcherate It! - an AvaloniaUI port of Head First C#'s Animal Matching
 * Game in Linux.
 * Copyright (C) 2025 Justine Ang
 *
 * File: EmojiNatureFactory.cs
 * Purpose: An implemention of EmojiFactory.cs that produces a random nature emoji.
 */

namespace MatchGame.Core.Factory;

public class EmojiNatureFactory : EmojiFactory
{
    public override IEmoji CreateEmoji()
    {
        return new EmojiNature();
    }
}