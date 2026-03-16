echo -n "Enter a number: "
read num
if [ $num -gt 0 ]
then
    echo "$num is Positive"
    if [ $((num % 2)) -eq 0 ]
    then
        echo "$num is Even"
    else
        echo "$num is Odd"
    fi
elif [ $num -lt 0 ]n
then
    echo "$num is Negative"
else
    echo "The number is Zero"
