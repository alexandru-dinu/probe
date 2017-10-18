while true 
do
	more < pipe
	echo "Pong" > pipe
	sleep 2s
done