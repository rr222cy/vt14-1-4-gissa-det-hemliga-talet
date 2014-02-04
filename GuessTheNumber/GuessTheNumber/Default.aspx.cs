using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GuessTheNumber.Models;

namespace GuessTheNumber
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber RandomNumber
        {
            get { return Session["randomNumber"] as SecretNumber; }
            set { Session["randomNumber"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // If the HTML5-focus attribute fails, awesomeness saves the day (or JavaScript).
            NumberGuessTextBox.Focus();
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            // If everything validates we start the awesome.
            if (IsValid)
            {
                // Checking if a session with a randomized number has been created and set, if not it will be.
                if (RandomNumber == null)
                {
                    RandomNumber = new SecretNumber();
                }              

                // Making the guess, than presenting the result for the user.
                var guessResult = RandomNumber.MakeGuess(Int32.Parse(NumberGuessTextBox.Text));
                if (guessResult == Outcome.High)
                {
                    GuessStatusLabel.Text = "För högt!";
                }
                else if (guessResult == Outcome.Low)
                {
                    GuessStatusLabel.Text = "För lågt!";
                }
                else if (guessResult == Outcome.Correct)
                {
                    GuessStatusLabel.Text = "Rätt!";
                    GuessButton.Enabled = false;
                    NumberGuessTextBox.Enabled = false;
                    NewNumberButton.Visible = true;
                }
                else if (guessResult == Outcome.NoMoreGuesses)
                {
                    GuessStatusLabel.Text = "Du har inga fler gissningar kvar!";
                    GuessButton.Enabled = false;
                    NumberGuessTextBox.Enabled = false;
                    NewNumberButton.Visible = true;                
                }
            }   
        }

        protected void NewNumberButton_Click(object sender, EventArgs e)
        {
            NumberGuessTextBox.Text = "";
            RandomNumber.Initialize();
        }
    }
}