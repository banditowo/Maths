# Maths
 
State and Context: there is a shader which reads the world position of the object and paints pixels according to their world x,y,z

Interpolation: there is a smoothing effect when enabling/disabling the object motion component.

Intersection: when the ghost sphere in the center of the scene and the moving sphere overlap, the movable sphere grows larger, indicating radius overlap.

Collision: same as intersection, there is a maximum radius which "clamps" the moving sphere, essentially functioning as a sphere collider.

Noise: Perlin noise is used to make the object motion.
