#!/bin/bash


#1. To check whether a number is greater than 10 or not.

echo "Enter a number:"
read num

if [ "$num" -gt 10 ]
then
    echo "The number is greater than 10"
else
    echo "The number is not greater than 10"
fi
