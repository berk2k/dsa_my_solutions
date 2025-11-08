/*
    -> pattern 
        -> only lowercase English letters (max 26 unique)
        -> 1 <= pattern.length <= 300
    -> s 
        -> lowercase English letters + single spaces
        -> 1 <= s.length <= 3000
        -> no leading or trailing spaces
        -> words separated by a single space
    
    -> Approach
        -> Split s by spaces to get words
        -> Use:
            - string[26] mapChar : pattern char → word mapping
            - Dictionary<string, char> mapWord : word → pattern char mapping
        -> Ensure one-to-one consistency in both directions
        -> Time:  O(n)
        -> Space: O(n)
        -> Optimal solution for given constraints
*/



public class Solution {
    public bool WordPattern(string pattern, string s) {
        var words = s.Split(' ');

        if(words.Length != pattern.Length)
            return false;
        
        string[] mapChar = new string[26];
        Dictionary<string, char> mapWord = new();

        for(int i = 0; i < pattern.Length; i++){
            int index = pattern[i] - 'a';
            string word = words[i];

            if(mapChar[index] == null && !mapWord.ContainsKey(word)){
                mapChar[index] = word;
                mapWord[word] = pattern[i];
            }
            else{
                if(mapChar[index] != word)
                    return false;
                if(mapWord.ContainsKey(word) && mapWord[word] != pattern[i])
                    return false;
            }
        }
        return true;
    }
}