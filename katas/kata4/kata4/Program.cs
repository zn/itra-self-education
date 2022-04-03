using System.Text.RegularExpressions;

namespace kata4
{
    public class Program
    {
        
        public static void Main()
        {
            //weatherTask();
            soccerTask();
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
    }
}