#!/bin/bash

echo "Enter command to execute:"
read cmd

$cmd


echo "Current Month Calendar:"
cal


echo "Enter date (dd-mm-yyyy):"
read date

if [[ $date =~ ^([0-9]{2})-([0-9]{2})-([0-9]{4})$ ]]
then
    echo "Valid Date Format"
else
    echo "Invalid Date Format"
fi
