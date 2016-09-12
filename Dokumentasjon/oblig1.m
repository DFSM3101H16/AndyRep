%Finner Vy utifra V og sin theta.
%Antar at V er 50.
%Antar at Theta er 40.
vy =sind (40) * 50;
vx =cosd (40) * 50;
%Displacement i X rettning er -100m.
%Tyngeaksjelerasjonen er - 9.81 m/2^2
a = -9.81;
d = -100;
%Hva er Vf?
%Vf^2=Vi^2+2a*d.
Vft = (vy)^2 +2*(a)*(d);
Vfy = sqrt(Vft);
Vfy *= -1; 
%Finner tiden.
t = (Vfy - vy)/a;
%Bruker tiden for å finne X pos
Vfx = (vx)*(t);
%Plotter resulat

