// Problem: Given two strings s and t, return true if t is an anagram of s.
//
// --- Approach (Optimal) ---
// Use a fixed-size integer array of length 26 to count letter frequencies.
// Increment for each char in s, decrement for each char in t.
// If any count goes below zero, it's not an anagram.
//
// Steps:
// 1. Check if lengths differ → return false.
// 2. Count frequencies in s (+1).
// 3. Subtract frequencies for t (-1).
// 4. If any count < 0 → return false; otherwise return true.
//
// Time Complexity: O(n)
// Space Complexity: O(1)

public class Solution2 {
    public bool IsAnagram(string s, string t){
        if(s.Length != t.Length)
            return false
        
        var counts = new int[26];

        foreach(char c in s)
            counts[c - 'a']++;
        
        foreach(char c in t){
            counts[c - 'a']--;
            if(counts[c - 'a'] < 0)
                return false;
        }
        return true;
    }
}


// Problem: Given two strings s and t, return true if t is an anagram of s, and false otherwise.
//
// --- Approach 1 (Dictionary Comparison) ---
// Use two dictionaries to count the frequency of each character in both strings,
// then compare their frequency tables.
//
// Steps:
// 1. If lengths differ → return false immediately.
// 2. Count character occurrences for each string using Dictionary<char, int>.
// 3. Compare frequency counts of both dictionaries.
// 4. Return true only if all character counts match.
//
// Time Complexity: O(n)
// Space Complexity: O(k) → where k is the number of unique characters.
// Note: Works for any character set, but uses extra space (two dictionaries).


public class Solution {
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> ds = new Dictionary<char, int>();
        Dictionary<char, int> dt = new Dictionary<char, int>();

        foreach (var ch in s)
        {
            if (ds.ContainsKey(ch))
                ds[ch]++;
            else
                ds[ch] = 1;
        }

        foreach (var ch in t)
        {
            if (dt.ContainsKey(ch))
                dt[ch]++;
            else
                dt[ch] = 1;
        }

        foreach (var kv in ds)
        {
            if (!dt.ContainsKey(kv.Key) || dt[kv.Key] != kv.Value)
                return false;
        }

        return true;
    }
}
