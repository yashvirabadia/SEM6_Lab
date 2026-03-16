#!/bin/bash

#2. To find a largest number from 2 numbers. using only if statement

echo "Enter first number:"
read a

echo "Enter second number:"
read b

if [ "$a" -gt "$b" ]
then
    echo "Largest number is: $a"
fi

if [ "$b" -gt "$a" ]
then
    echo "Largest number is: $b"
fi

if [ "$a" -eq "$b" ]
then
    echo "Both numbers are equal"
fi