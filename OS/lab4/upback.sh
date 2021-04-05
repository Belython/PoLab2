#!/bin/bash
LastBackupDate=$(ls /home/user | grep -E "^Backup-" | sort -n | tail -1 | sed 's/^Backup-//')
LastBackup="/home/user/Backup-${LastbackupDate}"
if [ -z "$LstBackupDate" ]
then
	exit 1
fi

if ! [ -d /home/user/restore ]
then
	mkdir /home/user/restore
else
	rm -r /home/user/restore
	mkdir /home/user/restore
fi

for i in $(ls $LastBackup | grep -Ev "\.[0-9]{4}-[0-9]{2}-[0-9]{2}$")
do
	cp "${LastBackup}/${i}" "/home/user/restore/${i}"
done
