/*
 * Matcherate It! - an AvaloniaUI port of Head First C#'s Animal Matching
 * Game in Linux.
 * Copyright (C) 2025 Justine Ang
 *
 * File: EmojiNature.cs
 * Purpose: An implemention of IEmoji.cs that generates random nature emoji
 * within the range of \U+1F330 (chestnut) to \U+1F353 (strawberry).
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchGame.Core;

public class EmojiNature : IEmoji
{
    /**
     * A chestnut emoji.
     */
    private const int LowerBound = 0x1F330;
    
    /**
     * A strawberry emoji.
     */
    private const int UpperBound = 0x1F353;

    /**
     * Specifies the number of unique emoji we have to generate.
     */
    private const byte UniqueSelection = 8;

    /**
     * Randomizes our selection of emojis.
     */
    private readonly Random _randomizer = new Random();

    /**
     * Icons to guess.
     */
    public List<string> Icons { get; } = [];

    public EmojiNature()
    {
        // Create a list of indexes from chestnut to strawberry
        // emoji for us to pick up to randomly.
        var indexes = Enumerable.Range(LowerBound, (UpperBound - LowerBound)).ToList();

        /*
         * Pick a random emoji from chestnut (\U+1F330) to strawberry (\U+1F353)
         * then add it as a pair to our Icon collection. Afterward, remove that index
         * from our indexes so we don't pick it more than we need.
         */
        for (byte i = 0; i < UniqueSelection; i++)
        {
            var index = _randomizer.Next(UniqueSelection);
            Icons.AddRange([char.ConvertFromUtf32(indexes[index]), char.ConvertFromUtf32(indexes[index])]);
        
            indexes.RemoveAt(index);
        }
    }
}