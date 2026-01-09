# An AvaloniaUI port of Head First C#'s Match Game

> Original source from the book can be found
> [here](https://github.com/head-first-csharp/fourth-edition/tree/master/Code/Chapter_1/MatchGame).

Since the original material uses Windows Presentation Foundation (WPF), I have implemented the game
in [AvaloniaUI](https://avaloniaui.net/) - an open-source WPF successor for building
beautiful, cross-platform .NET apps in order to follow through with the book.

## Improvements made over the book

- Remove repeated properties from TextBlocks and defined them in a Grid style.

```xaml
<Grid.Styles>
    <Style Selector="TextBlock">
        <Setter Property="FontSize" Value="36" />
        ...
    </Style>
</Grid.Styles>
```

- Added factory classes to generate different kinds of emojis every time the game start.

```
project
|--- Core
     |--- Factory
          |--- EmojiAnimalFactory.CS
          |--- EmojiFactory.cs
          |--- EmojiNatureFactory.CS
          |--- EmojiSmileyFactory.CS
     |--- EmojiAnimal.cs
     |--- EmojiNature.cs
     |--- Emojismiley.cs
     |--- IEmoji.cs
```

- Created a single point of randomization for all factory classes and game setup to use in
  order to avoid highly predictable and non-uniform distribution of values.

```csharp
public sealed class Randomizer
{
    /**
     * An instance of Randomizer singleton.
     */
    private static Randomizer? _instance = null;
    ...
}
```