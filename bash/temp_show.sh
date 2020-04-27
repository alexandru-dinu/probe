#!/bin/bash

(which tlp &> /dev/null) || {
	echo 'tlp not found.'
	exit 1
}

refreshes=$1
delta=$2

SUM=0 # used for avg. temp.

rm -f out

for i in `seq 0 $refreshes`; do
	DT=
	TP=$(sudo tlp stat | grep 'CPU temp' | awk '{print $4}')
	SUM=$(($SUM+$TP))
	echo -e "$(date +%M)\n$TP" >> out
	sleep "$delta"
done

AVG=$(echo "scale=2; $SUM/$refreshes" | bc)
echo "Avg. temp.: $AVG" >> out

paste - - < out | nl | head -n +"$((2*$refreshes))" | gnuplot -p -e 'plot "-" using 1:3:xtic(2) with lines title "temp"'

rm -f out