// Problem: Given an array of integers nums and an integer target,
// return indices of the two numbers such that they add up to target.
//
// --- Approach ---
// Use a Dictionary (Hash Map) to store each number and its index as we iterate.
// For each element, compute its complement (target - nums[i]).
// If the complement already exists in the map, we found the two numbers.
//
// Steps:
// 1- Loop through each number in the array.
// 2- For each number, calculate complement = target - nums[i].
// 3- Check if complement exists in the dictionary → if yes, return indices.
// 4- Otherwise, store current number with its index in the map.
//
// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int>map = new Dictionary<int,int>();

        for(int i=0; i<nums.Length; i++){
            int complement = target - nums[i];
            if(map.ContainsKey(complement))
                return new int[] {map[complement],i};
            
            if(!map.ContainsKey(complement))
                map.Add(nums[i],i);
        }
        return new int[0];
    }
}