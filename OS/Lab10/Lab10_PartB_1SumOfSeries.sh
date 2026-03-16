#!/bin/bash

echo "Enter the value of n:"
read n

sum=0
for ((i=1; i*i<=n; i++))
do
    sum=$((sum + i*i))
done

echo "Sum of series is: $sum"
