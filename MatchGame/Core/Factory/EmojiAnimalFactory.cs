/*
 * Matcherate It! - an AvaloniaUI port of Head First C#'s Animal Matching
 * Game in Linux.
 * Copyright (C) 2025 Justine Ang
 *
 * File: EmojiAnimalFactory.cs
 * Purpose: An implemention of EmojiFactory.cs that produces a random animal emoji.
 */

namespace MatchGame.Core.Factory;

public class EmojiAnimalFactory : EmojiFactory
{
    public override IEmoji CreateEmoji()
    {
        return new EmojiAnimal();
    }
}