using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManoharanV_ASSN03_GuessAWord
{
    public partial class Form1 : Form
    {
        string word = "";
        string strWordGuessedSoFar = "";
        string guesses = "";

        public Form1()
        {
            InitializeComponent();
            txtWord.Focus();
        }

        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            btnConfirm.Focus();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            btnGuess.Enabled = true;
            btnFinishRound.Enabled = true;

            word = txtWord.Text;
            txtGuess.Focus();
            lblDisplay.Text = "This word has " + word.Count() + " letters.";

            for (int i = 0; i < word.Length; i++)
            {
                strWordGuessedSoFar = strWordGuessedSoFar.PadLeft(word.Length, '*');
            }
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            string guess = txtGuess.Text;
            guesses += guess + " , ";
            txtGuess.Text = "";
            txtGuess.Focus();
            CheckLetter(guess);
        }


        private void CheckLetter(string guess)
        {
            string[] wordArray = new string[word.Count()];
            int count = 0;


            for (int i = 0; i < word.Count(); i++)
            {
                wordArray[i] = word.Substring(i, 1);
                if (wordArray[i] == guess)
                {
                    count += 1;
                    strWordGuessedSoFar = strWordGuessedSoFar.Remove(i, 1);
                    strWordGuessedSoFar = strWordGuessedSoFar.Insert(i, guess);
                }
            }

            lblDisplay.Text += Environment.NewLine + "The letter " + guess + " appears " + count + " times.";

            if (word == strWordGuessedSoFar)
            {
                btnGuess.Enabled = false;
                btnFinishRound.Focus();
                lblDisplay.Text += Environment.NewLine + Environment.NewLine + "Winner! You have guessed all the letters. The word was:" + Environment.NewLine + word;
            }
        }

        private void btnFinishRound_Click(object sender, EventArgs e)
        {
            DisplayLettersGuessed(guesses);
        }

        private void DisplayLettersGuessed(object guess)
        {
            MessageBox.Show("Letters Guessed: " + guesses, "Round Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblDisplay.Text = "";
            txtGuess.Text = "";
            btnFinishRound.Enabled = false;
            btnGuess.Enabled = false;
            btnConfirm.Enabled = true;       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }     
}