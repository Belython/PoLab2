#!/bin/bash
function exite () {
if [ -n $1 ] && [ $1 -eq $1 ] 
then    if [ -z "$1" ]
	then  exit 0
	else  exit "$1"
	fi
else echo "write number, not chat"
fi
}
