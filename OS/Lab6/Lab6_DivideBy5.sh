#!/bin/bash
#To check whether given no is divisible by 5 or not.

echo "Enter a number:"
read num

if [ $((num % 5)) -eq 0 ]
then
    echo "Number is divisible by 5"
else
    echo "Number is not divisible by 5"
fi