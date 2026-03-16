#!/bin/bash

echo "Enter username:"
read user

if id "$user" >/dev/null 2>&1
then
    echo "User exists"
else
    echo "User does not exist"
fi
