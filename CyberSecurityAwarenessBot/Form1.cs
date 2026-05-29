using System;
using System.Media;
using System.Drawing;
using System.Windows.Forms;

namespace CyberSecurityAwarenessBot
{
    public partial class Form1 : Form
    {
        private BotResponse bot = new BotResponse();
        private MemoryManager memory = new MemoryManager();

        RichTextBox chatBox = new RichTextBox();
        TextBox inputBox = new TextBox();
        Button sendButton = new Button();

        public Form1()
        {
            InitializeComponent();
            SetupUI();
            PlayGreeting();
        }

        private void SetupUI()
        {
            this.Text = "Cybersecurity Awareness Bot";
            this.Size = new Size(800, 500);
            this.BackColor = Color.Black;

            chatBox.Location = new Point(20, 20);
            chatBox.Size = new Size(740, 330);
            chatBox.BackColor = Color.Black;
            chatBox.ForeColor = Color.Lime;
            chatBox.Font = new Font("Consolas", 11);

            inputBox.Location = new Point(20, 380);
            inputBox.Size = new Size(600, 30);

            sendButton.Text = "Send";
            sendButton.Location = new Point(640, 378);
            sendButton.Size = new Size(120, 35);

            sendButton.Click += SendButton_Click;

            this.Controls.Add(chatBox);
            this.Controls.Add(inputBox);
            this.Controls.Add(sendButton);

            chatBox.AppendText("=== CYBERSECURITY AWARENESS BOT ===\n");
            chatBox.AppendText("Bot: Welcome! Stay safe online.\n\n");
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player =
                    new SoundPlayer("Resources/welcome.wav");

                player.Play();
            }
            catch
            {
                chatBox.AppendText("Voice greeting file missing.\n");
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string input = inputBox.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            chatBox.AppendText("You: " + input + "\n");

            string response = bot.GetResponse(input);

            chatBox.AppendText("Bot: " + response + "\n\n");

            inputBox.Clear();
        }
    }
}