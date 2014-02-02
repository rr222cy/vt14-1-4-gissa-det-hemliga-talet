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
        public bool CanMakeGuess { get; }
        public int Count { get; }
        public int? Number { get; }
        public Outcome Outcome { get; set; }
        public IEnumerable<int> PreviousGuesses
        {
            get { return _previousGuesses; }
        }

        // The methods for the class.
        public void Initialize()
        {

        }

        public Outcome MakeGuess(int guess)
        {
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

        // The constructors for the class.
        public SecretNumber()
        {

        }
    }
}