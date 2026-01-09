/*
 * Matcherate It! - an AvaloniaUI port of Head First C#'s Animal Matching
 * Game in Linux.
 * Copyright (C) 2025 Justine Ang
 *
 * File: EmojiAnimal.cs
 * Purpose: An implemention of IEmoji.cs that generates random animal emoji
 * within the range of \U+1F417 (boar) to \U+1F43C (panda).
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchGame.Core;

public class EmojiAnimal : IEmoji
{
    /**
     * A boar emoji.
     */
    private const int LowerBound = 0x1F417;
    
    /**
     * A panda emoji.
     */
    private const int UpperBound = 0x1F43C;

    /**
     * Specifies the number of unique emoji we have to generate.
     */
    private const byte UniqueSelection = 8;

    /**
     * Icons to guess.
     */
    public List<string> Icons { get; } = [];

    public EmojiAnimal()
    {
        // Create a list of indexes for us to pick up to randomly.
        var indexes = Enumerable.Range(LowerBound, UpperBound - LowerBound).ToList();

        /*
         * Pick a random emoji from boar (\U+1F417) to panda (\U+1F43C)
         * then add it as a pair to our Icon collection. Afterward, remove that index
         * from our indexes so we don't pick it more than we need.
         */
        for (byte i = 0; i < UniqueSelection; i++)
        {
            var index = Randomizer.Instance.Next(UniqueSelection);
            Icons.AddRange([char.ConvertFromUtf32(indexes[index]), char.ConvertFromUtf32(indexes[index])]);
        
            indexes.RemoveAt(index);
        }
    }
}