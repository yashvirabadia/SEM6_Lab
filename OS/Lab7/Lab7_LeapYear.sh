
echo -n "Enter Year: "
read y

if [ $((y % 4)) -eq 0 ]
then
    if [ $((y % 100)) -eq 0 ]
    then
        if [ $((y % 400)) -eq 0 ]
        then
            echo "$y is a Leap Year"
        else
            echo "$y is NOT a Leap Year"
        fi
    else
        echo "$y is a Leap Year"
    fi
else
    echo "$y is NOT a Leap Year"
fi