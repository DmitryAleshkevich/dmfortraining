using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Checkpoint2Text
{
    public class Parser
    {
        #region Services

        private string path;

        private Dictionary<int, StringBuilder> rest = new Dictionary<int, StringBuilder>();

        private StreamReader OpenFile(string connectionPath)
        {
            try
            {
                this.path = connectionPath.Replace(".txt", "1.txt");
                File.Copy(connectionPath, this.path);
                return new StreamReader(this.path); ;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file {0} could not be read, cause:",connectionPath);
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private StringBuilder AddRestToString(int stringCounter, StringBuilder strbuild)
        {
            StringBuilder strbuild2 = new StringBuilder();
            for (int key = stringCounter; key > 0; key--)
            {
                if (key < stringCounter)
                {
                    if (this.rest.TryGetValue(key, out strbuild2))
                    {
                        if (stringCounter - key == 1) strbuild2.Insert(strbuild2.Length, " ");
                        strbuild.Insert(0, strbuild2);
                    }
                }
            }
            return new StringBuilder(Regex.Replace(strbuild.ToString(), "\\s+", " "));
        }

        private void AddStringToRest(StringBuilder textLine, int stringCounter)
        {
            StringBuilder strbuild2 = new StringBuilder();
            for (int key = 1; key <= stringCounter; key++)
            {
                if (this.rest.TryGetValue(key, out strbuild2))
                {
                    if (textLine.ToString().IndexOf(strbuild2.ToString()) != -1)
                    {
                        textLine.Remove(textLine.ToString().IndexOf(strbuild2.ToString()), strbuild2.Length);
                    }
                    else
                    {
                        this.rest.Remove(key);
                    }
                }
            }
            if (textLine.Length > 0)
            {
                this.rest.Add(stringCounter, new StringBuilder(Regex.Replace(textLine.ToString(), "\\s+", " ")));
            }
        }
       
        #endregion

        #region Parsers

        public Text ParseText(string connectionPath)
        {
            var reader = OpenFile(connectionPath);
            if (reader != null)
            {
                Text text = new Text(); 
                text.SentensesColl = new List<Sentense>(); 
                string textLine; 
                int stringCounter = 0; 
                while ((textLine = reader.ReadLine()) != null)
                {
                    stringCounter++;
                    StringBuilder strbuild = new StringBuilder(Regex.Replace(textLine, "\\s+", " ")).Replace(" ",String.Empty,0,Math.Min(1,textLine.Length));
                    strbuild = AddRestToString(stringCounter, strbuild);
                    text.SentensesColl.AddRange(ParseSentense(strbuild, stringCounter));
                }
                reader.Close();
                File.Delete(this.path);
                return text;
            }
            return null;
        }

        private List<Sentense> ParseSentense(StringBuilder textLine, int stringCounter)
        {
            List<Sentense> sentenses = new List<Sentense>();
            string pattern = @"([А-ЯA-Z]([^?!.\(]|\([^\)]*\))*[.?!])";
            var matches = Regex.Matches(textLine.ToString(), pattern);
            foreach (Match match in matches)
            {
                Sentense sentense = new Sentense(); sentense.SentenseElements = new List<ISentenceItem>(); StringBuilder strbuild2 = new StringBuilder();
                StringBuilder strbuild = new StringBuilder(match.Value);
                for (int key = 1; key <= stringCounter; key++)
                {
                    if (this.rest.TryGetValue(key, out strbuild2))
                    {
                        if (strbuild.ToString().IndexOf(strbuild2.ToString()) != -1)
                        {
                            var strbuild3 = new StringBuilder(strbuild2.ToString());
                            sentense.SentenseElements.AddRange(ParseSentenceElements(strbuild3, key));                
                            strbuild.Remove(textLine.ToString().IndexOf(strbuild2.ToString()), strbuild2.Length);
                            this.rest.Remove(key);
                        }                        
                    }
                }
                sentense.SentenseElements.AddRange(ParseSentenceElements(new StringBuilder(Regex.Replace(strbuild.ToString(), "\\s+", " ")), stringCounter));
                sentense.DetermineType();
                sentenses.Add(sentense);
                textLine.Clear();
            }
            if (textLine.Length > 0) AddStringToRest(textLine, stringCounter);
            return sentenses;
        }
  
        private List<ISentenceItem> ParseSentenceElements(StringBuilder textLine, int stringCounter)
        {
            List<ISentenceItem> sentensesItems = new List<ISentenceItem>();
            string pattern = @"[^\s,;.!?]+";
            var matches = Regex.Matches(textLine.ToString(), pattern);
            foreach (Match match in matches)
            {
                string newstr = textLine.ToString().Substring(0, textLine.ToString().IndexOf(match.ToString()));
                if (newstr.Length != 0)
                {
                    StringBuilder strbuild = new StringBuilder(newstr);
                    sentensesItems.AddRange(ParseSymbols(strbuild,stringCounter));
                    textLine.Replace(newstr, String.Empty, 0, textLine.ToString().IndexOf(match.Value));                
                }
                StringBuilder strbuild2 = new StringBuilder(match.ToString());
                sentensesItems.AddRange(ParseWord(strbuild2, stringCounter));
                textLine.Replace(match.Value, String.Empty, 0, textLine.ToString().IndexOf(match.Value) + match.Length);                
            }
            if (textLine.Length > 0)
            {
                sentensesItems.AddRange(ParseSymbols(textLine, stringCounter));
                textLine.Clear();    
            }
            return sentensesItems;
        }

        private List<Word> ParseWord(StringBuilder textLine, int stringCounter)
        {
            List<Word> words = new List<Word>();
            Word word = new Word(); word.Symbols = new List<Symbol>();
            word.Symbols.AddRange(ParseSymbols(textLine, stringCounter));
            words.Add(word);
            return words;
        }

        public List<Symbol> ParseSymbols(StringBuilder strbuild, int stringCounter)
        {
            List<Symbol> listSymb = new List<Symbol>();
            foreach (Char s in strbuild.ToString())
            {
                if (Char.IsLetterOrDigit(s))
                {
                    LetterFigure symbol = new LetterFigure() { Representation = s, StringNumber = stringCounter };
                    listSymb.Add(symbol);
                }
                else
                {
                    PunctuationMark symbol = new PunctuationMark() { Representation = s, StringNumber = stringCounter };
                    listSymb.Add(symbol);
                }
            }
            return listSymb;
        }
        
        #endregion
    }
}
