#!/bin/bash
. ./calc.sh
. ./log.sh
. ./search.sh
. ./reverse.sh
. ./strlen.sh
. ./exite.sh
. ./help.sh
case "$1" in
calc )
calc "$2" "$3" "$4"
;;
search )
search "$2" "$3"
;;
reverse )
revers "$2" "$3"
;;
strlen )
strlen "$2"
;;
log )
log
;;
exit )
exite "$2"
;;
help )
help
;;
interactive )
./interactive.sh
;;
* )
echo "command not found"
help
esac
