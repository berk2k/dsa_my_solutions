/*
    ---- Optimal approach space complexity O(1) ---- 
    -> Problem
        -> Determine if a number is a "happy number" using Floyd’s Cycle Detection.
        -> Replace the number with the sum of squares of its digits repeatedly.
        -> If it reaches 1 → happy. If it loops forever → not happy.

    -> Approach (Floyd's Cycle Detection)
        -> No HashSet needed.
        -> Use two pointers:
            - slow moves one step at a time
            - fast moves two steps at a time
        -> If they meet at 1 → happy
           else if they meet elsewhere → not happy

    -> Helper function:
        -> next(n): returns the sum of the squares of the digits of n.

    -> Complexity
        -> Time:  O(log n × k)
        -> Space: O(1)
*/

public class Solution2 {
    // Helper function to compute sum of squares of digits
    private int Next(int n) {
        int sum = 0;
        while (n > 0) {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }
        return sum;
    }

    public bool IsHappy(int n) {
        int slow = n;
        int fast = Next(n);

        // Move slow by 1 step, fast by 2 steps
        while (fast != 1 && slow != fast) {
            slow = Next(slow);
            fast = Next(Next(fast));
        }

        // If fast reached 1, it’s a happy number
        return fast == 1;
    }
}




/*
    -> Problem
        -> A number is called a "Happy Number" if by repeatedly replacing it 
           with the sum of the squares of its digits, we eventually reach 1.
        -> If we fall into a cycle that does not include 1, the number is not happy.
    
    -> Constraints
        -> 1 <= n <= 2^31 - 1
        -> The number can have multiple digits.

    -> Approach
        -> Use a HashSet<int> to record all numbers that have been seen.
           If a number repeats, we are in a cycle -> return false.
        -> For each step:
            - Split the number into its digits.
            - Compute the sum of squares of all digits.
            - Replace n with this sum.
        -> Continue until:
            - n == 1  -> return true
            - or n is repeated -> return false

    -> Complexity
        -> Time:  O(log n) * k     (each iteration processes all digits; k = number of iterations)
        -> Space: O(k)             (due to HashSet for visited numbers)
*/

public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> seen = new HashSet<int>();
        
        while (n != 1 && !seen.Contains(n)) {
            seen.Add(n);
            int sum = 0;

            while (n > 0) {
                int digit = n % 10;      // extract last digit
                sum += digit * digit;    // add its square
                n /= 10;                 // remove last digit
            }

            n = sum; // assign the new number for the next iteration
        }

        return n == 1;
    }
}
