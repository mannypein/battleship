using BattleShip.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip.View
{
    public partial class GameModeForm : Form
    {

        public static List<string> items = new List<string>();
        private static int counterOne = 0;
        private static int counterTwo = 0;
        private static int counterThree = 0;
        private static int counterFour = 0;


        public GameModeForm()
        {
            InitializeComponent();
        }

        //Game game = new Game();

        // I created this accidentally in the designer and now it's dangerous to delete
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < (checkedListBox1.Items.Count - 1); i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    items.Add(checkedListBox1.Items[i].ToString());
                }
            }
            Game game = new Game();
            this.Hide();
            DialogResult result = game.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //string fileName = path + "/game.bs";
                //using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                //{
                //    IFormatter formatter = new BinaryFormatter();
                //    formatter.Serialize(fileStream, game.state);
                //}
                //if(Game.isFinished)
                //{
                //    File.Delete(fileName);
                //}
                //checkedListBox1.Enabled = true;
                this.Show();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
            {
                checkedListBox1.Enabled = false;
            }
            else if(checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
            {
                checkedListBox1.Enabled = false;
            }
            else if(checkedListBox1.GetItemCheckState(3) == CheckState.Checked)
            {
                checkedListBox1.Enabled = false;
            }
            else if(checkedListBox1.GetItemCheckState(4) == CheckState.Checked)
            {
                checkedListBox1.Enabled = false;
            }
            else if(checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
            {
                checkedListBox1.Enabled = false;

            }
            else if(checkedListBox1.GetItemCheckState(5) == CheckState.Checked)
            {
                checkedListBox1.Enabled = false;
            }
        }
    }
}
