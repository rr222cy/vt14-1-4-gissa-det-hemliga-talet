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
        protected void Page_Load(object sender, EventArgs e)
        {
            // If the HTML5-focus attribute fails, awesomeness saves the day.
            NumberGuessTextBox.Focus();
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                GuessStatusLabel.Text = "För högt!";
            }
            // Wow, such awesome!
        }

        protected void NewNumberButton_Click(object sender, EventArgs e)
        {
            // Much click.
        }
    }
}