echo -n "Enter first integer: "
read int1
echo -n "Enter second integer: "
read int2
if [ $int1 -eq $int2 ]
then
    echo "Both numbers are equal."
else
    if [ $int1 -gt $int2 ]
    then
        echo "The largest number is: $int1"
    else
        echo "The largest number is: $int2"
    fi
fi
