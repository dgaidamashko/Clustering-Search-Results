﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StopWords;

namespace ClusteringSearchResults
{
    static class TextOperations
    {

        static StWdsEng Eng;
        static StWdsRus Rus;
        public static List<string> ts;
        public static List<string> txt;
        public static List<List<Word>> Tag;
        static double[,] Matrix;
        static Tags[] TextTitles;
        static Tags[] Words;
        static List<string> AllWds;
        #region
        static string[] temp;

       /* static string[] temp = {"Британск полиц знает о местонахожден основател WikiLeaks",
"В суд США начина процесс прот россиянина, рассыла спам",
"Церемон вручен Нобелевск прем мир бойкотир 19 стран",
"В Великобритан арестова основател сайт Wikileaks Джулиа Ассандж",
"Украин игнорир церемон вручен Нобелевск прем",
"Шведск суд отказа рассматрива апелляц основател Wikileaks",
"НАТО и США разработа план оборон стран Балт прот Росс",
"Полиц Великобритан нашл основател WikiLeaks, но, не арестова",
"В Стокгольм и Осло сегодн состо вручен Нобелевск прем",
                               };*/
        #endregion

        public static void InitParams(string[] t)
        {
            temp = t;
            Eng = new StWdsEng();
            Rus = new StWdsRus();
            ts = new List<string>();
            ts.AddRange(temp);
            txt = new List<string>();
            Tag = new List<List<Word>>();
        }

        public static void TagNullifier()
        {
            Tag = new List<List<Word>>();
        }

        //Дробление текста на слова
        public static List<string> Divid(string txt)
        {
            List<string> words = new List<string>();
            string[] temp = txt.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temp.Length; i++)
            {
                if (alphabetCharsExistance(temp[i]))
                {
                    words.Add(PunctuationDel(temp[i]));
                }
            }
            return words;
        }

