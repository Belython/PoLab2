#!/bin/bash
arr=()
i=0
N=$1
while true;
do 
	if [[ ${#arr[@]} > N ]]
	then
		exit 0
	fi
	arr+=(1 2 3 4 5 6 7 8 9 10)
	let i=$((i+1))
done
