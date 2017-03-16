import pygame
from pygame.locals import *

w_size = 600
h_size = 600
screen = pygame.display.set_mode((w_size, h_size), DOUBLEBUF)

bg_color = (0, 255, 127)
p_x = 0
p_y = 0
radius = 10

running = True
increment = False

up = False
down = False
left = False
right = False

speed = radius

while running:
	for event in pygame.event.get():
		if event.type == pygame.QUIT:
			running = False
		if event.type == KEYDOWN:
			if event.key == K_RIGHT:
				increment = True
				up = False
				down = False
				left = False
				right = True
			elif event.key == K_LEFT:
				increment = True
				up = False
				down = False
				left = True
				right = False
			elif event.key == K_UP:
				increment = True
				up = True
				down = False
				left = False
				right = False
			elif event.key == K_DOWN:
				increment = True
				up = False
				down = True
				left = False
				right = False

		if increment and left:
			if p_x - speed >= 0:
				p_x = p_x -  speed
		elif increment and right:
			if p_x + speed + 100 <= w_size:
				p_x = p_x + speed
		elif increment and up:
			if p_y - speed >= 0:
				p_y = p_y - speed
		elif increment and down:
			if p_y + speed + 100 <= h_size:
				p_y = p_y + speed

	position = [p_x, p_y]

	screen.fill(bg_color)

	surface = pygame.Surface((100, 100), pygame.SRCALPHA)
	image = pygame.image.load('ball.png')
	screen.blit(image, (p_x,p_y))

	pygame.display.flip()

pygame.quit()
