

uniform sampler2D optTex;
uniform vec2 resolution;
uniform vec2 mouse;
uniform float lowFreq;
uniform float time;

void main() {
  vec2 pos = vec2(0.5, 0.5) - gl_FragCoord.xy / resolution.y;
  
  float d = length(pos);
  float a = atan(pos.y, pos.x);
  
//  vec2 tex = vec2(time + 2.0 / (6.0 * d + 3.0 * pos.x), 3.0 * a / 3.14);
  vec2 tex = vec2(time + 2.0 / (6.0 * d + 3.0 * pos.x), 4.0 * d / 3.14 + 3.0 * a / 3.14);
  
  float f = min(1.0, d/0.3);
  
  gl_FragColor = texture2D(optTex, tex) * f;
}
