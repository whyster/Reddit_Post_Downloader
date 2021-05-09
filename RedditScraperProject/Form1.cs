using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace RedditScraperProject
{
    public partial class Form1 : Form
    {
        static ReaderWriterLock locker = new ReaderWriterLock();
        public string baseUrl = "http://old.reddit.com/r/";
        public HttpClient webClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            webClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        }

        private void Start(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            string subreddit = subredditBox.Text;
            int count = Int32.Parse(countBox.Text);
            int currentPosition = 0; 
            string path = saveLocationBox.Text;

            

            HtmlDocument mainDoc = new HtmlDocument();
            mainDoc.Load(webClient.GetStreamAsync($"{baseUrl}{subreddit}").Result);
            var subDocs = mainDoc.DocumentNode.SelectNodes($"//p[@class = 'title']/a[contains(@href, '/r/{subreddit}')]");
            
            File.WriteAllText(path, "{\n");
            Stack<Thread> threads = new Stack<Thread>();
            while (currentPosition <= count) 
            {
                countLabel.Text = $"{currentPosition}/{count}";
                int amount = (count - currentPosition) <= subDocs.Count ? (count - currentPosition) : (subDocs.Count);
                Thread t = new Thread((() => subThreadProcess(amount, subDocs, path)));
                threads.Push(t);
                t.Start();

                currentPosition += amount;
                
                countLabel.Text = $"{currentPosition}/{count}";
                
                if (currentPosition < count)
                {
                    try
                    {
                        mainDoc.Load(webClient.GetStreamAsync(mainDoc.DocumentNode.SelectNodes("//span[@class='next-button']/a[contains(@href, 'old.reddit.com')]")[0].GetAttributeValue("href", "tmp")).Result);
                    }
                    catch (Exception exception)
                    {
                    
                        //File.WriteAllText("fuck.txt", mainDoc.Text);
                        throw;
                    }
                }
                else
                {
                    while (threads.Count != 0)
                    {
                        Thread t1 = threads.Pop();
                        System.Diagnostics.Debug.WriteLine($"Joining main thread onto thread {t1.ManagedThreadId.ToString()}");
                        t1.Join();
                    }
                    break;
                }
                
                subDocs = mainDoc.DocumentNode.SelectNodes($"//p[@class = 'title']/a[contains(@href, '/r/{subreddit}')]");
            } 
             
            //loop 
            //until 25 
            //then reload
            try
            {
                locker.AcquireWriterLock(Int32.MaxValue);
                File.AppendAllText(path, "\n}");
                cleanFile(path);
            }
            finally
            {
                locker.ReleaseLock();
            }
            
            
            startButton.Enabled = true;
        }

        private void subThreadProcess(int acount, HtmlNodeCollection subDoc, string path)
        {
            String[] maxText = new string[acount];
            System.Diagnostics.Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId.ToString()} has started");
            //Thread.CurrentThread.
            string title, body;
            for (int i = 0; i < acount; i++)
            {
                body = "";

                HtmlDocument postDoc = new HtmlDocument();
                postDoc.Load(webClient
                    .GetStreamAsync($"http://old.reddit.com{subDoc[i].GetAttributeValue("href", "null")}").Result);
                title = postDoc.DocumentNode.SelectNodes("//p[@class = 'title']/a")[0].InnerText.Trim();
                try
                {
                    foreach (var node in postDoc.DocumentNode.SelectNodes(
                        "//div[@class='entry unvoted']/div/form/div/div[@class='md']")[0].ChildNodes)
                    {
                        body += node.InnerText.Trim();
                    }
                }
                catch (Exception e)
                {
                    body = "No body text";
                }

                maxText[i] = $"\"{title}\":\"{body}\",\n";
            }
            try
            {
                locker.AcquireWriterLock(Int32.MaxValue);
                File.AppendAllLines(path, maxText);
            }
            finally
            {
                locker.ReleaseLock();
            }
            System.Diagnostics.Debug.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId.ToString()} has finished running");
        }

        private void cleanFile(string path)
        {
            /*
             * &#39; = '
             * â€™ = '
             * â€œ
             * â€
             * \.([\w]) = \. $1
             */
            string text = File.ReadAllText(path);
            Regex stuff = new Regex("\\.(.)");
            text = stuff.Replace(text, ". $1");
            
            text = text.Replace("â€œ", "");
            text = text.Replace("â€", "");

            text = text.Replace("â€˜", "'");
            text = text.Replace("&#39;", "'");
            text = text.Replace("â€™", "'");

            text = text.Replace("&quot;", "\\\"");
            text = text.Replace("\n", "");
            text = text.Replace("\",\"", "\",\n\"");
            text = text.Replace(",}", "}");
            File.WriteAllText(path, text);
        }
    }
}