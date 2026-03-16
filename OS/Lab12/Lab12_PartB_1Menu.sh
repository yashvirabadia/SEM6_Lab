#!/bin/bash

echo "1. Display calendar"
echo "2. Display date and time"
echo "3. Logged in users"
echo "4. Display name at given position"
echo "5. Display terminal number"
echo "6. Exit"

echo "Enter choice:"
read ch

case $ch in
1) cal ;;
2) date ;;
3) who ;;
4)
    echo "Enter X position:"
    read x
    echo "Enter Y position:"
    read y
    echo "Enter your name:"
    read name
    tput cup $x $y
    echo "$name"
    ;;
5) tty ;;
6) exit ;;
*) echo "Invalid choice" ;;
esac
