#!/bin/bash

echo "Enter file name:"
read filename

if [ -f "$filename" ]
then
    wc -l "$filename"
else
    echo "File does not exist."
fi
