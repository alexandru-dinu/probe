#!/bin/bash

RF=$1 #refreshes
SLP=$2 #sleep time
PLOT=$3

rm out &> /dev/null

for (( i = 0; i < $RF; i++ )); do
	DT=$(date +%M)
	MEM=$(free -m | head -2 | tail -1 | awk '{print $4}')
	echo -e "$DT\n$MEM" >> out
	sleep "$SLP"
done

if [[ $PLOT -eq "1" ]]; then
	paste - - < out | nl | gnuplot -p -e 'plot "-" using 1:3:xtic(2) with lines title "mem"'
fi
