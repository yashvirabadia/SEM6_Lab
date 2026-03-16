#!/bin/bash

total=$(cut -d: -f1 /etc/passwd | wc -l)
logged=$(who | wc -l)

echo "Total users: $total"
echo "Currently logged in: $logged"
