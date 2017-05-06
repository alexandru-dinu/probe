#!/bin/bash

RF=$1 #nr of refreshes 
SLP=$2 #sleep
PLOT=$3
SUM=0 #used for avg. temp.

rm out &> /dev/null

for (( i = 0; i < $RF; i++ )); do
	DT=$(date +%M)
	TP=$(sudo tlp stat | grep 'CPU temp' | awk '{print $4}')
	SUM=$(($SUM+$TP))
	echo -e "$DT\n$TP" >> out
	sleep "$SLP"
done

AVG=$(echo "scale=2; $SUM/$RF" | bc)
echo "Avg. temp.: $AVG" >> out

if [[ $PLOT -eq "1" ]]; then
	paste - - < out | nl | head -n +"$((2*$RF))" | gnuplot -p -e 'plot "-" using 1:3:xtic(2) with lines title "temp"'
fi