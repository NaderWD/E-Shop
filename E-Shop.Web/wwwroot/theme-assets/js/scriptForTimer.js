// Set timer duration in seconds
let duration = 120;

const timerElement = document.getElementById('timer');
const resendLink = document.getElementById('resendLink');

function updateTimer() {
    if (duration > 0) {
        timerElement.textContent = `مدت زمان اعتبار کد: ${duration--} ثانیه`;
        setTimeout(updateTimer, 1000);
    } else {
        timerElement.classList.add('hidden');
        resendLink.classList.remove('hidden');
    }
}

updateTimer();