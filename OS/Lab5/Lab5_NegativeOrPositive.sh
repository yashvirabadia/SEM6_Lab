#1. To check whether given no is NEGATIVE or POSITIVE. use only if statement.

echo "Enter a number:"
read num

if [ "$num" -lt 0 ]
then
    echo "Number is negative"
fi
if [ "$num" -gt 0 ]
then
    echo "Number is positive"
fi
if [ "$num" -eq 0 ]
then
    echo "Number is zero"
fi