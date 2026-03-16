#!/bin/bash
echo "Enter marks of 5 subjects: "
read m1 m2 m3 m4 m5

total=$((m1 + m2 + m3 + m4 + m5))
percent=$((total / 5))

echo "Percentage: $percent"

if [ $percent -gt 90 ]; then
    echo "Grade A"
elif [ $percent -ge 80 ]; then
    echo "Grade B"
elif [ $percent -ge 70 ]; then
    echo "Grade C"
elif [ $percent -ge 60 ]; then
    echo "Grade D"
elif [ $percent -ge 50 ]; then
    echo "Grade E"
else
    echo "Grade F"
fi
