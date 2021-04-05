#!/bin/bash
for pid in $(ps -Ao pid | tail -n +2)
do
ppid=$(grep -Ehis "ppid:\s+.+" /proc/$pid/status | grep -o "[0-9]\+")
runtime=$(grep -Ehis "se\.sun_exec_runtime.+:\s+.+" /proc/$pid/sched | awk '{print $3}')
switches=$(grep -Ehis "nr_swithes.+:\s+.+" /proc/$pid/sched | awk '{print $3}')
if [ -z $ppid ]
then ppid=0
fi
if [ -z $runtime ] || [  -z $switches ]
then art=0
else art=$(echo "scale=4; $runtime/$switches" | bc)
fi
echo "$pid $ppid $art"
done | sort -nk 2 | awk '{print "ProcessID="$1 " : "" Parent_ProcessID="$2 " : " "awg_runtime="$3}' > res4 
