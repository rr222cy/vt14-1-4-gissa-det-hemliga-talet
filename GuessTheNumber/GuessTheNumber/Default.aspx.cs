using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuessTheNumber
{
    public partial class Default : System.Web.UI.Page
    {
        private int? RandomNumber
        {
            get { return Session["randomNumber"] as int?; }
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
                if (RandomNumber.HasValue)
                {
                    GuessStatusLabel.Text = "För högt!"; 
                }
                else
                {
                    RandomNumber = 1;
                }
            }   
        }

        protected void NewNumberButton_Click(object sender, EventArgs e)
        {
            // Much click.
        }
    }
}