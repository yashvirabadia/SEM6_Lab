#!/bin/bash

#To check whether person is eligible to vote. (age>18).

echo "Enter your age:"
read age

if [ "$age" -ge 18 ]
then
    echo "You are eligible to vote."
else
    echo "You are not eligible to vote."
fi