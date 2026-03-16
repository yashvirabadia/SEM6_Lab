#!/bin/bash
echo "Enter first number: "
read a
echo "Enter second number: "
read b

if [ $a -eq $b ]; then
    echo "Both numbers are equal"
else
    if [ $a -gt $b ]; then
        large=$a
    else
        large=$b
    fi

    echo "Largest number is: $large"

    if [ $((large % 5)) -eq 0 ] && [ $((large % 7)) -eq 0 ]; then
        echo "Divisible by both 5 and 7"
    elif [ $((large % 5)) -eq 0 ]; then
        echo "Divisible by 5"
    elif [ $((large % 7)) -eq 0 ]; then
        echo "Divisible by 7"
    else
        echo "Not divisible by 5 or 7"
    fi
fi
