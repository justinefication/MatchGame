/*
 * Matcherate It! - an AvaloniaUI port of Head First C#'s Animal Matching
 * Game in Linux.
 * Copyright (C) 2025 Justine Ang
 *
 * File: Randomizer.cs
 * Purpose: Provides a single point of randomization for Matcherate It!
 */

using System;

namespace MatchGame.Core;

/**
 * Provides a shared randomizer for all randomizing.
 */
public sealed class Randomizer
{
    /**
     * An instance of Randomizer singleton.
     */
    private static Randomizer? _instance = null;
    
    /**
     * Shared object for threads to obtain lock for thread-safety.
     * This prevents two or more threads from evaluating our null-check and
     * both create an instance of our Randomizer.
     */
    private static readonly object _lock = new();

    /**
     * Internal psuedo-random number generator.
     */
    private readonly Random _randomizer = new Random();
    
    private Randomizer()
    {
    }

    /**
     * Gets an instance of <see cref="Randomizer"/>
     */
    public static Randomizer Instance
    {
        get
        {
            /*
             * Thread-safe implementation of singleton.
             *
             * The threads acquire a lock on a shared object then checks whether
             * an instance has been created already before creating an instance.
             *
             * https://csharpindepth.com/articles/singleton
             */
            lock (_lock)
            {
                _instance ??= new Randomizer();
                return _instance;
            }
        }
    }

    /**
     * Returns a non-negative random integer that is less than the specified maximum.
     */
    public int Next(int maxValue)
    {
        return _randomizer.Next(maxValue);
    }
}