using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        //Create an empty List to store the result
        List<string> result = new List<string>(words.Length/2);

        //Intialize a Hash Set to store words without pairings
        HashSet<string> seenWords = new HashSet<string>();

        //Iterate through words
        foreach (string word in words)
        {
            //Check if the letters in the word pair are the same
            if(word[0] == word[1])
            {
                continue;
            }

            //Generate the reverse of a word
            string reversed = new string(new char[] { word[1], word[0] });

            //Check if the reversed word is found in seenWords
            if (seenWords.Contains(reversed))
            {
                //If it is, concatenate word and reversed and add it to result
                result.Add($"{reversed} & {word}");
            }
            else
            {
                //Otherwise, add word to seenWords
                seenWords.Add(word);
            }
        }
        //Convert the list to an array and return it
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            //Get the degree and store it in a string
            string degree = fields[3];

            // If the degree is already in the dictionary, increase the count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            // Otherwise, add it to the dictionary with a count of 1
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        //Format both words to remove spaces and convert to undercase
        string formattedWord1 = word1.ToLower().Replace(" ", "");
        string formattedWord2 = word2.ToLower().Replace(" ", "");

        //Checks if the both words are of different lengths
        if(formattedWord1.Length != formattedWord2.Length)
        {
            return false;
        }

        //Initialize a dictionary in order to count the characters
        Dictionary<char, int> charCount = new Dictionary<char, int>();


        //Loops through the first word and counts character repetitions
        for (int i = 0; i < formattedWord1.Length; i++)
        {
            char c = formattedWord1[i];
            //if a character already exists increase the count by 1
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            //else create a new entry in the dictionary and map it to one
            else
            {
                charCount[c] = 1;
            }
        }

        //Loops through the second word
        for (int i = 0; i < formattedWord2.Length; i++)
        {
            char c = formattedWord2[i];
            
            //If the character doesn't exist in the Dictionary or if the character repeats more times than the first word, return false
            if (!charCount.ContainsKey(c) || charCount[c] == 0)
            {
                return false;
            }
            
            //Subtracts the count from the dictionary at the index of the character
            charCount[c]--;
        }

        //return true since every letter matches between both words
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}