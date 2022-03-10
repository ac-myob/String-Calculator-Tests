namespace StringCalculator;



public class StringCalculator {
    private string openSingleDelim = "//";
    private string openMultiDelim = "//[";
    private string closeMultiDelim = "]\n";

    public string[] getDelimiters(string word) {
        string[] delimiters = {",", "\n"};
        // Case 1: Additional multi-character delimiter
        // getDelimiters("//[xxx]\n1xxx2") => [",", "\n", "xxx"]
        // getDelimiters("//[x][y]\n1x2y3") => [",", "\n", "x", "y"]
        if (word.IndexOf(openMultiDelim) != -1) {
            int startIndexOfMultiDelim = word.IndexOf(openMultiDelim) + openMultiDelim.Length;
            int endIndexOfMultiDelim = word.IndexOf(closeMultiDelim) - 1;
            int lengthOfDelim = endIndexOfMultiDelim - startIndexOfMultiDelim + 1;
            // [x][yy][zzz][%] => x][yy][zzz][% -> call .split("][")
            string delimsWithoutBrackets = word.Substring(startIndexOfMultiDelim,lengthOfDelim);
            string[] delimsInArray = delimsWithoutBrackets.Split("][");
            delimiters = delimiters.Concat(delimsInArray).ToArray();
        }
        // Case 2: Additional single-character delimiter
        // getDelimiter("//\n\n1\n2") => [",", "\n", "\n"]
        else if (word.IndexOf(openSingleDelim) != -1) {
            delimiters = delimiters.Concat(new string[] {word[2].ToString()}).ToArray();
        }

        // Case 3: Default delimiters
        return delimiters;
    }

    public string getword(string word) {
        int startingIndexOfWord;
        // Case 1: Additional multi-character delimiter
        // getWord("//[xxx]\n1xxx2") => "1xxx2"
        if (word.IndexOf(openMultiDelim) != -1) {
            startingIndexOfWord = word.IndexOf(closeMultiDelim) + closeMultiDelim.Length;
        }
        // Case 2: Additional single-character delimiter
        // getWord("//\n\n1\n2") => "1\n2"
        else if (word.IndexOf(openSingleDelim) != -1) {
            startingIndexOfWord = 4;
        }
        // Case 3: No additional delimiter
        // getWord("1,2") => "1,2"
        else {
            startingIndexOfWord = 0;
        }
        return word.Substring(startingIndexOfWord);
    }

    public void checkNonNegativeArray(int[] arr) {
        if (arr.Any(x => x < 0)) {
            throw new NegativeNumberException("Negative numbers not allowed");
        }
    }

    public int Add(string word) {
        if (word.Length == 0) {
            return 0;
        }
        else {
            int[] arrayOfNums = 
            getword(word).
            Split(getDelimiters(word), StringSplitOptions.None).
            Select(x => Convert.ToInt32(x)).
            Where(x => x < 1000).
            ToArray();

            checkNonNegativeArray(arrayOfNums);

            return arrayOfNums.Sum();
        }
    }
}