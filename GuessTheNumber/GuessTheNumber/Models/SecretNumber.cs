using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum Outcome
{
    Indefinite,
    Low = 1,
    High = 100,
    Correct,
    NoMoreGuesses,
    PreviousGuess
}

namespace GuessTheNumber.Models
{
    public class SecretNumber
    {
        // Defining the fields that will be used.
        private int _number;
        private List<int> _previousGuesses = new List<int>();
        public const int MaxNumberOfGuesses = 8;
    }
}