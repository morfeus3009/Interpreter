using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpreter
{
    public partial class Form1 : Form
    {
        bool checkSign = false;
        string helper = string.Empty;
        List<string> textListe = new List<string>();
        Dictionary<string, string> variablen = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnStartInterpreter_Click(object sender, EventArgs e)
        {          
            string text = "var meineErsteVariable = \"Ich bin die; Erste Variable\";var meineZweiteVariable = \"Ich bin die Zweite Variable\";";
            SplitCommands(text);
            VarToDict();
            
        }

        private void SplitCommands (string commands)

        {
            foreach (char sign in commands)
            {
                helper += sign;
                if (sign.Equals('"'))
                    checkSign = !checkSign;

                if (sign.Equals(';') && !checkSign)
                {
                    textListe.Add(helper);
                    helper = string.Empty;
                }
            }
        }

        private void VarToDict()
        { 
            
            foreach (string currentElement in textListe)
            {
                try
                {
                    string command = string.Empty;
                    if (currentElement.StartsWith("var"))
                        command = currentElement.Remove(0, 3);
                    string[] commandSplit = command.Split('=');
                    int i = commandSplit.Count();
                    if (variablen.ContainsKey(commandSplit[0].Trim()))
                        variablen[commandSplit[i - 2].Trim()] = commandSplit[i - 1].Trim(new char[] { ' ', '\"', ';'});
                    else
                        variablen.Add(commandSplit[i - 2].Trim(), commandSplit[i - 1].Trim(new char[] { ' ', '\"', ';'}));
                }
                catch { }
            }
        }
    }
}
