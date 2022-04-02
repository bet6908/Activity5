using System.IO;

namespace Activity5
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        
        public Form1()
        {
            InitializeComponent();
        }

        string line = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFile.FileName);
                while(line != null)
                {
#pragma warning disable CS8601 // Possible null reference assignment.
                    line = sr.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                    if (line != null)
                    {
                        txtText.Text = line;
                    }
                }
                sr.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFile.Filter = "Text files (.txt| *.txt";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string txt1 = txtText.Text;
            txtText2.Text = txt1.ToLower();
        }

        private void button4_Click(object sender, EventArgs e)
        {

                
            string[] words = txtText.Text.Split(' ');

            int length;
            string largestword = words[0];

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                length = word.Length;

                if (largestword.Length < words[i].Length)
                {
                    largestword = word;
                    txtBox4.Text = largestword;
                }
            }

                
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            string firstword = txtText.Text.Split(' ').First();
            string lastword = txtText.Text.Split(' ').Last();

            if (firstword.CompareTo(lastword) < 0)
            {
                txtBox3.Text = firstword + ": " + lastword;
            }
            else
            {
                txtBox3.Text = lastword + ": " + firstword;
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            string[] words = txtText.Text.Split(' ');
            string word = "";


            var mostVowels = 0;

            for (int i = 0; i < words.Length; i++)
            {
                var part = words[i];
                var numberOfVowels = 0;
                foreach (var vowel in vowels)
                {
                    if (part.Contains(vowel)) numberOfVowels++;
                }

                if (mostVowels < numberOfVowels)
                {
                    mostVowels = i;
                    word = part;
                }

            }
            txtBox5.Text = word;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.WriteLine(txtText2.Text);
                    sw.WriteLine(txtBox3.Text);
                    sw.WriteLine(txtBox4.Text);
                    sw.WriteLine(txtBox5.Text);
                }
            }
        }
    }
}