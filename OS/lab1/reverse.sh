#!/bin/bash
function revers() {
if [[ -z "$1" ]]
then echo "write read file"
else if [[ -z "$2" ]]
     then echo "write write file"
     else tac $1 > temp
	  rev temp > $2
     fi
fi
}
