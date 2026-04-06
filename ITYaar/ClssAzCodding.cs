using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITYaar
{
    internal class CodeDecode
    {
        private string myVersion = "14041007.2400";
        public string Version
        {
            get { return myVersion; }
        }
        public int ascciCode(char x)
        {
            //Char c1 = txtIn.Text[0];
            return (int)x;
            //out= x.ToString();
        }
        public string reverse(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                    return input;

                var elements = new List<string>();
                var enumerator = System.Globalization.StringInfo.GetTextElementEnumerator(input);

                while (enumerator.MoveNext())
                {
                    elements.Add(enumerator.GetTextElement());
                }

                elements.Reverse();
                return string.Concat(elements);
            }
            catch { return input; }
        }
        public string xxCaesarCipher(string text, int shift)
        {
            try
            {
                char[] result = new char[text.Length];

                for (int i = 0; i < text.Length; i++)
                {
                    char ch = text[i];

                    if (Char.IsLetter(ch))
                    {
                        char baseChar = Char.IsUpper(ch) ? 'A' : 'a';
                        int asciiOffset = (ch - baseChar + shift) % 22;

                        // برای مقادیر منفی
                        if (asciiOffset < 0)
                            asciiOffset += 26;

                        result[i] = (char)(baseChar + asciiOffset);
                    }
                    else
                    {
                        result[i] = ch;
                    }
                }

                return new string(result);
            }
            catch { return text; }
        }
        public string yyCaesarCipher(string encryptedText, int shift)
        {
            try
            {
                char[] result = new char[encryptedText.Length];

                for (int i = 0; i < encryptedText.Length; i++)
                {
                    char ch = encryptedText[i];

                    if (Char.IsLetter(ch))
                    {
                        char baseChar = Char.IsUpper(ch) ? 'A' : 'a';
                        // تفاوت اصلی: در decode منهای shift می‌گذاریم
                        int asciiOffset = (ch - baseChar - shift) % 22;

                        // برای مقادیر منفی
                        if (asciiOffset < 0)
                            asciiOffset += 26;

                        result[i] = (char)(baseChar + asciiOffset);
                    }
                    else
                    {
                        result[i] = ch;
                    }
                }

                return new string(result);
            }
            catch { return encryptedText; }
        }
        public string xxAzYekdarmiyoon(string text, int shift)
        {
            try
            {
                char[] inputstr = new char[text.Length];
                char[] outputstr = new char[text.Length];

                for (int i = 0; i < text.Length; i++)
                {
                    char ch = text[i];
                    int a = (int)(shift * Math.Pow(-1, i));
                    int b = ascciCode(ch);
                    int c = a + b;
                    char d = (char)c;
                    //outputstr[i] = (char)(ascciCode(ch) + shift*(-1)^i);
                    outputstr[i] = d;
                }
                return new string(outputstr);
            }
            catch { return text; }
        }
        public string yyAzYekdarmiyoon(string text, int shift)
        {
            try
            {
                char[] inputstr = new char[text.Length];
                char[] outputstr = new char[text.Length];

                for (int i = 0; i < text.Length; i++)
                {
                    char ch = text[i];
                    int a = (int)(shift * -Math.Pow(-1, i));
                    int b = ascciCode(ch);
                    int c = a + b;
                    char d = (char)c;
                    //outputstr[i] = (char)(ascciCode(ch) + shift*(-1)^i);
                    outputstr[i] = d;
                }
                return new string(outputstr);
            }
            catch { return text; }
        }
        public string xxAzTabeHaft(string text, int key)
        {
            try
            {

                //char[] inputstr = new char[text.Length];
                char[] outputstr = new char[text.Length];
                int shift = (int)Math.Floor((double)text.Length / 2);
                for (int x = 0; x < text.Length; x++)
                {
                    char ch = text[x];
                    int b = ascciCode(ch);
                    double y = Math.Abs(-x + shift) * key;
                    int c = (int)y + b;
                    char d = (char)c;
                    outputstr[x] = d;
                }
                return new string(outputstr);
            }
            catch { return text; }
        }
        public string yyAzTabeHaft(string text, int key)
        {
            try
            {
                char[] inputstr = new char[text.Length];
                char[] outputstr = new char[text.Length];
                int shift = (int)Math.Floor((double)text.Length / 2);
                for (int x = 0; x < text.Length; x++)
                {
                    char ch = text[x];
                    int b = ascciCode(ch);
                    double y = -Math.Abs(-x + shift) * key;
                    int c = (int)y + b;
                    char d = (char)c;
                    outputstr[x] = d;
                }
                return new string(outputstr);
            }
            catch { return text; }
        }
        public string xxMixedWithKey(string input, string key)
        {
            try
            {

                int inputLen = input.Length;
                int keyLen = key.Length;
                char[] outputstr = new char[inputLen];
                for (int x = 0; x < inputLen; x++)
                {
                    char inputChar = input[x];
                    int inputAsc = (int)inputChar;
                    int xx = x % keyLen;
                    char keyChar = key[xx];
                    int keyAsc = (int)keyChar;
                    //outputstr[x] = (char)(inputAsc + keyAsc * (int)Math.Pow(-1, x));
                    //outputstr[x] = (char)( (int)Math.Floor((double)(inputAsc + keyAsc)/2) );
                    outputstr[x] = (char)(inputAsc + keyAsc);
                }
                return new string(outputstr);
            }
            catch { return input; }
        }
        public string yyMixedWithKey(string input, string key)
        {
            try
            {
                int inputLen = input.Length;
                int keyLen = key.Length;
                char[] outputstr = new char[inputLen];
                for (int x = 0; x < inputLen; x++)
                {
                    char inputChar = input[x];
                    int inputAsc = (int)inputChar;
                    char keyChar = key[x % keyLen];
                    int keyAsc = (int)keyChar;
                    //int outputint = inputAsc - keyAsc * (int)Math.Pow(-1, x);
                    int outputint = inputAsc - keyAsc;
                    outputstr[x] = (char)(outputint);
                }
                return new string(outputstr);
            }
            catch { return input; }
        }


    }
}
