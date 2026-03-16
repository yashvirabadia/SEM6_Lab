echo -n "Enter first number: "
read num1
echo -n "Enter second number: "
read num2
echo -n "Enter third number: "
read num3
if [ $num1 -gt $num2 ] && [ $num1 -gt $num3 ]
then
    echo "Largest number is: $num1"
elif [ $num2 -gt $num1 ] && [ $num2 -gt $num3 ]
then
    echo "Largest number is: $num2"
else
    echo "Largest number is: $num3"
fi  