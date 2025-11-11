/*
-----Approach 1 (Brute Force Solution)-------

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
    -> Time Complexity: O(N²) -> Quadratic, since every pair is compared.
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
