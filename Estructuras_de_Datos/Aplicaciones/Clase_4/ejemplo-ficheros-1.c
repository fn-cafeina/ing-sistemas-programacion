#include <stdio.h>
#include <stdlib.h>

int main()
{
        FILE *fd;
        char buffer[32];

        /* abrimos un fichero de texto para escritura, como no existe, se crea*/
        fd = fopen("fichero.txt", "wt");

        /* si hay un error, fd==NULL, osea fd=(void *)0, que es lo mismo que */
        /* decir que fd es falso */
        if (!fd)
        {
                printf("Error abriendo el fichero\n");
                exit(-1);
        }

        /* escribimos una frase en el fichero */
        fprintf(fd, "Escribiendo dentro del fichero.\n");

        /* lo cerramos */
        fclose(fd);

        /* lo abrimos otra vez, pero para lectura */
        fd = fopen("fichero.txt", "rt");

        if (!fd)
        {
                printf("Error abriendo el fichero (2)\n");
                exit(-1);
        }

        /* nos posicionamos 12 bytes desde el pricipio del fichero */
        /* eso nos situda delante de la palabra ’dentro’ */
        fseek(fd, 12, SEEK_SET);

        /* leemos 6 objetos de tamaño 1, es decir 6 bytes. Como 1 */
        /* caracter es 1 byte, leemos la palabra ’dentro’ */
        fread(buffer, 1, 6, fd);

        fclose(fd);

        printf("leido: '%s'\n\n", buffer); /* salida −> leído: ’dentro’ */

        /* se acabó */
        return 1;
}