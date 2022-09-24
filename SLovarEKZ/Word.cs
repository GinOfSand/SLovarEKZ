using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLovarEKZ
{
    [Serializable]
    internal class Word
    {
        public string Words { get; set; }
        public string[] Word_translition { get; set; }
        public Word(string words, string[] word_translition)
        {
            if (words == null) { words = "Default"; }
            if (word_translition == null) { word_translition = new string[] { "Default" }; } 
            Words = words; 
            Word_translition = word_translition;
        }
        public void AddTranslition(string translit)
        {
            Word_translition = new string[Word_translition.Length + 1];
            Word_translition.Append(translit);
        }
        public void DeleteTranslition(int pozition)
        {
            if (Word_translition.Length > 1)
            {
                string[] translitionSaver = new string[Word_translition.Length - 1];
                Word_translition[pozition] = null;
                int j = 0;
                for (int i = 0; i < Word_translition.Length; i++)
                {
                    if (Word_translition[i] != null)
                    {
                        translitionSaver[j] = Word_translition[i];
                        j++;
                    }
                }
                Word_translition = translitionSaver;
            }
        }
    }
}
