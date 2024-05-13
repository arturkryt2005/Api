let canvas = document.getElementsByClassName('snow')[0];
canvas.width = window.innerWidth;
canvas.height = window.innerHeight;

window.addEventListener('resize', function () {
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;
});


let c = canvas.getContext('2d');

function randomNum(max, min) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function Snowflakes(x, y, radius, velocityY, opacity) {
    this.x = x;
    this.y = y;
    this.radius = radius;
    this.velocityY = velocityY;
    this.opacity = opacity;

    this.draw = function () {
        c.beginPath();
        c.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false);
        c.fillStyle = "rgba(255, 255, 255, " + this.opacity + ")";
        c.fill();
    }

    this.update = function () {
        if (this.y + this.radius > canvas.height) {
            this.y = randomNum(-50, -10);
            this.x = randomNum(0, canvas.width);
        }
        this.y += this.velocityY;
        this.draw();
    }
}

let snowArray = [];

for (let i = 0; i < 140; i++) {
    let snowXLocation = randomNum(0, canvas.width);
    let snowYLocation = randomNum(0, canvas.height);
    let randomRadius = randomNum(3, 1);
    let randomSpeed = randomNum(2, 0.5);
    let randomOpacity = Math.random();
    snowArray.push(new Snowflakes(snowXLocation, snowYLocation, randomRadius, randomSpeed, randomOpacity));
}

function animateSnow() {
    requestAnimationFrame(animateSnow);
    c.clearRect(0, 0, canvas.width, canvas.height);

    for (let i = 0; i < snowArray.length; i++) {
        snowArray[i].update();
    }
}

animateSnow();