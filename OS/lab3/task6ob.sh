#!/bin/bash
echo $$ > .pid
res=1
MODE=""
usr1()
{
	MODE="+"
}
usr2()
{
	MODE="*"
}
sigterm()
{
	MODE="SIGTERM"
}
trap 'usr1' USR1
trap 'usr2' USR2
trap 'sigterm' SIGTERM

while true; do
	case $MODE in
		"+")
			let res=$res+2
			echo "res == $res"
			;;
		"*")
			let res=$res*2
			echo "res == $res"
			;;
		"TERM")
			echo "FINISH"
			exit
			;;
	esac
	sleep 1
done
