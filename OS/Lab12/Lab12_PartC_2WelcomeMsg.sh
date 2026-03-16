#!/bin/bash

hour=$(date +%I)
minute=$(date +%M)
ampm=$(date +%p)

echo "Current time: $hour:$minute $ampm"

h=$(date +%H)

if [ $h -lt 12 ]
then
    echo "Good Morning"
elif [ $h -lt 17 ]
then
    echo "Good Afternoon"
elif [ $h -lt 20 ]
then
    echo "Good Evening"
else
    echo "Good Night"
fi
