B) QUICK SORT ALGORITHM
Description: Divides array around a pivot, places smaller elements left, larger right, then recursively sorts sub-arrays.

Step-by-Step Diagram with Arrows:
Initial Array: [5, 8, 7, 2, 1, 9, 4, 3]



STEP 1: Choose Pivot (usually last element = 3)
        ↓
[5, 8, 7, 2, 1, 9, 4, 3]
 Pivot = 3

STEP 2: Partition - elements < 3 go left, > 3 go right

Compare 5 with 3: 5 > 3 → keep right side
Compare 8 with 3: 8 > 3 → keep right side
Compare 7 with 3: 7 > 3 → keep right side
Compare 2 with 3: 2 < 3 → swap with first element >3

[5, 8, 7, 2, 1, 9, 4, 3]
 ↑        ↑
Swap 5 and 2:

[2, 8, 7, 5, 1, 9, 4, 3]
    ↑        ↑
Compare 1 with 3: 1 < 3 → swap with next position

[2, 8, 7, 5, 1, 9, 4, 3]
    ↑        ↑
Swap 8 and 1:

[2, 1, 7, 5, 8, 9, 4, 3]
       ↑           ↑
Compare remaining with 3 (all >3)

Finally place pivot (3) in correct position:

[2, 1, 3, 5, 8, 9, 4, 7]
          ↑
Pivot 3 in correct position

Left of pivot: [2, 1]
Right of pivot: [5, 8, 9, 4, 7]

STEP 3: Recursively sort left subarray [2, 1]

[2, 1]  Pivot = 1
 ↓
Compare 2 with 1: 2 > 1 → keep right
Place pivot: [1, 2]

STEP 4: Recursively sort right subarray [5, 8, 9, 4, 7]
Pivot = 7

[5, 8, 9, 4, 7]
          ↑
Compare 5 with 7: 5 < 7 → keep left
Compare 8 with 7: 8 > 7 → keep right
Compare 9 with 7: 9 > 7 → keep right
Compare 4 with 7: 4 < 7 → swap with 8

[5, 8, 9, 4, 7]  →  [5, 4, 9, 8, 7]
    ↑        ↑          ↑
    8 and 4 swapped

Place pivot 7:

[5, 4, 7, 8, 9]
       ↑
Pivot 7 in position

Left of 7: [5, 4]
Right of 7: [8, 9]

Sort [5, 4] with pivot 4 → [4, 5]
[8, 9] already sorted

Final combination:
[1, 2] + [3] + [4, 5] + [7] + [8, 9]


quick sort tree diagram

                    [5, 8, 7, 2, 1, 9, 4, 3]
                              |
                    Pivot=3, Partition
                    /            \
              [2, 1]              [5, 8, 9, 4, 7]
                 |                    Pivot=7
            Pivot=1                   /        \
              |                  [5, 4]        [8, 9]
           [1, 2]              Pivot=4          |
                                  |           [8, 9]
                               [4, 5]
                                   \
                                    [4, 5, 7, 8, 9]
                                      \
                              [1, 2, 3, 4, 5, 7, 8, 9]
