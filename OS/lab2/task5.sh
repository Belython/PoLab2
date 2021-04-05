#!/bin/bash
ppid_0=0
artsum=0
count=0
avg=0
echo -e "$(<res4)\n" | sed "s/[^0-9.]\+/ /g" | sed "s/^ //g" |
while read line
 	   do pid=$(awk '{print $1}' <<< $line)
	      ppid=$(awk '{print $2}' <<< $line)
	      art=$(awk '{print $3}' <<< $line)
	   if [[ $ppid = $ppid_0 ]]
	   then artsum=$(echo "$artsum+$art" | bc | awk '{printf "%f", $0}')
	        count=$(($count+1))
	   else avg=$(echo "scale=4; $artsum/$count" | bc | awk '{printf "%f", $0}')
	        echo "Averange_Children_Running_Time_of_ParentID="$ppid_0" is " $avg
	        artsum=$art
                count=1
                ppid_0=$ppid
	   fi
	   if [[ ! -z $pid ]]
	   then echo "ProcessID="$pid" : Parent_ProcessID="$ppid" : Average_Running_Time="$art
	   fi
done > res5



