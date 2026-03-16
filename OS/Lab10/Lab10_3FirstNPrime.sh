#!/bin/bash

echo "Enter n:"
read n

count=0
num=2

while [ "$count" -lt "$n" ]
do
    isPrime=1
    for ((i=2; i<=num/2; i++))
    do
        if [ $((num % i)) -eq 0 ]; then
            isPrime=0
            break
        fi
    done

    if [ "$isPrime" -eq 1 ]; then
        echo -n "$num "
        count=$((count + 1))
    fi

    num=$((num + 1))
done

echo
