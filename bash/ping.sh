mkfifo pipe
while true 
do
	echo "Ping" > pipe
	sleep 1s
	more < pipe
done