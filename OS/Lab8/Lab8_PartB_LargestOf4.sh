#!/bin/bash
echo "Enter four numbers: "
read a b c d

if [ $a -gt $b ] && [ $a -gt $c ] && [ $a -gt $d ]; then
    echo "Largest is: $a"
elif [ $b -gt $c ] && [ $b -gt $d ]; then
    echo "Largest is: $b"
elif [ $c -gt $d ]; then
    echo "Largest is: $c"
else
    echo "Largest is: $d"
fi
