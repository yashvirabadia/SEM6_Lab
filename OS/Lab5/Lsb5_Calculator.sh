#!/bin/bash

:'1. Which works like a calculator and performs below operations Addition, Subtract, Division and
Multiplication. use only if statement to select the operation to be performed. '

echo "Select operation to perform:"
echo "1. Addition"
echo "2. Subtraction"
echo "3. Multiplication"
echo "4. Division"
read op

echo "Enter first number:"
read a

echo "Enter second number:"
read b

if [ "$op" -eq 1 ]
then
    result=$((a + b))
    echo "Addition: $result"
fi
if [ "$op" -eq 2 ]
then
    result=$((a - b))
    echo "Subtraction: $result"
fi
if [ "$op" -eq 3 ]
then
    result=$((a * b))
    echo "Multiplication: $result"
fi
if [ "$op" -eq 4 ]
then
    if [ "$b" -ne 0 ]
    then
        result=$((a / b))
        echo "Division: $result"
    else
        echo "Error: Division by zero"
    fi
fi