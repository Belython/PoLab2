#!/bin/bash
LastBackupDate=$(ls /home/user | grep -E "^Backup-" | sort -n | tail -1 | sed "s/Backup-//")
LastBackup="/home/user/Backup-${LastBackupDate}"
NowDate=$(date + "%Y-%m-%d")
NowTime=$(date -d "$NowDate" + "%s")
LastBackupTime=$(date -d "$LastBackupBate" + "%s")
ResTime=$(echo "(${NowTime} - ${lastBackupTime}) / 60 / 60 / 24" | bc)
rep=/home/user/.backup-report
if [ $ResTime > 7 ] || [ -z "$LastBackupDate" ]
then
	mkdir "/home/user/Backup-${NowDate}"
	for i in $(ls /home/user/sourse)
	do
		cp "/home/user/sourse/$i" "/home/user/Backup-$NowDate"
	done
	flist=$(ls /home/user/sourse | sed "s/^/\t/")
	echo -e "${NowDate} ${flist}" >> $rep
else
	change=""
	for i in $(ls /home/user/sourse)
	do
		if [ -f "$lastBackup/$i" ]]
		then
			soursesize=$(wc -c "home/user/sourse/${i}" | awk '{print $1}')
			backupsize=$(wc -c "${LastBackup}/{i}" | awk '{print $1}')
			ressize=$(echo "${soursesize} - {backupsize}" | bc)
			if [ $ressize != 0 ]
			then
				mv "$LastBackup/$i" $LastBackup
				cp "/home/user/sourse/$i" $LastBackup
				change="${change} $i"
			fi
		else
			cp "/home/user/sourse/$i" $LastBackup
			change="${change} $i"
		fi
	done
	change=$(echo $change | sed 's/^\\n//')
	if ! [ -z "$change" ]
	then
		echo -e "${LastBackupDate} ${change}" >> $rep
	fi
fi
