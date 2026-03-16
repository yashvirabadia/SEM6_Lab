#!/bin/bash

echo "Enter a character:"
read ch

case $ch in
    a|e|i|o|u|A|E|I|O|U)
        echo "It is a Vowel"
        ;;
    [a-zA-Z])
        echo "It is a Consonant"
        ;;
    *)
        echo "Invalid character"
        ;;
esac
