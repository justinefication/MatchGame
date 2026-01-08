using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace MatchGame;

public partial class MainWindow : Window
{
    /**
     * Timer
     */
    private DispatcherTimer _timer;

    private int _tenthOfSecondsElapsed;
    
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
    
    public MainWindow()
    {
        InitializeComponent();

        foreach (var textBlock in MainGrid.Children.OfType<TextBlock>())
        {
            // Add our event handler during game setup instead of in 
            // our AXAML file.
            textBlock.PointerPressed += TextBlock_PointerPressed;
        }
        
        _timer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(.1)
        };
        _timer.Tick += UpdateTimer;
        
        SetupGame();

        TimerTextBlock.PointerPressed += TimerTextBlock_PointerPressed;
    }

    /**
     * Set up our matching  game by filling each box
     * with a random icon and delegating an event handler
     * to each box to respond to our clicks.
     */
    private void SetupGame()
    {
        var animals = new List<string>()
        {
            "\U0001F43C", "\U0001F43C",    // Panda
            "\U0001F425", "\U0001F425",    // Chicken
            "\U0001F437", "\U0001F437",    // Pig
            "\U0001F435", "\U0001F435",    // Monkey
            "\U0001F431", "\U0001F431",    // Cat
            "\U0001F436", "\U0001F436",    // Dog
            "\U0001F43B", "\U0001F43B",    // Bear
            "\U0001F430", "\U0001F430",    // Rabbit
        };

        var random = new Random();

        foreach (var textBlock in MainGrid.Children.OfType<TextBlock>())
        {
            var next = (byte) random.Next(animals.Count);
            
            textBlock.Text = animals[next];
            animals.RemoveAt(next);
            
            textBlock.IsVisible = true;
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