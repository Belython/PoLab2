using System;
using System.Collections;
using System.IO;
using System.Globalization;

namespace INIParser
{

    public class IniParser
    {
        public Hashtable hash = new Hashtable();

        public struct SectKey
        {
            public string Section;
            public string Key;
        }

        public IniParser(string path)
        {
            TextReader file;
            string str = "";
            string section = "";
            string[] key;
            if (File.Exists(path))
            {
                var extension = System.IO.Path.GetExtension(path);
                if (extension != ".ini")
                {
                    throw new FormatException("wrong wormat file");
                }
                else
                {


                    file = new StreamReader(path);

                    str = file.ReadLine();

                    while (str != null)
                    {

                        if (str != "")
                        {
                            if (str.Contains(";"))
                            {
                                int index = str.IndexOf(";");
                                if (index > 0)
                                {
                                    str = str.Substring(0, index);
                                }
                            }
                            if (str.StartsWith("[") && str.EndsWith("]"))
                            {
                                section = str.Substring(1, str.Length - 2);
                            }
                            else
                            {
                                str = str.Replace(" ", string.Empty);
                                if (str.Contains("="))
                                {
                                    key = str.Split(new char[] {'='}, 2);
                                    SectKey SectKey;
                                    string value = "";

                                    SectKey.Section = section;
                                    SectKey.Key = key[0];

                                    if (key.Length > 1)
                                        value = key[1];

                                    hash.Add(SectKey, value);
                               }
                                else
                                {
                                    if (str[0] != ';')
                                    {
                                        throw new ArgumentException("string not equals");
                                    }
                                }
                            }
                        }
                        str = file.ReadLine();
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("file not found");
            }

        }

        public string TryGetString(string section, string setting)
        {
            SectKey SectKey;
            SectKey.Section = section;
            SectKey.Key = setting;
            if (hash[SectKey] == null)
            {
                throw new ArgumentNullException("wrong section or setting");
            }
            else
            {
                return (string)hash[SectKey];
            }

        }

        public int TryGetInt(string section, string setting)
        {
            SectKey SectKey;
            SectKey.Section = section;
            SectKey.Key = setting;
            string s = hash[SectKey].ToString();
            if (hash[SectKey] == null)
            {
                throw new ArgumentNullException("wrong section or setting");
            }
            else
            {
                int a;
                bool f = int.TryParse(s, out a);
                if (f)
                    return a;
                else
                {
                    throw new ArgumentException("wrong wormat arguments");
                }
            }
        }

        public double TryGetDouble(string section, string setting)
        {
            SectKey SectKey;
            SectKey.Section = section;
            SectKey.Key = setting;
            if (hash[SectKey] == null)
            {
                throw new ArgumentNullException( "wrong section or setting");
                
            }
            else
            {


                string s = hash[SectKey].ToString();
                double a;
                bool f = double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out a);
                if (f)
                    return a;
                else
                {
                    throw new ArgumentException("wrong wormat arguments");
                }
            }
        }
        public T TryGet<T>(string section, string setting) where T : IConvertible
        {
            SectKey SectKey;
            SectKey.Section = section;
            SectKey.Key = setting;
            if (hash[SectKey] == null)
            {
                throw new ArgumentNullException("wrong section or setting");

            }
            else
            {
                string s = hash[SectKey].ToString();
                if (typeof(T) == typeof(double))
                {
                    double a;
                    bool f = double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out a);
                    if (f)
                        return (T)Convert.ChangeType(a, typeof(T));
                    else
                    {
                        throw new ArgumentException("wrong wormat arguments");
                    }
                }

                if (typeof(T) == typeof(int))
                {
                    int a;
                    bool f = int.TryParse(s, out a);
                    if (f)
                        return (T)Convert.ChangeType(a, typeof(T));
                    else
                    {
                        throw new ArgumentException("wrong wormat arguments");
                    }
                }
                return (T)Convert.ChangeType(s, typeof(T));

            }
        }
    }
}
