"""
    -> Problem
        -> Determine if a number is a 'Happy Number' using Floyd’s Cycle Detection.
        -> Replace the number with the sum of the squares of its digits repeatedly.
        -> If it reaches 1 -> happy; if it enters a cycle -> not happy.

    -> Approach (Floyd’s Cycle Detection)
        -> Use two pointers:
            - slow moves one step at a time
            - fast moves two steps at a time
        -> If they meet at 1 -> happy number
        -> If they meet elsewhere -> cycle detected (not happy)
        -> This avoids using extra memory (O(1) space).

    -> Complexity
        -> Time:  O(k × log n) -> O(log n)
        -> Space: O(1)
"""

class Solution:
    def _next(self,n: int) -> int:
        sum = 0
        while n > 0:
            digit = n % 10
            sum += int(digit) ** 2
            n //= 10
        return sum

    def isHappy(self, n: int) -> bool:
        slow = n
        fast = self._next(n)
        while fast != 1 and slow != fast:
            slow = self._next(slow)
            fast = self._next(self._next(fast))
        return fast == 1
        




"""
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

    -> Time Complexity
        -> Each iteration processes all digits → O(log n)
        -> The sequence length (k) is small and independent of n
           → Total: O(k × log n) -> O(log n)
           (not O(n × log n) because n is a numeric value, not number of items)

    -> Space Complexity
        -> O(k) due to the 'seen' set (bounded, small constant space)
"""
class Solution:
    def isHappy(self, n: int) -> bool:
        seen = set()

        while n != 1 and n not in seen:
            seen.add(n)
            sum = 0
            while n > 0:
                digit = n % 10
                sum += int(digit) ** 2
                n //= 10 
            n = sum
        return n == 1