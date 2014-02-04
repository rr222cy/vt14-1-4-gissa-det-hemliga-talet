using System;
using System.Collections;
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

            // Checking if a session with a randomized number has been created and set, if not it will be.
            if (RandomNumber == null)
            {
                RandomNumber = new SecretNumber();
            }

            // Preventing the user from double-posting, or closing/opening window and re-enabling controls.
            if (RandomNumber.CanMakeGuess == false)
            {
                DisableInput();
            }
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            // If everything validates we start the awesome.
            if (IsValid)
            {
                // Making the guess, than presenting the result for the user.
                var guessResult = RandomNumber.MakeGuess(Int32.Parse(NumberGuessTextBox.Text));

                // Looping out the previous guesses and presents them for the user.
                foreach (int i in RandomNumber.PreviousGuesses)
                {
                    GuessesLabel.Text += i.ToString() + " ";
                }

                if (guessResult == Outcome.High)
                {
                    GuessStatusLabel.Text = "För högt!" + RandomNumber.Number;    
                }
                else if (guessResult == Outcome.Low)
                {
                    GuessStatusLabel.Text = "För lågt!";
                }
                else if (guessResult == Outcome.Correct)
                {
                    GuessStatusLabel.Text = String.Format("Rätt! Du klarade det på {0} försök!", RandomNumber.Count);
                    DisableInput();
                }
                else if (guessResult == Outcome.NoMoreGuesses)
                {
                    GuessStatusLabel.Text = String.Format("Inga gissningar kvar. Det hemliga talet var {0}.", RandomNumber.Number);
                    DisableInput();
                }
            }   
        }

        public void DisableInput()
        {
            GuessButton.Enabled = false;
            NumberGuessTextBox.Enabled = false;
            NewNumberButton.Visible = true;
        }

        protected void NewNumberButton_Click(object sender, EventArgs e)
        {
            GuessButton.Enabled = true;
            NumberGuessTextBox.Enabled = true;
            NewNumberButton.Visible = false;
            NumberGuessTextBox.Text = "";
            RandomNumber.Initialize();
        }
    }
}