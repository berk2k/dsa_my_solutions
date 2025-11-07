/*
    Example: "abcbc" -> "degeg"  (a → d, b → e, c → g)

    Conditions:
    - s.Length == t.Length
    - Only valid ASCII characters (0–127)
      -> Use two fixed-size char arrays for mapping
      -> Space Complexity: O(1)

    Approach1 (Optimal):
    - mapS: stores which character in t corresponds to a character in s
    - mapT: stores which character in s corresponds to a character in t
    - If both mappings are empty, create a new mapping.
    - If a mapping already exists, check for consistency.
    - If a mismatch occurs, return false.
    - If the loop finishes with no conflicts, return true.
    Time Complexity: O(n)
    Space Complexity: O(1)
*/
public class Solution {
    public bool IsIsomorphic(string s, string t) {
        char[] mapS = new char[128];
        char[] mapT = new char[128];

        for(int i = 0; i < s.Length; i++){
            if(mapS[s[i]] == '\0' && mapT[t[i]] == '\0')
            {    
                mapS[s[i]] = t[i];
                mapT[t[i]] = s[i];
            }
            else if(mapS[s[i]] != t[i])
                return false;
        }
        return true;
    }
}

/*
    Approach2 (Dictionary-based):
    - Use two hash maps (Dictionary<char, char>) instead of fixed-size arrays.
    - mapS: stores mapping from characters in s -> t
    - mapT: stores mapping from characters in t -> s
    - If both mappings don't exist, create a new pair.
    - If any mapping exists but is inconsistent, return false.
    - If all pairs are consistent, return true.
    Time Complexity: O(n)
    Space Complexity: O(n)   (due to dynamic dictionary storage)
*/

public class Solution2 {
    public bool IsIsomorphic(string s, string t){
        var mapS = new Dictionary<char, char>();
        var mapT = new Dictionary<char, char>();

        for (int i = 0; i < s.Length; i++)
        {
            char a = s[i];
            char b = t[i];

            if (!mapS.ContainsKey(a) && !mapT.ContainsKey(b))
            {
                mapS[a] = b;
                mapT[b] = a;
            }
            else if ((mapS.ContainsKey(a) && mapS[a] != b) ||
                    (mapT.ContainsKey(b) && mapT[b] != a))
            {
                return false;
            }
        }
        return true;
    }
}