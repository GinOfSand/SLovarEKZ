using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLovarEKZ
{
    [Serializable]
    internal class BookWord
    {
        public string BW_name { get; set; }
        public Word[] Word_Tr { get; set; }
        public BookWord(string bw_name, Word[] word_Tr)
        {
            if(word_Tr == null) { word_Tr = new Word[1]; }
            if(bw_name == null) { bw_name = "Default"; }
            BW_name = bw_name;
            Word_Tr = word_Tr;
        }
        public void AddWord(string words, string translition)
        {
            string[] trnsl = { translition };
            Word_Tr.Append(new Word(words, trnsl));
        }
        public void DeleteWord(string words)
        {
            int j = 0;
            Word[] saver = new Word[Word_Tr.Length-1];
            for(int i = 0; i < Word_Tr.Length; i++)
            {
                if (Word_Tr[i].Words == words)
                {
                    Word_Tr[i] = null;
                }
                if(Word_Tr[i] != null)
                {
                    saver[j] = Word_Tr[i];
                }
            }
            Word_Tr = saver;
        }
    }
}
