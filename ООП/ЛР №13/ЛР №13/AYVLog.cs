using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ЛР__13
{
    static class AYVLog
    {
        private static string path = "AYVLog.txt";
        private static string path1 = "AYVLog1.txt";
        public static void Log(string FileName, string Message)
        {
            
            string msg = $"[{DateTime.Now}] {FileName}: {Message}";
            using(StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLineAsync(msg);
            }
        }
        public static List<string>? Search(string SearchData)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string FileData = sr.ReadToEnd();
                List<string> SearchedInfo = new List<string>();
                for(int i = 0; i < FileData.Length; i++)
                {
                    for(int SearchDataIndex = 0, FileDataIndex = i; SearchDataIndex < SearchData.Length; SearchDataIndex++, FileDataIndex++)
                    {
                        if (FileData[FileDataIndex] == SearchData[SearchDataIndex])
                        {
                            if (SearchData.Length - 1 == SearchDataIndex)
                            {
                                while (FileData[FileDataIndex] != '[')
                                    FileDataIndex--;
                                string Message = "";
                                while (FileData[FileDataIndex] != '\n')
                                {
                                    Message += FileData[FileDataIndex];
                                    FileDataIndex++;
                                }
                                SearchedInfo.Add(Message);
                                break;
                            }
                            else
                                continue;
                        }   
                        else
                            break;
                    }
                }
                if (SearchedInfo.Count > 0)
                    return SearchedInfo;
                else
                    return null;
            }
        }
        public static List<string>? SearchByDay(string day)
        {
            if (Convert.ToInt32(day) < 0 || Convert.ToInt32(day) > 31)
                return null;
            if (day.Length == 1)
            {
                day += '0';
                char[] arr = day.ToCharArray();
                Array.Reverse(arr);
                day = new string(arr);
            }

            List<string> SearchedData = new List<string>();
            using(StreamReader sr = new StreamReader(path))
            {
                while(!sr.EndOfStream)
                {
                    string Line = sr.ReadLine();
                    if (Line[1] == day[0] && Line[2] == day[1])
                        SearchedData.Add(Line);
                }
            }
            if (SearchedData.Count == 0)
                return null;
            else 
                return SearchedData;
        }
        public static bool RemoverByTime(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
                return false;
            
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string Line = sr.ReadLine();
                    string date = "";
                    DateTime DT = new DateTime();
                    for (int i = 1; i < 20; i++)
                        date += Line[i];
                    try
                    {
                        DT = Convert.ToDateTime(date);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                    if (!(DT >= startTime && DT <= endTime))
                    {
                        using(StreamWriter sw = File.AppendText(path1))
                        {
                            sw.WriteLine(Line);
                        }
                    }
                }
            }
            return true;
        }
    }
}
