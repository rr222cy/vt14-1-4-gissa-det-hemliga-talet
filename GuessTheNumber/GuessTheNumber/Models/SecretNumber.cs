using System;
using System.Collections;
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
        public const int MaxNumberOfGuesses = 7;

        // The properties for the class.
        public bool CanMakeGuess { get; set; }
        public int Count { get; set; }
        public int? Number 
        {
            get { return _number; }
        }
        public Outcome Outcome { get; set; }

        public IReadOnlyCollection<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }

        // The methods for the class.
        public void Initialize()
        {
            // Randomizing a number between 1 and 100.
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 101);
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
            CanMakeGuess = true;
            Count = 0;
        }

        public Outcome MakeGuess(int guess)
        {
            // Validating that the input is within range and that no more guesses than allowed has been done.
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (guess != _number && Count == MaxNumberOfGuesses - 1 || CanMakeGuess == false)
            {
                // Adds the guess to the list.
                _previousGuesses.Add(guess);
                CanMakeGuess = false;
                return Outcome.NoMoreGuesses;
            }
            else
            {
                if (PreviousGuesses.Contains(guess))
                {
                    return Outcome.PreviousGuess;
                }

                _previousGuesses.Add(guess);
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
                    CanMakeGuess = false;
                    return Outcome.Correct;
                }                             
            }                  
        }

        // The constructors for the class.
        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }
    }
}