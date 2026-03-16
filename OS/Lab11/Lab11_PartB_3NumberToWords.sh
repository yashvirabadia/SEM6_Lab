#!/bin/bash

echo "Enter a number (1-5):"
read num

case $num in
    1) echo "One" ;;
    2) echo "Two" ;;
    3) echo "Three" ;;
    4) echo "Four" ;;
    5) echo "Five" ;;
    *) echo "Number out of range" ;;
esac
