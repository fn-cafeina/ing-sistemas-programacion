#!/usr/bin/env sh

gcc -c cafeina.c -o cafeina.o
ar rcs libcafeina.a cafeina.o