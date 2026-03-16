#!/bin/bash

echo "Enter Gender (M/F):"
read gender

case $gender in
    M|m)
        echo "Gender: Male"
        ;;
    F|f)
        echo "Gender: Female"
        ;;
    *)
        echo "Invalid Input"
        ;;
esac
