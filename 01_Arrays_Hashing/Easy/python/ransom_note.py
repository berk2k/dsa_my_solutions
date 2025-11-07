"""
    -> ransom.length <= magazine.length
    -> lowercase english letters
        -> 26 letters 
            -> space complexity O(1)

    -> store frequency of letters(magazine)
    if a then frequency --
    if frequency < 0
        -> return False
    
    -> time complexity O(n)
    -> space complexity O(1)
"""

class Solution:
    def canConstruct(self, ransomNote: str, magazine: str) -> bool:
        if len(ransomNote) > len(magazine):
            return False
        
        counts = [0] * 26
        for char in magazine:
            counts[ord(char) - ord('a')] += 1

        for char in ransomNote:
            counts[ord(char) - ord('a')] -=1
            if counts[ord(char) - ord('a')] < 0:
                return False
        return True