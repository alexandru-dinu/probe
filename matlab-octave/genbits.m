%GENBITS (s)	Generates a square sxs matrix filled with random bits
function [ B ] = genbits(s)
	B = rand(s);
	B = B .* 1e4;
	B = round(B);
	B = mod(B, 2);
end
