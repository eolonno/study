let img = document.querySelector("img");
	radius = 250,
    speed = 25;
	angle = 0;
	step = 2 * Math.PI / 180;

setInterval(circle, speed);

function circle() {
    angle += step;
    img.style.left = window.innerWidth / 2 + radius * Math.sin(angle) + 'px';
    img.style.top = window.innerHeight / 2 - img.height / 2 + radius * Math.cos(angle) + 'px';
}