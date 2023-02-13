using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B1n4r10
{
    public partial class B1n4r10 : Form
    {
    Dictionary<char, string> binaryCode = new Dictionary<char, string>
    {
        {'A', "01000001"}, 
        {'B', "01000010"}, 
        {'C', "01000011"},
        {'D', "01000100"}, 
        {'E', "01000101"}, 
        {'F', "01000110"},
        {'G', "01000111"}, 
        {'H', "01001000"}, 
        {'I', "01001001"},
        {'J', "01001010"}, 
        {'K', "01001011"}, 
        {'L', "01001100"},
        {'M', "01001101"}, 
        {'N', "01001110"}, 
        {'O', "01001111"},
        {'P', "01010000"}, 
        {'Q', "01010001"}, 
        {'R', "01010010"},
        {'S', "01010011"}, 
        {'T', "01010100"}, 
        {'U', "01010101"},
        {'V', "01010110"}, 
        {'W', "01010111"}, 
        {'X', "01011000"},
        {'Y', "01011001"},
        {'Z', "01011010"},
        {'0', "00110000"},
        {'1', "00110001"}, 
        {'2', "00110010"},
        {'3', "00110011"}, 
        {'4', "00110100"}, 
        {'5', "00110101"},
        {'6', "00110110"}, 
        {'7', "00110111"}, 
        {'8', "00111000"},
        {'9', "00111001"},
        {' ', "00100000"},
        {'!', "00100001"},
        {'"', "00100010"},
        {'#', "00100011"},
        {'$', "00100100"},
        {'%', "00100101"},
        {'&', "00100110"},
        {'(', "00101000"},
        {')', "00101001"},
        {'*', "00101010"},
        {',', "00101100"},
        {'-', "00101101"},
        {'.', "00101110"},
        {'/', "00101111"},
        {':', "00111010"},
        {'<', "00111100"},
        {'=', "00111101"},
        {'>', "00111110"},
        {'?', "00111111"},
        {'@', "01000000"},
        {'_', "01011111"},
        {'´', "11000010 10110100"},
        {'`', "01100000"},
        {'[', "01011011"},
        {']', "01011101"},
        {'^', "01011110"},
        {'{', "01111011"},
        {'|', "01111100"},
        {'}', "01111101"},
        {'~', "01111110"},
        //Portuguese Characters
        {'Ç', "10000111"},
        {'Á', "10000001"},
        {'Ã', "10000011"},
        {'À', "10000000"},
        {'Â', "10000010"},
        {'É', "10001001"},
        {'È', "10001000"},
        {'Ê', "10001010"},
        {'Ì', "10001100"},
        {'Î', "10001110"},
        {'Í', "10001101"},
        {'Ó', "10010011"},
        {'Õ', "10010101"},
        {'Ò', "10010010"},
        {'Ô', "10010100"},
        {'Ú', "10011010"},
        {'Û', "10011011"},
        {'Ù', "10011001"}

    };

        private Dictionary<string, char> ReverseBinaryCode { get; set; }
        public B1n4r10()
        {
            InitializeComponent();
            ReverseBinaryCode = binaryCode.ToDictionary(x => x.Value, x => x.Key);

        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.ToUpper();
            string output = "";

            if (rbnTextToBinary.Checked == true)
            {
                foreach (char letter in input)
                {
                    if (binaryCode.ContainsKey(letter))
                    {
                        output += binaryCode[letter] + " ";
                    }
                }
            }
            else if (rbnBinaryToText.Checked == true)
            {
                string[] binaryStrings = input.Split(' ');
                foreach (string binaryString in binaryStrings)
                {
                    if (ReverseBinaryCode.ContainsKey(binaryString))
                    {
                        output += ReverseBinaryCode[binaryString];
                    }
                }
            }

            
            txtOutput.Text = output;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text == "")
            {
                MessageBox.Show("Para copiar o Output, é preciso haver Output." +
                    "\n\nPeço-te se não for muito maçante, escreve alguma coisa no Input.", "Sem Output", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Clipboard.SetText(txtOutput.Text);
                MessageBox.Show("Copiado com sucesso!", "Copiado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            txtInput.Text = Clipboard.GetText();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string message = "Eu ao contrário do meu projeto de código morse, consegui colocar caracteres acentuados usados na linguagem portuguesa. Mas sim pode haver uma fuga, por favor se encontrar alçgum erro, dirija-se ao meu Website e reporte o problema.";
            string ws = Environment.NewLine + "\nhttps://h3nr1qu3x.github.io/website/contact.html";
            MessageBox.Show(message + ws, "Ajuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
