#!/bin/bash
grep "VmRSS" /proc/*/status | tr '/' ' ' | sort -n -k 4 | tail -1 | awk '{print $2 " " $4}'
top -b -n 1 | awk '{print $1 ", " $6}' | sort -n -r -k 2 | head -1
