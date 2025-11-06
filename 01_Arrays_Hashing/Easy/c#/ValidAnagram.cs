// Problem: Given two strings s and t, return true if t is an anagram of s, and false otherwise.
//
// --- Approach ---
// Use two dictionaries (hash maps) to count the frequency of each character in both strings.
// Then compare the counts: if they match for all characters, the strings are anagrams.
//
// Steps:
// 1-Check if lengths are different → return false immediately.
// 2-Count character occurrences for each string using Dictionary<char, int>.
// 3-Compare frequency tables of both dictionaries.
// 4-Return true only if all character counts match.
//
// Time Complexity: O(n)
// Space Complexity: O(1) → technically O(26) for lowercase English letters, or O(k) for unique characters.

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
