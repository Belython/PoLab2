#!/bin/bash
ps -fu user | tail -n +2 | awk '{print $2 ":" $8}' > temp
cat temp | wc -l > res1
cat temp >> res1
rm temp
