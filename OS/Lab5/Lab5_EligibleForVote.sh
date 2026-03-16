#To check whether person is eligible to vote. (age>18) use only if statement.
echo "Enter your age:"
read age

if [ "$age" -ge 18 ]
then
    echo "You are eligible to vote."
fi
if [ "$age" -lt 18 ]
then
    echo "You are not eligible to vote."
fi