using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SecretNumber
/// </summary>
public class SecretNumber
{
    private List<int> _guessedNumbers = new List<int>();
    private int _number;
    public const int MaxNumberOfGuesses = 7;
    public int ValueCheck;

    public SecretNumber()
    {
        Initialize();
    }

    public void Initialize()
    {
        Random random = new Random();
        _number = random.Next(1, 101);
        CanMakeGuess = true;
        Count = 0;
        ValueCheck = 0;
        //_guessedNumbers.Clear();

        //for (int i = 0; i < MaxNumberOfGuesses; i++)
        //{
        //    _guessedNumbers.Add(0);
        //}
    }

    public bool MakeGuess(int number)
    {
        // Lägger in senaste gissningen i korrekt arrayplats samt ökning av Count efter att detta gjorts.
        if (Count < MaxNumberOfGuesses)
            _guessedNumbers.Add(number);

        Count++;
        // Kastning av undantag då gissningen hamnar utanför intervallet.
        if (number < 1 || number > 100)
            throw new ArgumentOutOfRangeException();

        // Kastning av undantag då för många gissningar görs (fler än de tillåtna antalet 7).
        if (Count > MaxNumberOfGuesses)
        {
            Count = MaxNumberOfGuesses;
            CanMakeGuess = false;
            throw new ApplicationException();
        }

        // Kontroll vid sista gissningen, och utskrifter beroende på om sista gissningen var rätt eller fel.
        if (Count == MaxNumberOfGuesses)
        {
            CanMakeGuess = false;
            if (number == _number)
            {
                return true;
            }
            else
                return false;  
        }

        // Loop för att undersöka om gissningen gjorts tidigare, om så är fallet räknas inte denna gissning och användaren får en ny chans.
        for (int i = 0; i < (Count - 1); i++)
        {
            if (number == _guessedNumbers[i])
            {
                Count--;
                return false;
            }
        }

        // Kontroll om användaren gissat rätt.
        if (number == _number)
        {
            CanMakeGuess = false;
            return true;
        }
        else if (number > _number)
        {
            ValueCheck = 0;
            return false;
        }
        else if (number < _number)
        {
            ValueCheck = 101;
            return false;
        }
        else
            return false;
    }

    // Egenskaper
    public int Number
    {
        get 
        { 
            return _number; 
        }
    }

    public bool CanMakeGuess
    {
        get;
        private set;
    }
    public int Count
    {
        get;
        private set;
    }
    public int GuessesLeft
    {
        get
        {
            return (MaxNumberOfGuesses - Count);
        }
    }
    public ReadOnlyCollection<int> GuessedNumbers
    {
        get
        {
            ReadOnlyCollection<int> _guesses = new ReadOnlyCollection<int>(_guessedNumbers);
            return _guesses;
        }
    }
}