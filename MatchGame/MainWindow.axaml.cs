using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using MatchGame.Core;
using MatchGame.Core.Factory;

namespace MatchGame;

public partial class MainWindow : Window
{
    /**
     * Stores the <see cref="TextBlock"/> last selected
     * by our player.
     */
    private TextBlock? _lastTextBlock;
    
    /**
     * Determines whether we are looking for a matching
     * icon or not.
     */
    private bool _findingMatch = false;

    private byte _matchFound = 0;
    
    private int _tenthOfSecondsElapsed;
    
    /**
     * Timer
     */
    private DispatcherTimer _timer;

    public MainWindow()
    {
        InitializeComponent();

        foreach (var textBlock in MainGrid.Children.OfType<TextBlock>())
        {
            // Add our event handler during game setup instead of in 
            // our AXAML file.
            textBlock.PointerPressed += TextBlock_PointerPressed;
        }
        
        // Setup Game Timer
        _timer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(.1)
        };
        _timer.Tick += UpdateTimer;
        TimerTextBlock.PointerPressed += TimerTextBlock_PointerPressed;
        
        SetupGame();
    }

    /**
     * Set up our matching  game by filling each box
     * with a random icon and delegating an event handler
     * to each box to respond to our clicks.
     */
    private void SetupGame()
    {
        string[] categories = ["Animals", "Nature", "Smileys"];
        var selectedCategory = (byte) Randomizer.Instance.Next(categories.Length);

        EmojiFactory emojiFactory;
        switch (categories[selectedCategory])
        {
            case "Animals":
                emojiFactory = new EmojiAnimalFactory();
                break;
            case "Nature":
                emojiFactory = new EmojiNatureFactory();
                break;
            default:
                emojiFactory = new EmojiSmileyFactory();
                break;
        }
        var emojis = emojiFactory.CreateEmoji();
        
        // Distribute the emojis in our grid.
        foreach (var textBlock in MainGrid.Children.OfType<TextBlock>())
        {
            var next = (byte) Randomizer.Instance.Next(emojis.Icons.Count);
            
            textBlock.Text = emojis.Icons[next];
            textBlock.IsVisible = true;
            
            emojis.Icons.RemoveAt(next);
        }
        
        _timer.Start();
        _tenthOfSecondsElapsed = 0;
        _matchFound = 0;
    }

    private void TextBlock_PointerPressed(object? sender, RoutedEventArgs e)
    {
        var textBlock = sender as TextBlock;

        if (! _findingMatch)
        {
            textBlock!.IsVisible = false;
            
            _lastTextBlock = textBlock;
            _findingMatch = true;
        }
        
        else if (textBlock!.Text == _lastTextBlock!.Text)
        {
            textBlock.IsVisible = false;
            _findingMatch = false;
            _matchFound++;
        }

        else
        {
            _lastTextBlock.IsVisible = true;
            _findingMatch = false;
        }
    }

    private void TimerTextBlock_PointerPressed(object? sender, RoutedEventArgs e)
    {
        if (_matchFound == 8)
        {
            SetupGame();
        }
    }

    private void UpdateTimer(object? sender, EventArgs e)
    {
        _tenthOfSecondsElapsed++;
        TimerTextBlock.Text = (_tenthOfSecondsElapsed / 10F).ToString("0.0s");

        if (_matchFound == 8)
        {
            _timer.Stop();
            TimerTextBlock.Text += " - Play Again?";
        }
    }
}