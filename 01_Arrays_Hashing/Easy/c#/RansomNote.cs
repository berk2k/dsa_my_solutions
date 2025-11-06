/*
-----Approach 1 (Optimal solution)-------

    -> Inputs contain only lowercase English letters (a-z).
    -> Comparison is case-sensitive.
    -> If ransomNote.Length > magazine.Length, return false.
    -> There are only 26 possible characters.

Algorithm:
    ->Count the frequency of each character in magazine using an array of size 26.
    ->Iterate through ransomNote:
    ->If a character’s count is 0, return false.
    ->Otherwise, decrement its frequency.
    ->If all characters are available, return true.

Complexity:
    -> Time Complexity: O(m + n) -> O(n) ->linear in input size.
    -> Space Complexity: O(1) -> constant space (only 26 letters).
*/
public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if(ransomNote.Length > magazine.Length)
            return false;

        var counts = new int[26];
        foreach(char c in magazine)
            counts[c - 'a']++; // frequency
        
        foreach(char c in ransomNote){
            if(counts[c - 'a'] == 0){
                return false;
            }
            counts[c - 'a']--;
        }
        return true;
    }
}

/*
-----Approach 2 (Dictionary solution)-------

    -> Works with any character set (not only a-z).
    -> Uses a Dictionary<char, int> to store frequencies.
    -> If ransomNote.Length > magazine.Length, return false.

Algorithm:
    -> Count frequency of each character in magazine.
    -> Iterate through ransomNote:
        -> If char not found or count is 0, return false.
        -> Otherwise, decrement the count.
    -> If all characters are found, return true.

Complexity:
    -> Time Complexity: O(m + n) -> O(n)
    -> Space Complexity: O(k) where k = number of unique characters.
*/

public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if (ransomNote.Length > magazine.Length)
            return false;
        var counts = new Dictionary<char, int>();

        foreach (char c in magazine) {
            if (!counts.ContainsKey(c))
                counts[c] = 0;
            counts[c]++;
        }

        foreach (char c in ransomNote) {
            if (!counts.ContainsKey(c) || counts[c] == 0)
                return false;
            counts[c]--;
        }

        return true;
    }
}

/*
-----Approach 3 (LINQ version)-------

    -> Uses LINQ to count character frequencies in both strings.
    -> Works with any character set.
    -> More readable but less efficient than array or dictionary approach.

Algorithm:
    -> For each character in ransomNote, 
       check if its count in ransomNote <= its count in magazine.
    -> If this holds for all characters, return true; otherwise, false.

Complexity:
    -> Time Complexity: O(n * k) (repeated counting)
    -> Space Complexity: O(k) where k = number of unique characters.
*/

public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        return ransomNote.Distinct().All(c =>
            ransomNote.Count(x => x == c) <= magazine.Count(x => x == c));
    }
}