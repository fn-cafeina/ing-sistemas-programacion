#include <stdio.h>

int main()
{
        int i = 1, j, res = 0;

        while (i <= 7)
        {
                j = 1;

                while (j <= i - res)
                {
                        if (i > 4)
                                res++;
                        printf(" %d ", j);
                        j++;
                }

                printf("\n");
                i++;
        }

        return 0;
}