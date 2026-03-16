echo -n "Enter length of side 1: "
read side1
echo -n "Enter length of side 2: "
read side2
echo -n "Enter length of side 3: "
read side3
if [ $((side1 + side2)) -le $side3 ] || [ $((side2 + side3)) -le $side1 ] || [ $((side1 + side3)) -le $side2 ]
then
    echo "The lengths do not form a valid triangle."
else
    if [ $side1 -eq $side2 ] && [ $side2 -eq $side3 ]
    then
        echo "The triangle is Equilateral."
    elif [ $side1 -eq $side2 ] || [ $side2 -eq $side3 ] || [ $side1 -eq $side3 ]
    then
        echo "The triangle is Isosceles."
    else
        echo "The triangle is Scalene."
    fi
fi