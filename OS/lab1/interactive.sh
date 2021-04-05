#!/bin/bash
. ./calc.sh
. ./exite.sh
. ./help.sh
. ./strlen.sh
. ./log.sh
. ./search.sh
. ./reverse.sh
echo "a-calc"
echo "b-search"
echo "c-reverse"
echo "d-strlen"
echo "e-log"
echo "f-exit"
echo "g-help"
echo "write a-g"
read a
case "$a" in
a )
echo "write sum/sub/mul/div"
read n
echo "write num1"
echo "write num 2"
read a
read b
calc "$n" "$a" "$b"
./interactive.sh
;;
b ) 
echo "write directory and reg value"
read b
read c 
search $b $c
./interactive.sh
;; 
c )
echo "file read and file write"
read b
read c
revers "$b" "$c"
./interactive.sh
;;
d )
echo "write string"
read q
strlen "$q"
./interactive.sh
;;
e )
echo "log"
log
./interactive.sh
;;
f )
echo "write value or pass"
read a
exite "$a"
;;
g )
echo "help"
help
./interactive.sh
;;
*)
echo "commandas not found"
;;
esac
