using System.Numerics;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;

namespace FullScreenGameWindows
{
    public partial class Form1 : Form
    {
        private CustomLabel customLabel;  // CustomLabel instance (Here we have added an item which is actually a class by right clicking the 'FullScreenGameWindows'
                                          //under 'solution explorar' => add => item (here named the file as 'CustomLabel.cs' & this is the new class which is added in this project , if you see in the
                                          //solution explorar window

        //Explanation:-
        //1. CustomLabel Class: This class sets up a Label with properties like Text, Font, Color, and Location.
        //   The GetLabel method returns the configured label.
        //
        //2. Form1: An instance of CustomLabel is created in Form1 and added to the form using this.Controls.
        //   Add(customLabel.GetLabel());. The label will display "Welcome to the Game!" at the top-left corner
        //   of the form. This setup allows you to manage your custom label separately from the main form logic.

        //Key Points:
        //1.	this.FormBorderStyle = FormBorderStyle.None;: Removes the title bar and window borders, creating a borderless window.
        //2.	this.WindowState = FormWindowState.Maximized;: Maximizes the form to fill the entire screen.
        //3.	this.TopMost = true;: Ensures the form remains on top of other windows.
        
        //Optional: Exiting the Application
        //Since there are no window controls to close the application, you might want to handle an exit key, like Escape, to close the game.
        //Add this code in your Form1_KeyDown method:
        //
        //
        //if (e.KeyCode == Keys.Escape)
        //{
        //    Application.Exit(); // Close the application on pressing Esc
        //}


        public Form1()
        {
            InitializeComponent();

            // Set the form to be full-screen and borderless
            this.FormBorderStyle = FormBorderStyle.None; // No border or title bar
            this.WindowState = FormWindowState.Maximized; // Maximize to full screen
            this.TopMost = false; // Keep the form on top change it to 'true' when you are not experimenting

            // Initialize and add the custom label
            CustomLabel customLabel1 = new CustomLabel("Welcome to the Game!", 24, Color.White, new Point(750, 550));
            CustomLabel customLabel2 = new CustomLabel("please press right, left, up & down arrow keys to move 'player'", 12, Color.Wheat, new Point(750, 585));
            CustomLabel customLabel3 = new CustomLabel("press escape button to close this window or exit this application", 11, Color.Violet, new Point(750, 610));

            this.Controls.Add(customLabel1.GetLabel());
            this.Controls.Add(customLabel2.GetLabel());
            this.Controls.Add(customLabel3.GetLabel());
        }

        bool right, left, up, down, escape;

        // Arrow key movement function
        void arrow_key_movement()
        {
            if (right)
            {
                if (player.Left < this.ClientSize.Width - player.Width)
                {
                    player.Left += 20; // Move right
                }
            }
            if (left)
            {
                if (player.Left > 0)
                {
                    player.Left -= 20; // Move left
                }
            }
            if (up)
            {
                if (player.Top < this.ClientSize.Height - player.Height && player.Top  > 10)
                {
                    player.Top -= 20; // Move up
                }
            }
            if (down)
            {
                
                if (player.Top < this.ClientSize.Height - (player.Height + 17) )
                {
                    player.Top += 20; // Move down
                }
            }
        }

        // Detect key press events
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //For left & right movements
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }

            //For up & down movements
            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = true;
            }

            //For exiting from full screen mode
            if (e.KeyCode == Keys.Escape)
            {
                escape = true;
                //get to close / exit the game
                this.Close();
            }
        }

        // Detect key release events
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Sequence for left & right key state
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            //Sequence for up & down key state
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }


            //Sequence for closing the program.
            if (e.KeyCode == Keys.Space)
            {
                escape = false;
            }
        }

        // Timer tick event for continuous movement
        private void timer1_Tick(object sender, EventArgs e)
        {
            arrow_key_movement();//The method is kept under the timer 
        }


    }
}


