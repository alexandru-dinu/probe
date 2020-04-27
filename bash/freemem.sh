#!/bin/bash

refreshes=$1
delta=$2

rm -f out

for i in `seq 0 $refreshes`; do
	mem=$(free -m | head -2 | tail -1 | awk '{print $4}')
	echo -e "$(date +%M)\n$mem" >> out
	sleep "$delta"
done

paste - - < out | nl | gnuplot -p -e 'plot "-" using 1:3:xtic(2) with lines title "mem"'

rm -f out
