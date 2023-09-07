
let randomNumber = Math.floor(Math.random() * 20) + 1;
let score = 20;
let highscore = 0;

function checkGuess() {
    const guess = parseInt(document.getElementById("guess").value);

    if (isNaN(guess) || guess < 1 || guess > 20) {
        document.getElementById("message").textContent = "Ingresa un número válido entre 1 y 20.";
    } else if (guess === randomNumber) {
        document.getElementById("message").textContent = "¡Felicidades! Has adivinado el número.";
        if (score > highscore) {
            highscore = score;
            document.getElementById("highscore").textContent = highscore;
        }
        score = 20;
        document.getElementById("score").textContent = "Puntaje: " + score;
        randomNumber = Math.floor(Math.random() * 20) + 1;
    } else {
        score -= 1;
        document.getElementById("score").textContent = "Puntaje: " + score;
        if (guess < randomNumber) {
            document.getElementById("message").textContent = "Intenta con un número más alto.";
        } else {
            document.getElementById("message").textContent = "Intenta con un número más bajo.";
        }
        if (score <= 0) {
            document.getElementById("message").textContent = "¡Perdiste! El número era " + randomNumber + ". Inténtalo de nuevo.";
            score = 20;
            document.getElementById("score").textContent = "Puntaje: " + score;
            randomNumber = Math.floor(Math.random() * 20) + 1;
        }
    }
    document.getElementById("guess").value = "";
}