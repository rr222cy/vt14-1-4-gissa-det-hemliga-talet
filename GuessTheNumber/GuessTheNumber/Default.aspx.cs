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
            get
            {
                if (Session["randomNumber"] == null)
                {
                    Session["randomNumber"] = new SecretNumber();
                    return Session["randomNumber"] as SecretNumber;
                }
                else
                {
                    return Session["randomNumber"] as SecretNumber;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // If the HTML5-focus attribute fails, awesomeness saves the day (or JavaScript).
            NumberGuessTextBox.Focus();

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
                // Makes sure a game is not already running, in that case the user will have to restart first.
                if (RandomNumber.CanMakeGuess == true)
                {
                    // Making the guess, than presenting the result for the user.
                    var guessResult = RandomNumber.MakeGuess(Int32.Parse(NumberGuessTextBox.Text));
                
                    // Looping out the previous guesses and presents them for the user.
                    foreach (int i in RandomNumber.PreviousGuesses)
                    {
                        GuessesLabel.Text += String.Format("{0} ", i);
                    }

                    if (guessResult == Outcome.High)
                    {
                        GuessStatusLabel.Text = "För högt!";
                        NumberGuessTextBox.Text = "";
                    }
                    else if (guessResult == Outcome.Low)
                    {
                        GuessStatusLabel.Text = "För lågt!";
                        NumberGuessTextBox.Text = "";
                    }
                    else if (guessResult == Outcome.PreviousGuess)
                    {
                        GuessStatusLabel.Text = "Du har redan gissat på detta tal!";
                        NumberGuessTextBox.Text = "";
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
                else
                {
                    GuessStatusLabel.Text = "Game Over. Klicka på knappen för att spela igen";
                }
            }   
        }

        // Method for enabling and disabling fields acoording to game completion.
        public void DisableInput()
        {
            GuessButton.Enabled = false;
            NumberGuessTextBox.Enabled = false;
            NewNumberButton.Visible = true;
            NewNumberButton.Focus();
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