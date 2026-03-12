Description: Divides array into halves, recursively sorts them, then merges the sorted halves.

Step-by-Step Diagram with Arrows:

INITIAL ARRAY: [5, 8, 7, 2, 1, 9, 4, 3]

STEP 1: Divide into halves until single elements

                    [5, 8, 7, 2, 1, 9, 4, 3]
                           /            \
                          /              \
              [5, 8, 7, 2]              [1, 9, 4, 3]
                /        \                /        \
               /          \              /          \
          [5, 8]        [7, 2]        [1, 9]        [4, 3]
           /    \        /    \        /    \        /    \
          /      \      /      \      /      \      /      \
        [5]     [8]   [7]     [2]   [1]     [9]   [4]     [3]

STEP 2: Merge pairs back in sorted order

        Merge [5] and [8]:
        Compare 5 and 8 → 5 < 8
        [5, 8]  ← 5 then 8

        Merge [7] and [2]:
        Compare 7 and 2 → 2 < 7
        [2, 7]  ← 2 then 7

        Merge [1] and [9]:
        Compare 1 and 9 → 1 < 9
        [1, 9]  ← 1 then 9

        Merge [4] and [3]:
        Compare 4 and 3 → 3 < 4
        [3, 4]  ← 3 then 4

STEP 3: Merge [5, 8] and [2, 7]

[5, 8] and [2, 7]
 ↓       ↓
Compare 5 and 2 → 2 < 5 → take 2
Result: [2, _, _, _]

[5, 8] and [7]
 ↓       ↓
Compare 5 and 7 → 5 < 7 → take 5
Result: [2, 5, _, _]

[8] and [7]
 ↓    ↓
Compare 8 and 7 → 7 < 8 → take 7
Result: [2, 5, 7, _]

[8] remains → take 8
Result: [2, 5, 7, 8]

STEP 4: Merge [1, 9] and [3, 4]

[1, 9] and [3, 4]
 ↓       ↓
Compare 1 and 3 → 1 < 3 → take 1
Result: [1, _, _, _]

[9] and [3, 4]
 ↓    ↓
Compare 9 and 3 → 3 < 9 → take 3
Result: [1, 3, _, _]

[9] and [4]
 ↓    ↓
Compare 9 and 4 → 4 < 9 → take 4
Result: [1, 3, 4, _]

[9] remains → take 9
Result: [1, 3, 4, 9]

STEP 5: Final Merge - [2, 5, 7, 8] and [1, 3, 4, 9]

[2, 5, 7, 8] and [1, 3, 4, 9]
 ↓            ↓
Compare 2 and 1 → 1 < 2 → take 1
Result: [1, _, _, _, _, _, _, _]

[2, 5, 7, 8] and [3, 4, 9]
 ↓            ↓
Compare 2 and 3 → 2 < 3 → take 2
Result: [1, 2, _, _, _, _, _, _]

[5, 7, 8] and [3, 4, 9]
 ↓         ↓
Compare 5 and 3 → 3 < 5 → take 3
Result: [1, 2, 3, _, _, _, _, _]

[5, 7, 8] and [4, 9]
 ↓         ↓
Compare 5 and 4 → 4 < 5 → take 4
Result: [1, 2, 3, 4, _, _, _, _]

[5, 7, 8] and [9]
 ↓         ↓
Compare 5 and 9 → 5 < 9 → take 5
Result: [1, 2, 3, 4, 5, _, _, _]

[7, 8] and [9]
 ↓      ↓
Compare 7 and 9 → 7 < 9 → take 7
Result: [1, 2, 3, 4, 5, 7, _, _]

[8] and [9]
 ↓    ↓
Compare 8 and 9 → 8 < 9 → take 8
Result: [1, 2, 3, 4, 5, 7, 8, _]

[9] remains → take 9
Result: [1, 2, 3, 4, 5, 7, 8, 9]


merge sort tree diagram 

                    [5, 8, 7, 2, 1, 9, 4, 3]
                           /            \
                          /              \
              [5, 8, 7, 2]              [1, 9, 4, 3]
                /        \                /        \
               /          \              /          \
          [5, 8]        [7, 2]        [1, 9]        [4, 3]
           /    \        /    \        /    \        /    \
          /      \      /      \      /      \      /      \
        [5]     [8]   [7]     [2]   [1]     [9]   [4]     [3]
         |       |     |       |     |       |     |       |
        [5]     [8]   [7]     [2]   [1]     [9]   [4]     [3]
           \    /        \    /        \    /        \    /
            \  /          \  /          \  /          \  /
          [5, 8]        [2, 7]        [1, 9]        [3, 4]
               \        /                  \        /
                \      /                    \      /
              [2, 5, 7, 8]                [1, 3, 4, 9]
                      \                      /
                       \                    /
                    [1, 2, 3, 4, 5, 7, 8, 9]