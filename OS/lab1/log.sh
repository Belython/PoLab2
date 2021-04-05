#!/bin/bash
function log {
war="$(cat /var/log/anaconda/X.log | awk '{if(($3 == "(WW)"))print$0}')"
inf="$(cat /var/log/anaconda/X.log | awk '{if(($3 == "(II)"))print$0}')"
echo -e "${war//"(WW)"/"\e[1;33mWarning:\e[0m"}"
echo -e "${inf//"(II)"/"\e[1;34mInformation:\e[0m"}"
}
