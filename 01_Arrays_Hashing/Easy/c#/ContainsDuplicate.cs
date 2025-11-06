// Problem: Given an integer array nums, return true if any value appears at least twice in the array,
// and return false if every element is distinct.
/

// --- Approach 1 (Initial Attempt) ---
// Using a Dictionary to track elements. However, this approach is inefficient
// because Dictionary.ContainsValue() has O(n) time complexity per call,
// leading to an overall O(n^2) solution.
public class Solution {
    public bool hasDuplicate(int[] nums) {
        Dictionary<int,int>map = new Dictionary<int,int>();

        for(int i=0; i<nums.Length; i++){
            if(!map.ContainsValue(nums[i])){
                map[i] = nums[i];
            }
            else{
                return true;
            }
        }
        return false;
    }
}

// --- Approach 2 (Optimized Solution) ---
// Using a HashSet to store seen numbers. 
// For each number, we check if it's already in the set.
// If yes → duplicate found, return true.
// If no → add it to the set.
// Time Complexity: O(n)
// Space Complexity: O(n)
public class Solution {
    public bool hasDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (set.Contains(num))
                return true;

            set.Add(num);
        }

        return false;
    }
}