using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Butterfly.Database.Interfaces;
using System.Text;
using System.Globalization;

namespace Butterfly.HabboHotel.Rooms.Chat.Filter
{
    public sealed class WordFilterManager
    {
        private readonly List<string> _filteredWords;
        private readonly List<string> _pubWords;

        public WordFilterManager()
        {
            this._filteredWords = new List<string>();
            this._pubWords = new List<string>();
        }

        public void Init()
        {
            if (this._filteredWords.Count > 0)
                this._filteredWords.Clear();
            if (this._pubWords.Count > 0)
                this._pubWords.Clear();

            DataTable Data = null;
            DataTable Data2 = null;
            using (IQueryAdapter dbClient = ButterflyEnvironment.GetDatabaseManager().GetQueryReactor())
            {
                dbClient.SetQuery("SELECT * FROM `room_swearword_filter`");
                Data = dbClient.GetTable();

                if (Data != null)
                {
                    foreach (DataRow Row in Data.Rows)
                    {
                        this._filteredWords.Add(Convert.ToString(Row["word"]));
                    }
                }

                dbClient.SetQuery("SELECT * FROM `worldfilterpub`");
                Data2 = dbClient.GetTable();

                if (Data2 != null)
                {
                    foreach (DataRow Row in Data2.Rows)
                    {
                        this._pubWords.Add(Convert.ToString(Row["word"]));
                    }
                }
            }
        }

        public void AddFilterPub(string Word)
        {
            if (!this._pubWords.Contains(Word))
            {
                this._pubWords.Add(Word);

                using (IQueryAdapter queryreactor = ButterflyEnvironment.GetDatabaseManager().GetQueryReactor())
                {
                    queryreactor.SetQuery("INSERT INTO worldfilterpub (word) VALUES (@word)");
                    queryreactor.AddParameter("word", Word);
                    queryreactor.RunQuery();
                }
            }
        }

        public string CheckMessage(string Message)
        {
            foreach (string Filter in this._filteredWords.ToList())
            {
                if (Message.ToLower().Contains(Filter))
                {
                    Message = Regex.Replace(Message, Filter, "****", RegexOptions.IgnoreCase);
                }
            }

            return Message;
        }

        private void ClearMessage(ref string message, bool Jcp = false)
        {
            // Ή
            message = message.Replace("Î‰", "h");
            message = message.ToLower();

            message = RemoveDiacritics(message);

            message = message.Replace("Ή", "h").Replace("µ", "u").Replace("₱", "p").Replace("ø", "o").Replace("Ω", "o").Replace("ð", "d").Replace("ω", "w").
                Replace("я", "r").Replace("ß", "b").Replace("0", "o").Replace("4", "a").Replace("3", "e").Replace("1", "i").Replace("@", "a").Replace("Ø", "o").
                Replace("$", "s").Replace("Ð", "d").Replace("8", "b").Replace("β", "b");

            if(!Jcp)
                message = new Regex(@"[^a-z]", RegexOptions.IgnoreCase).Replace(message, string.Empty);
        }

        public bool Ispub(string message)
        {
            if (message.Length <= 3)
                return false;

            this.ClearMessage(ref message);

            foreach (string pattern in this._pubWords)
                if (message.Contains(pattern))
                    return true;

            return false;
        }

        public bool CheckMessageWord(string message)
        {
            int OldLength = message.Replace(" ", "").Length;

            this.ClearMessage(ref message, true);

            int LetterDelCount = OldLength - message.Length;

            List<string> WordPub = new List<string>() { "go",
                                                        ".fr",
                                                        ".com",
                                                        ".me",
                                                        ".org",
                                                        ".be",
                                                        ".eu",
                                                        "recru",
                                                        "staff",
                                                        "rejoignez",
                                                        "retro",
                                                        "rétro",
                                                        "meilleur",
                                                        "direction",
                                                        "rejoin",
                                                        "gratuit",
                                                        "open",
                                                        "http",
                                                        "recrutement",
                                                        "/",
                                                        "É", //Etoile
                                                        "fps",
                                                        "new",
                                                        "bbo", };

            
            int CountDetect = 0;
            foreach (string pattern in WordPub)
                if (message.Contains(pattern))
                {
                    CountDetect++;
                    continue;
                }

            if (CountDetect >= 5 || (LetterDelCount > 10 && CountDetect >= 2))
                return true;


            return false;
        }

        static string RemoveDiacritics(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
    }
}