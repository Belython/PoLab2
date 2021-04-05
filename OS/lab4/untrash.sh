#!/bin/bash
if [ $# != 1 ]
then
	echo "Error: wrong count paramet"
	exit 1
fi
if  ! [ -d "/home/user/.trash" ] 
then
	echo "Erro: not found .trash"
fi
if ! [ -f "/home/user/.trash.log" ]
then
	echo "Error: not found .trash.log"
	exit 1
fi
for i in $(grep -h $1 $HOME/.trash.log)
do
	path=$(echo $i | awk -F "_" '{print $1}')
	ref=$(echo $i | awk -F "_" '{print $2}')
	echo $path
	echo $ref
	if [ $PWD/$1 == $path ];
	then
		rmfile=/home/user/.trash/$ref
		echo "write create file Y or N"
		read ans
		if [ "$ans" == "Y" ]
		then
			if [ -d $(dirname $path) ] 
			then
				if [ -e $path ] 
				then
					echo "Write new name file"
					read newname
					ln "$rmfile" "$(dirname $path)/$newname"
				else
					ln $rmfile $path
				fi
			else
				echo "Directory not found"
				ln $rmfile $HOME/$1
			fi
			rm $rmfile
		fi
	fi
done
