#include <stdio.h>

int power(int, int);

void main(void)
{

        int r;

        r = power(4, 2);

        printf("r = %d\n", r);
}

int power(int x, int n)
{
        int p;

        for (p = 1; x > 0; x--)
                p *= n;

        return p;
}