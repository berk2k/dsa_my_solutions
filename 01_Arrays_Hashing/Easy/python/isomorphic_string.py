"""
    -> valid ascii chars
        -> 128 fixed size
            -> space complexity: O(1)
    -> t.length == s.length

    -> mapping
        -> 2 arrays
        -> 'a' = arr[96], 'b' = arr[97]
    -> time complexity : O(n)
"""

class Solution:
    def isIsomorphic(self, s: str, t: str) -> bool:
        map_s = [0] * 128
        map_t = [0] * 128
        n = len(s)
        for i in range(n):
            c1 = ord(s[i])
            c2 = ord(t[i])
            if map_s[c1] == 0 and map_t[c2] == 0:
                map_s[c1] = t[i]
                map_t[c2] = s[i]

            if map_s[c1] != t[i]:
                return False
        return True

        