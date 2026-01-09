/*
 * Matcherate It! - an AvaloniaUI port of Head First C#'s Animal Matching
 * Game in Linux.
 * Copyright (C) 2025 Justine Ang
 *
 * File: EmojiSmileyFactory.cs
 * Purpose: An implemention of EmojiFactory.cs that produces a random smiley emoji.
 */

namespace MatchGame.Core.Factory;

public class EmojiSmileyFactory : EmojiFactory
{
    public override IEmoji CreateEmoji()
    {
        return new EmojiSmiley();
    }
}