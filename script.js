const worked = document.getElementById('worked');
const rate = document.getElementById('rate');
const amountDiv = document.getElementById('result');

// Function to update the result in real time
function updateResult() {
    // Get the values from the inputs
    const num1 = parseFloat(worked.value) || 0; // Default to 0 if the input is empty
    const num2 = parseFloat(rate.value) || 0;

    // Perform the calculation (e.g., addition)
    const result = num1 * num2;

    // Update the result on the webpage
    amountDiv.textContent = `Total Expected Pay: ${result}`;
}

// Add event listeners to update the result whenever the inputs change
worked.addEventListener('input', updateResult);
rate.addEventListener('input', updateResult);
