#include <stdio.h>

int main()
{
        int i = 1, j, res = 0;

        do
        {
                j = 1;

                do
                {
                        if (i > 4)
                                res++;

                        printf(" %d ", j);

                        j++;
                } while (j <= i - res);

                printf("\n");

                i++;
        } while (i <= 7);

        return 0;
}