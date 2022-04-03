using System;
using System.Text.RegularExpressions;

namespace kata4
{
    public class Program
    {
        
        public static void Main()
        {
            //weatherTask();
            //soccerTask();
            dryTask();
        }

        static void weatherTask()
        {
            const string FILEPATH = @"C:\Users\user\Downloads\weather.dat";
            
            var lines = File.ReadAllLines(FILEPATH).Skip(2);
            var records = lines.Select(line => Regex.Split(line.Trim(), "\\s+").Take(3)); // first 3 columns of each row
            records = records.Take(records.Count() - 1); // skip the last line

            var recordsInt = records.Select(x => x.Select(c => Convert.ToInt32(c.Trim('*'))).ToList()).ToList();

            var sorted = recordsInt.Select(x => new KeyValuePair<int, int>(x[0], x[1] - x[2])).OrderBy(x => x.Value);

            var mostMin = sorted.First();
            var result = sorted.Where(x=>x.Value == mostMin.Value).ToList();

            foreach (var r in result)
            {
                Console.WriteLine(r.Key + " " + r.Value);
            }
        }

        static void soccerTask()
        {
            const string FILEPATH = @"C:\Users\user\Downloads\football.dat";
            
            var lines = File.ReadAllLines(FILEPATH).Skip(1);
            var records = lines.Select(line => Regex.Split(line.Trim(), "\\s+"));
            records = records.Where(r=>!r.First().StartsWith('-')); // skip the line with ------

            var sorted = records.Select(x =>
                    new KeyValuePair<string, int>(
                        x[1],
                        Math.Abs(Convert.ToInt32(x[6]) - Convert.ToInt32(x[8]))
                    )
                ).OrderBy(x => x.Value);

            var mostMin = sorted.First();
            var result = sorted.Where(x=>x.Value == mostMin.Value).ToList();

            foreach (var r in sorted)
            {
                Console.WriteLine(r.Key + " " + r.Value);
            }
        }

        static void dryTask()
        {
            string weatherFile = @"C:\Users\user\Downloads\weather.dat";
            parseTable(
                weatherFile, 
                lines => lines.Select(x =>
                        new KeyValuePair<string, int>(
                            x[0],
                            Math.Abs(Convert.ToInt32(x[1].Trim('*')) - Convert.ToInt32(x[2].Trim('*')))
                        )
                ),
                skipFirstRow:true,
                skipLastRow:true
            );

            string footballFile = @"C:\Users\user\Downloads\football.dat";
            parseTable(
                footballFile,
                lines => lines.Select(x =>
                        new KeyValuePair<string, int>(
                            x[1],
                            Math.Abs(Convert.ToInt32(x[6]) - Convert.ToInt32(x[8]))
                        )
                ),
                skipFirstRow:true,
                separators: new[]{'-'}
            );
        }

        /*
            filepath - path to the file
            action - function to extract needed data
            separators - array of symbols which used as rows separator
        */
        static void parseTable(
            string filepath,
            Func<IEnumerable<string[]>, IEnumerable<KeyValuePair<string, int>>> action,
            bool skipFirstRow = false,
            bool skipLastRow = false,
            char[]? separators = null)
        {
            var lines = File.ReadAllLines(filepath).AsEnumerable();

            if(skipFirstRow)
                lines = lines.Skip(1);
            if(skipLastRow)
                lines = lines.Take(lines.Count() - 1);

            lines = lines.Where(l => !string.IsNullOrWhiteSpace(l.Trim(separators))); // remove separation rows


            var splittedLines = lines.Select(line => Regex.Split(line.Trim(), "\\s+"));

            var filteredData = action(splittedLines).OrderBy(x=>x.Value);

            var mostMin = filteredData.First();
            var result = filteredData.Where(x => x.Value == mostMin.Value).ToList();

            foreach (var r in result)
            {
                Console.WriteLine(r.Key + " " + r.Value);
            }
        }
    }
}