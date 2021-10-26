using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task8_3
{
    class TextWorker
    {
        List<string> sentences;
        Dictionary<int, string> linesByIndex;

        public TextWorker()
        {
            linesByIndex = new Dictionary<int, string>();
            sentences = new List<string>();
        }

        public void ReadFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    StringBuilder sb = new StringBuilder();
                    string data = "";
                    bool isEmpty = true;
                    int count = 0;
                    int i = 0;

                    while (!sr.EndOfStream)
                    {

                        data = sr.ReadLine();
                        i = 0;

                        while (i < data.Length)
                        {

                            while (i < data.Length && data[i] != '.')
                            {
                                if (data[i] == '<' || data[i] == '>')
                                {
                                    count++;
                                }
                                i++;
                            }

                            sb.Append(data);

                            if (!data.Contains('.'))
                            {
                                continue;
                            }

                            if (data[i] == '.')
                            {
                                if (!linesByIndex.ContainsKey(count))
                                {
                                    linesByIndex.Add(count, sb.ToString());
                                }
                                else
                                {
                                    linesByIndex[count] += sb.ToString();
                                }
                                sentences.Add(sb.ToString());

                                sb.Clear();
                                count = 0;
                                break;
                            }
                        }
                        isEmpty = false;
                    }
                    if (isEmpty)
                    {
                        throw new Exception("File is empty!");
                    }

                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in sentences)
            {
                sb.Append(elem.ToString() + "\n");
            }
            return sb.ToString();
        }


        public string GetMostDepthSentence()
        {
            int maxDepth = linesByIndex.Keys.Max();
            string sentence = linesByIndex[maxDepth];
            return sentence;
        }


        public void SortSentences()
        {
            sentences.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
        }
    }
}
