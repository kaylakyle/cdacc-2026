D) SELECTION SORT ALGORITHM
Description: Finds the minimum element and swaps it with the first unsorted position.

Step-by-Step Diagram with Arrows:
Initial Array: [5, 8, 7, 2, 1, 9, 4, 3]

PASS 1: Find minimum in entire array and swap with first position

[5, 8, 7, 2, 1, 9, 4, 3]
 ↑                       ↑
Minimum = 1 at index 4
Swap 5 (index 0) with 1 (index 4):

[1, 8, 7, 2, 5, 9, 4, 3]
 ✓
1 in correct position

PASS 2: Find minimum from index 1 to end

[1, 8, 7, 2, 5, 9, 4, 3]
    ↑              ↑
Minimum = 2 at index 3
Swap 8 (index 1) with 2 (index 3):

[1, 2, 7, 8, 5, 9, 4, 3]
    ✓
1,2 in correct positions

PASS 3: Find minimum from index 2 to end

[1, 2, 7, 8, 5, 9, 4, 3]
       ↑              ↑
Minimum = 3 at index 7
Swap 7 (index 2) with 3 (index 7):

[1, 2, 3, 8, 5, 9, 4, 7]
       ✓
1,2,3 in correct positions

PASS 4: Find minimum from index 3 to end

[1, 2, 3, 8, 5, 9, 4, 7]
          ↑        ↑
Minimum = 4 at index 6
Swap 8 (index 3) with 4 (index 6):

[1, 2, 3, 4, 5, 9, 8, 7]
          ✓
1,2,3,4 in correct positions

PASS 5: Find minimum from index 4 to end

[1, 2, 3, 4, 5, 9, 8, 7]
             ↑        ↑
Minimum = 5 at index 4 (already in place)
No swap needed

[1, 2, 3, 4, 5, 9, 8, 7]
             ✓
1,2,3,4,5 in correct positions

PASS 6: Find minimum from index 5 to end

[1, 2, 3, 4, 5, 9, 8, 7]
                ↑     ↑
Minimum = 7 at index 7
Swap 9 (index 5) with 7 (index 7):

[1, 2, 3, 4, 5, 7, 8, 9]
                ✓
1,2,3,4,5,7 in correct positions

PASS 7: Find minimum from index 6 to end

[1, 2, 3, 4, 5, 7, 8, 9]
                   ↑  ↑
Minimum = 8 at index 6 (already in place)
No swap needed

[1, 2, 3, 4, 5, 7, 8, 9]
                   ✓
Array is fully sorted!
