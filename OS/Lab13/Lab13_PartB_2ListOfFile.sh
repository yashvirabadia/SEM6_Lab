#!/bin/bash

echo "Enter directory name:"
read dirname

if [ -d "$dirname" ]
then
    ls "$dirname"
else
    echo "Directory does not exist."
fi
