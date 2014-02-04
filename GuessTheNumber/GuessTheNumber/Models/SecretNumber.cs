using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum Outcome
{
    Indefinite,
    Low,
    High,
    Correct,
    NoMoreGuesses,
    PreviousGuess
}

namespace GuessTheNumber.Models
{
    public class SecretNumber
    {
        // The fields for the class.
        private int _number;
        private List<int> _previousGuesses = new List<int>();
        public const int MaxNumberOfGuesses = 8;

        // The properties for the class.
        public bool CanMakeGuess { get; set; }
        public int Count { get; set; }
        public int? Number 
        {
            get { return _number; }
        }
        public Outcome Outcome { get; set; }
        public IEnumerable<int> PreviousGuesses
        {
            get { return _previousGuesses; }
        }

        // The methods for the class.
        public void Initialize()
        {
            // Randomizing a number between 1 and 100.
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 101);
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
            Count = 0;
        }

        public Outcome MakeGuess(int guess)
        {
            _previousGuesses.Add(guess);
            // Validating that the input is within range and that no more guesses than allowed has been done.
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (Count > MaxNumberOfGuesses - 1)
            {
                return Outcome.NoMoreGuesses;
            }
            else
            {
                // A guess has been made.
                Count += 1;

                if (guess > _number)
                {
                    return Outcome.High;
                }
                else if (guess < _number)
                {
                    return Outcome.Low;
                }
                else
                {
                    return Outcome.Correct;
                }
            }         
        }

        // The constructors for the class.
        public SecretNumber()
        {
            Initialize();
        }
    }
}