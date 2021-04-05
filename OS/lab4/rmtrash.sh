#!/bin/bash
id=$(date +"%s")
if [ $# != 1 ]
then
	echo "Error: count parameter"
	exit 1
fi

if ! [ -f "$PWD/$1" ]
then
	echo "Error: file not found"
	exit 1
fi

if ! [ -d  $HOME/.trash ]
then
	mkdir "$HOME/.trash"
fi

ln $1 "$HOME/.trash/$id"

if ! [ -e $trashlog ] 
then
	touch $HOME/.trash.log
fi

echo "$PWD/$1_$id" >> $HOME/.trash.log

rm $1
