#!/bin/bash

echo "Enter a number:"
read num

if [ "$num" -le 1 ]; then
    echo "Not a prime number"
    exit
fi

flag=1
for ((i=2; i<=num/2; i++))
do
    if [ $((num % i)) -eq 0 ]; then
        flag=0
        break
    fi
done

if [ "$flag" -eq 1 ]; then
    echo "Prime number"
else
    echo "Not a prime number"
fi