        //Проверка на наличие в единице текста букв
        static bool alphabetCharsExistance(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'Ё' || word[i] == 'ё') return true;
                if (((int)(word[i]) >= 1040 && (int)(word[i]) <= 1071) || ((int)(word[i]) >= 65 && (int)(word[i]) <= 90)) return true;
                if ((((int)(word[i]) >= 1072 && (int)(word[i]) <= 1103)) || ((int)(word[i]) >= 97 && (int)(word[i]) <= 122)) return true;
                //if ((int)(word[i]) >= 48 && (int)(word[i]) <= 57) return true;
            }
            return false;
        }

        //Стемминг слов в тексте
        public static List<string> vClusterize(string text)
        {
            List<string> tx = Divid(text);
            for (int i = 0; i < tx.Count; i++)
            {
                string temp;
                int lang = LanguageCheck(tx[i], out temp);
                switch (lang)
                {
                    case 1://Русский язык
                        {
                            tx[i] = temp;
                            //tx[i]=Stemming(tx[i], "russian");
                            if (Rus.Check(tx[i]))
                            {
                                tx.RemoveAt(i);
                                i--;
                            }
                            break;
                        }
                    case 2://Английский язык
                        {
                            tx[i] = temp;
                            if (Eng.Check(tx[i]))
                            {
                                tx.RemoveAt(i);
                                i--;
                            }
                            //else tx[i] = Stemming(tx[i], "english");
                            break;
                        }
                }
            }
            return tx;
        }

        //Наличие символа в массиве
        static bool SymbExistance(char[] arr, char c)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (c == arr[i]) return true;
            }
            return false;
        }

        //Удаление знаков препинания, не разделенных от слов пробелами
        static string PunctuationDel(string s)
        {
            char[] beginning = { '(', '<', '\'', '\"', '«', '•', '◆', '⇨', '́' };
            char[] end = { ';', '.', ',', '\'', '\"', ':', '!', '?', '>', ')', '%', '»', '•', '◆', '⇨', '́' };
            while (SymbExistance(beginning, s[0]))
            {
                s = s.Substring(1, s.Length - 1);
            }
            while (SymbExistance(end, s[s.Length - 1]))
            {
                s = s.Substring(0, s.Length - 1);
            }
            return s;
        }

        //Формирование списка уникальных основ в тексте с указанием их частот
        public static List<Word> Frequency(List<string> text)
        {
            int index = 0;
            List<Word> Freq = new List<Word>();
            for (int i = 0; i < text.Count; i++)
            {
                if (FreqCheck(Freq, text[i], ref index))
                {
                    Freq[index].count++;
                }
                else
                {
                    Freq.Add(new Word(text[i]));
                }
                text.Remove(text[i]);
                i--;
            }
            return Freq;

        }

        //Проверка на повторение слова
        static bool FreqCheck(List<Word> txt, string w, ref int ind)
        {
            for (int i = 0; i < txt.Count; i++)
            {
                if (txt[i].word == w)
                {
                    ind = i;
                    return true;
                }
            }
            return false;
        }

        static void LLWchange()
        {
            string[] wordlist;  // wordlist - тот массив всех встречающихся вордов, что тебе надо заполнить; Можешь вместо него поставить что-то другое, но не забудь заменить
            List<List<Word>> temp = new List<List<Word>>();
            AllWds = AllWords();
            wordlist = new string[AllWds.Count];
            for (int i = 0; i < AllWds.Count; i++)
            {
                wordlist[i] = AllWds[i];
            }

            for (int i = 0; i < Tag.Count; i++)
            {
                temp.Add(new List<Word>());

                for (int j = 0; j < wordlist.Length; j++)
                {
                    bool wordexists = false;
                    for (int k = 0; k < Tag[i].Count; k++)
                    {
                        if (wordlist[j] == Tag[i][k].word)
                        {
                            wordexists = true;
                            temp[i].Add(new Word(Tag[i][k].word, Tag[i][k].count));
                            break;
                        }
                    }
                    if (!wordexists)
                    {
                        temp[i].Add(new Word(wordlist[j], 0));
                    }
                }
            }
            Tag = temp;
        }

        //Формирование списка уникальных основ слов, которые повторяются в РАЗНЫХ текстах
        static List<string> AllWords()
        {
            List<string> ss = new List<string>();
            List<Word> temp = new List<Word>();
            for (int i = 0; i < Tag.Count; i++)
            {
                for (int j = 0; j < Tag[i].Count; j++)
                {
                    if (!CheckItemInList(ref temp, Tag[i][j].word))
                    {
                        temp.Add(new Word(Tag[i][j].word));
                    }
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                if (!temp[i].IsSingle) ss.Add(temp[i].word);
            }
            return ss;
        }

        //Проверка на наличие элемента в списке
        static bool CheckItemInList(ref List<Word> ss, string elem)
        {
            for (int i = 0; i < ss.Count; i++)
            {
                if (ss[i].word == elem)
                {
                    ss[i].IsSingle = false;
                    return true;
                }
            }
            return false;
        }

        //Формирование частотной матрицы
        public static void FormMatrix()
        {
            LLWchange();
            Matrix = new double[Tag[0].Count, Tag.Count];
            TextTitles = new Tags[Matrix.GetLength(1)];
            Words = new Tags[Matrix.GetLength(0)];
            for (int i = 0; i < Tag[0].Count; i++)
            {
                for (int j = 0; j < Tag.Count; j++)
                {
                    Matrix[i, j] = Tag[j][i].count;
                    TextTitles[j] = new TextTitle(Convert.ToString(j + 1));
                    Words[i] = Tag[j][i];
                }
            }
        }

        //Проверка слова на принадлежность к языку
        public static int LanguageCheck(string word, out string wrd)
        {
            int rez = 0;
            string temp = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'Ё' || word[i] == 'ё') temp += "е";
                else if (((int)(word[i]) >= 1040 && (int)(word[i]) <= 1071) || ((int)(word[i]) >= 65 && (int)(word[i]) <= 90))
                { temp += Convert.ToString(Convert.ToChar(Convert.ToInt32(word[i]) + 32)); }
                else temp += Convert.ToString(word[i]);
                if ((int)temp[temp.Length - 1] >= 1072 && (int)temp[temp.Length - 1] <= 1103)
                {
                    if (rez == 0 || rez == 1) rez = 1;
                    else if (rez == 2) { rez = 0; temp = word; break; }
                }
                else if ((int)temp[temp.Length - 1] >= 97 && (int)temp[temp.Length - 1] <= 122)
                {
                    if (rez == 0 || rez == 2) rez = 2;
                    else if (rez == 1) { rez = 0; break; }
                }
            }
            wrd = temp;
            return rez;
            //0 - кириллица и латынь (очепятка)
            //1 - кириллица (русский язык)
            //2 - латиница (английский язык)
        }

        public static double[,] GetMatrix
        {
            get { return Matrix; }
        }

        public static Tags[] GetWords
        {
            get { return Words; }
        }

        public static Tags[] GetTextTitles
        {
            get { return TextTitles; }
        }
    }
}
