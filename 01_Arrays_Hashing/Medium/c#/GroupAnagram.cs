// Problem: Given an array of strings strs, group the anagrams together.
// You can return the answer in any order.
//
// --- Approach 1: Character Frequency (Optimized) ---
// Use a Dictionary<string, List<string>> to group words by their character frequency.
// Each word is represented by a 26-length integer array counting letters (a–z).
// Convert the count array to a unique key (joined string) and store all anagrams under that key.
//
// Steps:
// 1 Initialize a dictionary to map frequency-signature → list of words.
// 2 For each word, count the frequency of each character.
// 3 Use the frequency array as the key (converted to a string).
// 4 Add the word to its group in the dictionary.
// 5 Return all grouped values.
//
// Example:
// Input: ["eat","tea","tan","ate","nat","bat"]
// Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
//
// Time Complexity: O(n * k) — n = number of words, k = average word length
// Space Complexity: O(n * k)

public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, List<string>>();

        foreach(var word in strs){
            int[] count = new int[26];

            foreach(var c in word)
                count[c - 'a']++;

            string key = string.Join("#", count);

            if(!dict.ContainsKey(key))
                dict[key] = new List<string>();
            
            dict[key].Add(word);
        }
        return dict.Values.ToList<List<string>>();
    }
}

// --- Approach 2: Sorting-based (Simpler but Slower) ---
// Sort each word alphabetically and use the sorted string as the key.
// Easier to implement, but sorting each word adds O(k log k) cost.
//
// Time Complexity: O(n * k log k)
// Space Complexity: O(n * k)
public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var anagrams = new Dictionary<string, List<string>>();

        foreach(var word in strs){
            var key = String.Concat(word.OrderBy(c => c));
            if (!anagrams.ContainsKey(key))
                anagrams[key] = new List<string>();
            anagrams[key].Add(word);
        }
        return anagrams.Values.ToList<List<string>>();
    }
}