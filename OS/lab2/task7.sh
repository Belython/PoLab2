#!/bin/bash
before=" "
after=" "
ps aux | awk '{if ($6 != 0) print $2 " " $6 " " $11}' | sort -nk1 | tail -n +2 | head -n -6 > "$before"
sleep 1m
ps aux | awk '{if ($6 != 0) print $2 " " $6 " " $11}' | sort -nk1 | tail -n +2 | head -n -6 > "$after"

cat "$before" |
while read line
do pid=$(awk '{print $1}' <<< $line)
   memory_before=$(awk '{print $2}' <<< $line)
   cmd=$(awk '{print $3}' <<< $line)
   memory_after=$(cat "$after" | awk -v id="$pid" '{if ($1 == id) print $2}')
   memory_difference=$(echo "$memory_after - $memory_before" | bc)
   echo $pid " : " $cmd " : " $memory_difference
done | sort -t ":" -nk3 | head -n 3 
