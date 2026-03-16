// #include <stdio.h>

// int main() {
//     int i, j, n = 6;

//     for (i = 1; i <= n; i++) {
//         for ( j = 1; j <= 2*i-1; j++)
//         {
//             if (j == 1 || j == 2*i-1)
//                 printf("1");
//             else if (j < i)
//                 printf("*");
//             else if(j > i)
//                 printf("*");
//             else
//                 printf("%d", i );
//         }
        
//         printf("\n");
//     }
//     return 0;
// }

// #include <stdio.h>

// int main() {
//     int i, j, n = 5;
//     int val;

//     for (i = 0; i < n; i++) {
//         val = 1;
//         for (j = 0; j <= i; j++) {
//             printf("%d ", val);
//             val = val * (i - j) / (j + 1);
//         }
//         printf("\n");
//     }
//     return 0;
// }

#include <stdio.h>

int main() {
    int n;
    scanf("%d", &n);
    
    long long actual_sum = 0;
    for(int i = 1; i < n; i++) {
        int x;
        scanf("%d", &x);
        actual_sum += x;
    }
    
    // Expected sum of numbers from 1 to n is n*(n+1)/2
    long long expected_sum = (long long)n * (n + 1) / 2;
    
    // The difference is exactly the repeated number
    printf("%d\n", (int)(actual_sum - expected_sum));
    
    return 0;
}