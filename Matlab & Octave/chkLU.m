function [ c ] = chkLU( A )
%CHKLU(A) Checks if A can be written as A = LU
    [R, C] = size(A);
    if R ~= C
        error('A is not a square matrix!');
    end
    
    c = 0;
    n = length(A);
    count = 0;
    for p = 1:n
        if det(A(1:p, 1:p)) ~= 0
            count = count + 1;
        end
    end
    
    if count == n
        c = 1;
    end
end

