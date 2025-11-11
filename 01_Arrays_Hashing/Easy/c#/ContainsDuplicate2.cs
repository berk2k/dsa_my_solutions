/*
----- Optimal Solution - Sliding Window --------

    -> Uses a sliding window of size 'k' and a HashSet to track seen elements.
    -> At each step, check if nums[i] already exists in the window:
        -> If yes, return true (duplicate found within distance k).
        -> If no, add nums[i] to the set.
    -> If the window size exceeds k, remove the oldest element (nums[i - k]).
    -> Continue until the end of the array.
    -> If no duplicates found, return false.

Algorithm:
    -> Initialize an empty HashSet<int> (for constant-time lookup).
    -> Iterate through each element in nums:
        -> If the element exists in the set, return true.
        -> Otherwise, add it to the set.
        -> If the set size becomes greater than k, remove nums[i - k].
    -> Return false if the loop completes without finding duplicates.

Complexity:
    -> Time Complexity: O(N) -> Each element is added/removed at most once.
    -> Space Complexity: O(k) -> The set stores up to k elements at a time.
*/

public class SolutionOptimal {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        HashSet<int> seen = new HashSet<int>();

        for(int i = 0; i < nums.Length; i++){
            if(seen.Contains(nums[i]))
                return true;
            seen.Add(nums[i]);

            if(seen.Count > k)
                seen.Remove(nums[i - k]);
        }
        return false;
    }
}


/*
-----Approach 2 (Optimal using Dictionary)-------

    -> Uses a Dictionary<int, int> to keep track of the last seen index of each number.
    -> For every element in nums:
        -> If the number has been seen before (exists in the dictionary):
            -> Calculate the index difference between the current index and the last seen index.
            -> If the difference <= k, return true (valid nearby duplicate found).
        -> Otherwise, or after checking, update the dictionary with the current index for this number.
    -> If the loop finishes without finding any valid pair, return false.

Algorithm:
    -> Initialize an empty Dictionary<int, int>.
    -> Iterate over nums with index i:
        -> If nums[i] is already in the dictionary:
            -> Check if (i - map[nums[i]]) <= k -> if yes, return true.
        -> Update map[nums[i]] = i (store the most recent index).
    -> Return false if no valid nearby duplicates are found.

Key–Value Meaning:
    -> key   = nums[i]        -> the number itself
    -> value = last index (i) -> where this number was last seen

Complexity:
    -> Time Complexity: O(N) -> Each element is processed once.
    -> Space Complexity: O(N) -> Dictionary may store up to all unique elements.
*/

public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            if (map.ContainsKey(nums[i])) {
                if (i - map[nums[i]] <= k)
                    return true;
            }
            map[nums[i]] = i; // key = number, value = last seen index
        }

        return false;
    }
}


/*
----- Brute Force Solution -------
    PS: this solution can cause: time limit exceeded error.

    -> Compare every pair of elements (i, j) in the array.
    -> If nums[i] == nums[j] and |i - j| <= k, return true.
    -> If no such pair is found after all comparisons, return false.

Algorithm:
    -> Iterate through each element i from 0 to N-1.
    -> For each i, iterate through j = i+1 to N-1.
    -> If nums[i] == nums[j]:
        -> Compute the absolute difference between indices (|i - j|).
        -> If the difference <= k, return true immediately.
    -> If the loops finish without finding a valid pair, return false.

Complexity:
    -> Time Complexity: O(N^2) -> Quadratic, since every pair is compared.
    -> Space Complexity: O(1) -> Constant space, only a few variables used.
*/

public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] == nums[j]) {
                    int abs = Math.Abs(i - j);
                    if (abs <= k)
                        return true;
                }
            }
        }
        return false;
    }
}
