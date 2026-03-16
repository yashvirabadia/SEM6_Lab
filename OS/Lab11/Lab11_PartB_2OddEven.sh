#!/bin/bash

echo "Enter a number:"
read num

rem=$((num % 2))

case $rem in
    0)
        echo "Number is EVEN"
        ;;
    1)
        echo "Number is ODD"
        ;;
esac
