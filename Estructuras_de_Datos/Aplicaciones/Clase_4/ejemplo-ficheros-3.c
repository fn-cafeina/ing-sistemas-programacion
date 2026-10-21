#include <stdio.h>
#include <string.h>
int main()
{
        FILE *p;
        char st[80];
        char file[80];
        printf("Archivo a leer: ");
        gets(file);
        p = fopen(file, "r");
        if (p)
        {
                fgets(st, 60, p);
                st[strlen(st)] = 0;
                printf("Contenido del archivo: %s\n", st);
                fclose(p);
        }
        else
        {
                printf("Archivo no existe.\n");
        }
}