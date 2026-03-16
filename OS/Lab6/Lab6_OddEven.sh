#!/bin/bash

#3. To check whether given no is ODD or EVEN.

echo "Enter a number:"
read num

if [ $((num % 2)) -eq 0 ]
then
    echo "Number is even"
else
    echo "Number is odd"
fi
