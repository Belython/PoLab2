#!/bin/bash
function calc () {
case "$1" in
sum )
if [ -n $2 ] && [ $2 -eq $2 ] 2>/dev/null
then if [ -n $3 ] && [ $3 -eq $3 ] 2>/dev/null 
	then let res=$2+$3
	echo "sum = $res"
	else echo "write number2, not cahr"
	fi
else echo "write number1, not char"
fi
;;
sub )
if [ -n $2 ] && [ $2 -eq $2 ] 2>/dev/null
then if [ -n $3 ] && [ $3 -eq  $3 ] 2>/dev/null
	then let res=$2-$3
	echo "sub = $res"
	else echo "write number2, not char"
	fi
else echo "write number1, not char"
fi
;;
mul )
if [ -n $2 ] && [ $2 -eq $2 ] 2>/dev/null
then if [ -n $3 ] && [ $3 -eq $3 ] 2>/dev/null
	then let res=$2*$3
	     echo "mul = $res"
	else echo "write number2, not char"
	fi
else echo "write number1, not char"
fi
;;
div )
if [ -n $2 ] && [ $2 -eq $2 ] 2>/dev/null
then if [ -n $3 ] && [ $3 -eq $3 ] 2>/dev/null
	then if [[ "$3" -eq 0 ]]
	    then echo "not div 0"
	    else let res=$2/$3
		 echo "div = $res"
	    fi
	else echo "write number2, not char"
	fi
else echo "write number1, not char"
fi
;;
* )
echo "write sum/sub/mul/div"
;;
esac
}
