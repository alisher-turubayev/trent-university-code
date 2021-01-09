"use strict";

// This block will run when the DOM is loaded (once elements exist)
window.addEventListener('DOMContentLoaded', () => {
  // This function is correct, don't mess with it
  const emailIsValid = string => /^[^\s@]+@[^\s@]+\.[^\s@]$/.test(string);

  
  
  //replace ??? with the selector to get the required element
  const submitButton = document.querySelector(' ??? ');

  const emailInput = document.querySelector(' ??? ');
  const emailError = document.querySelector(' ??? ');

  const candySelect = document.querySelector(' ??? ');
  const candyError = document.querySelector(' ??? ');


  //replace 'event name here' with the correct event
  submitButton.addEventListener(' event name here ', event => {
    //do form validation here
    
    
  });
});