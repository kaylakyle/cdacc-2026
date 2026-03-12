task a)
Method 1: Binary Search Tree  Construction
In a Binary Search Tree, for each node:

Left child contains values less than the parent node

Right child contains values greater than the parent node

Duplicate values (like 28) can be handled by placing on either side (commonly right)


step by step construction

STEP 1: Insert 18 (Root)
        
                 18

STEP 2: Insert 17 (17 < 18 → go left)
        
                 18
                /
              17

STEP 3: Insert 6 (6 < 18 → left, 6 < 17 → left)
        
                 18
                /
              17
              /
            6

STEP 4: Insert 9 (9 < 18 → left, 9 < 17 → left, 9 > 6 → right)
        
                 18
                /
              17
              /
            6
             \
              9

STEP 5: Insert 20 (20 > 18 → right)
        
                 18
                /  \
              17    20
              /
            6
             \
              9

STEP 6: Insert 19 (19 > 18 → right, 19 < 20 → left)
        
                 18
                /  \
              17    20
              /    /
            6    19
             \
              9

STEP 7: Insert 28 (28 > 18 → right, 28 > 20 → right)
        
                 18
                /  \
              17    20
              /    /  \
            6    19    28
             \
              9

STEP 8: Insert 28 (duplicate) (28 > 18 → right, 28 > 20 → right, 28 = 28 → go right)
        
                 18
                /  \
              17    20
              /    /  \
            6    19    28
             \         \
              9         28

STEP 9: Insert 27 (27 > 18 → right, 27 > 20 → right, 27 < 28 → left)
        
                 18
                /  \
              17    20
              /    /  \
            6    19    28
             \       /  \
              9     27   28

STEP 10: Insert 33 (33 > 18 → right, 33 > 20 → right, 33 > 28 → right)
        
                 18
                /  \
              17    20
              /    /  \
            6    19    28
             \       /  \
              9     27   28
                          \
                          33

STEP 11: Insert 16 (16 < 18 → left, 16 < 17 → left, 16 > 6 → right, 16 < 9? No → 16 > 9 → right)
        
                 18
                /  \
              17    20
              /    /  \
            6    19    28
             \       /  \
              9     27   28
               \         \
               16         33

STEP 12: Insert 22 (22 > 18 → right, 22 > 20 → right, 22 < 28 → left, 22 < 27 → left)
        
                 18
                /  \
              17    20
              /    /  \
            6    19    28
             \       /  \
              9     27   28
               \   /      \
               16 22       33

STEP 13 : Insert 4 (4 < 18 - left, 4 < 17 left, 4 < 6 left )

final structure

                     18
                   /    \
                 17      20
                /       /  \
               6       19    28
              /  \          /  \
             4    9        27   28
                  \      /      \
                  16    22       33




