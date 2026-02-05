#include <stdio.h>

int main()
{
        int i, j, res = 0;

        for (i = 1; i <= 7; i++)
        {
                for (j = 1; j <= i - res; j++)
                {
                        if (i > 4)
                                res++;
                        printf(" %d ", j);
                }

                printf("\n");
        }

        return 0;
}