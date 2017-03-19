function [ s ] = vavg(v)
	s = 0;
	for x = v
		s = s + x;
	end
	printf('v_avg = %f\n', s / length(v));
end
