
let valid = false;
window.addEventListener('DOMContentLoaded', () => {

  // Add your event listener here:

  document.querySelector('#main-form').addEventListener('submit', event => {
    if (!valid) event.preventDefault();
  });
});