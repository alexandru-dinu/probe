% plots several functions in the same graphic area, 
% on the interval [0,4*pi], with a smoothness of e4

% interval
I = linspace(0, 4*pi, 10000);

% functions
y = sin(I);
z = cos(I);

plot(I,y,'.','linewidth',2, I,z,'-','linewidth',3);

% options
axis([0, 4*pi, -1, 1]);
grid on
title('Graph y, z');
xlabel('x');
ylabel('y = sin(x)\nz = cos(x)');
legend('y', 'z');
