#!/bin/bash
function search () {
if [ -z "$1" ] 
then echo "write directory"
else if [ -z "$2" ]
     then echo "string"	
     else
	if  [[ -r "$1" && -w "$1" ]]
	then grep -rn "$2" $1
	else echo "error"
	fi
     fi
fi
}
