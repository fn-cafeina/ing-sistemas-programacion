#!/usr/bin/env sh

clear

gcc -c cafeina.c -o cafeina.o
ar rcs libcafeina.a cafeina.o
gcc main.c -o main -L. -lcafeina

./main

rm main