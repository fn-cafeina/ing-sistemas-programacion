#include <stdio.h>

int main()
{
        int i = 1, j;

        while (i <= 6)
        {
                j = 1;

                if (i % 2 == 0)
                        printf("   ");

                while (j <= 9)
                {
                        printf(" * ");
                        j++;
                }

                printf("\n");
                i++;
        }

        return 0;
}