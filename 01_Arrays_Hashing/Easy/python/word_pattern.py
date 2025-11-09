"""
    -> Problem
        -> Given a pattern (string of lowercase letters) and a sentence s,
           determine if s follows the same pattern.
        -> Each unique character in pattern should map to a unique word in s (bijective mapping).
    
    -> Example
        -> pattern = "abba", s = "dog cat cat dog"  -> True
        -> pattern = "abba", s = "dog cat cat fish" -> False
    
    -> Constraints
        -> pattern consists of lowercase English letters only
        -> s contains lowercase words separated by a single space
        -> 1 <= len(pattern) <= 300
        -> 1 <= len(s) <= 3000
    
    -> Approach
        -> Split s by spaces -> list of words
        -> If word count != pattern length -> False
        -> Use:
            - mapChar: fixed array of size 26 (pattern char -> word)
            - mapWord: dictionary (word -> pattern char)
        -> Check consistency both ways to ensure one-to-one mapping
    
    -> Complexity
        -> Time:  O(n)
        -> Space: O(1) for mapChar + O(k) for mapWord (k = unique words)
"""
class Solution:
    def wordPattern(self, pattern: str, s: str) -> bool:
        words = s.split(" ")
        if len(words) != len(pattern):
            return False
        mapChar = [None] * 26
        mapWord = {}

        for i in range(len(pattern)):
            index = ord(pattern[i]) - ord('a')
            word = words[i]

            if mapChar[index] == None and word not in mapWord:
                mapChar[index] = word
                mapWord[word] = pattern[i]
            else:
                if mapChar[index] != word:
                    return False
                if word in words and mapWord[word] != pattern[i]:
                    return False  
        return True


        