using System;

class SortingDemo
{
    // Bubble Sort 
    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    //  Selection Sort 
    public static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIdx])
                    minIdx = j;
            }
            int temp = arr[minIdx];
            arr[minIdx] = arr[i];
            arr[i] = temp;
        }
    }

    // - Quick Sort 
    public static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            QuickSort(arr, low, pi - 1);   // Left side
            QuickSort(arr, pi + 1, high);  // Right side
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // pivot element
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1;
    }

    //  Merge Sort 
    public static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    private static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++) L[i] = arr[left + i];
        for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

        int x = 0, y = 0, k = left;
        while (x < n1 && y < n2)
        {
            if (L[x] <= R[y])
            {
                arr[k++] = L[x++];
            }
            else
            {
                arr[k++] = R[y++];
            }
        }

        while (x < n1) arr[k++] = L[x++];
        while (y < n2) arr[k++] = R[y++];
    }
}

class Program
{
    static void Main()
    {
        int[] arr = { 5, 8, 7, 2, 1, 9, 4, 3 };

        // Bubble Sort
        int[] bubbleArr = (int[])arr.Clone();
        SortingDemo.BubbleSort(bubbleArr);
        Console.WriteLine("Bubble Sorted:   " + string.Join(", ", bubbleArr));

        // Selection Sort
        int[] selectArr = (int[])arr.Clone();
        SortingDemo.SelectionSort(selectArr);
        Console.WriteLine("Selection Sorted:" + string.Join(", ", selectArr));

        // Quick Sort
        int[] quickArr = (int[])arr.Clone();
        SortingDemo.QuickSort(quickArr, 0, quickArr.Length - 1);
        Console.WriteLine("Quick Sorted:    " + string.Join(", ", quickArr));

        // Merge Sort
        int[] mergeArr = (int[])arr.Clone();
        SortingDemo.MergeSort(mergeArr, 0, mergeArr.Length - 1);
        Console.WriteLine("Merge Sorted:    " + string.Join(", ", mergeArr));
    }
}