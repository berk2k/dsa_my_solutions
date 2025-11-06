"""
-----Approach 1 (Optimal solution)-------

-> Both strings contain only lowercase English letters (a-z).
-> Inputs can be empty.
-> Use an array of size 26 to count character frequencies.

Algorithm:
    -> If lengths of s and t differ, return False.
    -> Count the frequency of each character in s.
    -> Decrease the frequency for each character in t.
    -> If all counts return to zero, return True.

Complexity:
    -> Time Complexity: O(n)
    -> Space Complexity: O(1)
"""


class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        if len(s) != len(t): 
            return False
        count = [0] * 26
        for c in s:
            count[ord(c) - ord('a')] += 1

        for c in t:
            count[ord(c) - ord('a')] -= 1
            if count[ord(c) - ord('a')] < 0:
                return False
        return True