#!/bin/bash

echo "Enter first number:"
read num1

echo "Enter second number:"
read num2

echo "Choose operation (+, -, *, /):"
read op

case $op in
    +)
        echo "Result = $(($num1 + $num2))"
        ;;
    -)
        echo "Result = $(($num1 - $num2))"
        ;;
    \*)
        echo "Result = $(($num1 * $num2))"
        ;;
    /)
        if [ $num2 -ne 0 ]
        then
            echo "Result = $(($num1 / $num2))"
        else
            echo "Division by zero not allowed"
        fi
        ;;
    *)
        echo "Invalid operator"
        ;;
esac
