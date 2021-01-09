/*
COIS 3420 - Web Application Development

Assignment 3 - Question 2
Prepared by Alisher Turubayev, 0630908
*/
window.addEventListener('DOMContentLoaded', () => {
    // Read this article by MDN, didn't understand anything, but it said better
    //     to use strict on function-to-function basis, instead of applying it 
    //     to the whole document.
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Strict_mode
    'use strict';

    // Highlight all initially needed code
    var install_code = document.querySelectorAll('pre.initial code');
    install_code.forEach((block) => {
        hljs.highlightBlock(block);
    });
    
    // Change a highlighting theme when the button is clicked
    var btn_change_theme = document.getElementById('change-theme');
    btn_change_theme.addEventListener('click', () => {
        // The solution was found on StackOverFlow:
        // https://stackoverflow.com/questions/19844545/replacing-css-file-on-the-fly-and-apply-the-new-style-to-the-page
        var old_link = document.querySelector('head > link[href*="atom"]');
        var new_link = document.createElement('LINK');
        new_link.setAttribute('rel', 'stylesheet');
        new_link.setAttribute('href', '//cdnjs.cloudflare.com/ajax/libs/highlight.js/9.18.1/styles/github.min.css');
        
        let head_tag = document.getElementsByTagName('head')[0];
        head_tag.replaceChild(new_link, old_link);
    }, { once: true });
    
    // Turn highlighting on a particular block after a button is clicked
    var code_snippet = document.querySelector(".hglt-after-press code");
    var btn = document.querySelector("#hglt-on-press");
    btn.addEventListener('click', () => {
        hljs.highlightBlock(code_snippet);
    });
    
    // Turn on/off highlighting on a particular block after a button is clicked
    var highlighted_code = document.querySelector(".rmv-hglt code");
    var btn = document.querySelector("#nohglt-on-press");
    btn.addEventListener('click', () => {
        highlighted_code.classList.toggle("hljs");
    });
});