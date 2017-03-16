function [ F ] = frobenius( A )
%FROBENIUS(A) Computes the Frobenius norm for the matrix A
    sum = 0;
    [R, C] = size(A);
    for k = 1:R
        sum = sum + A(k, 1:C) * A(k, 1:C)';
    end
    F = sqrt(sum);
end

