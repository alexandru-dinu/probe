// Live Coder Readme
// by hole

This is a real time editor/viewer of GLSL!
And it can use sound from mic.

・option
-w <width> <height>: window
-f <width> <height>: full screen

・key binds
F1 - F10: Change an editing file
F11: Show/hide code
F12: Edit post fx file

Ctrl+S: Save
Ctrl+O: Load
Ctrl+Z: Undo
Ctrl+Y: Redo
Ctrl+C: Copy
Ctrl+V: Paste
Ctrl+X: Cut

・Variables
vec2 resolution (px)
float time (sec)
vec2 mouse
sampler2D optTex (for option.bmp)
sampler2D backbuffer (previous rendered frame)
sampler1D fft (from mic.)
float lowFreq (from mic.)
float midFreq (from mic.)
float highFreq (from mic.)
