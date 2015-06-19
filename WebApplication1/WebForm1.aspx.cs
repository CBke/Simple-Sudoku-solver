using Board;
using System;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Sudoku board = new Sudoku();
            for (int i = 1; i < 82; i++)
            {
                TextBox t = (TextBox)FindControl("TextBox" + i);
                if (!string.IsNullOrEmpty(t.Text))
                {
                    int x = (i - 1) / 9;
                    int y = (i - 1) % 9;
                    board[x, y] = int.Parse(t.Text);
                }
            }
            board.Resolve();

            for (int i = 1; i < 82; i++)
            {
                TextBox t = (TextBox)FindControl("TextBox" + i);

                int x = (i - 1) / 9;
                int y = (i - 1) % 9;
                t.Text = board[x, y].ToString();
            }
        }
    }
}