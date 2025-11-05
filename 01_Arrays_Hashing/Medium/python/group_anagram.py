# Problem: Given an array of strings strs, group the anagrams together.
# You can return the answer in any order.
#
# --- Approach ---
# Use a defaultdict(list) to group words by their character frequency.
# Each word is represented by a 26-length array counting letters (a–z).
# Convert the count array to a tuple (hashable) and use it as a dictionary key.
#
# Steps:
# 1 Initialize a defaultdict(list) to store groups of anagrams.
# 2 For each word, count the frequency of each letter.
# 3 Use the frequency tuple as the key.
# 4 Append the word to the corresponding list in the dictionary.
# 5 Return all grouped values.
#
# Example:
# Input: ["eat","tea","tan","ate","nat","bat"]
# Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
#
# Time Complexity: O(n * k) — n = number of words, k = average word length
# Space Complexity: O(n * k)

from collections import defaultdict
from typing import List

class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        anagrams = defaultdict(list)

        for word in strs:
            count = [0] * 26
            for c in word:
                count[ord(c) - ord('a')] += 1

            key = tuple(count)
            anagrams[key].append(word)

        return list(anagrams.values())
