using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private SecretNumber newNumber
    {
        get
        {
            return Session["newGuess"] as SecretNumber;
        }
        set
        {
            Session["newGuess"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RetryButton.Visible = false;
        GuessButton.Visible = true;
    }
    protected void GuessButton_Click(object sender, EventArgs e)
    {
        int guess = int.Parse(GuessBox.Text);
        SecretNumber number = new SecretNumber();

        if (newNumber == null)
            newNumber = number;

        if (Page.IsValid)
        {
            if (newNumber.MakeGuess(guess))
            {
                result.InnerText = "Du gissade rätt! Det hemliga talet var " + newNumber.Number + "!" ;
                GuessButton.Visible = false;
                RetryButton.Visible = true;
            }
            else
            {
                result.InnerText = "Du gissade fel, försök igen! Du har " + newNumber.GuessesLeft + " gissningar kvar!";

                if (guess > newNumber.ValueCheck)
                {
                    result.InnerText = result.InnerText + " Din senaste gissning var för hög!";
                }
                else if (guess < newNumber.ValueCheck)
                {
                    result.InnerText = result.InnerText + " Din senaste gissning var för låg!";
                }

                if (!(newNumber.CanMakeGuess))
                {
                    result.InnerText = "Du har tyvärr slut på gissningar! Det hemliga talet var " + newNumber.Number + "!";
                    GuessButton.Visible = false;
                    RetryButton.Visible = true;
                }
            }

            guesses.InnerText = "Dina gissningar: ";
            foreach (int i in newNumber.GuessedNumbers)
            {
                guesses.InnerText = guesses.InnerText + i + ", ";
            }
        }
    }
    protected void RetryButton_Click(object sender, EventArgs e)
    {
        newNumber = null;
        result.InnerText = "";
        guesses.InnerText = "";
    }
}