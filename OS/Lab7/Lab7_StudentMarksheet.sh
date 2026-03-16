echo -n "Enter marks for Subject 1: "
read sub1
echo -n "Enter marks for Subject 2: "
read sub2
echo -n "Enter marks for Subject 3: "
read sub3   
total=$((sub1 + sub2 + sub3))
percentage=$((total / 3))
echo "Total Marks: $total"
echo "Percentage: $percentage%"
if [ $percentage -ge 60 ]
then
    echo "Class Obtained: First Class"
elif [ $percentage -ge 50 ]
then
    echo "Class Obtained: Second Class"
elif [ $percentage -ge 40 ]
then
    echo "Class Obtained: Pass Class"
else
    echo "Class Obtained: Fail"
fi