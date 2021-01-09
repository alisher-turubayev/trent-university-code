/*
COIS 3420 - Web Application Development

Assignment 3 - Question 1
Prepared by Alisher Turubayev, 0630908

Note: all assumptions for this part are in the submission document. 
    The implementation of some parts is justified by providing a link to a 
    source that mentiones the validity of such approach. I am not really sure
    whether those are best practices, so I totally understand if marks are 
    deducted anyways.
*/

// Added for IE9 support (at least that was what I understood)
window.addEventListener('DOMContentLoaded', () => {
    // Read this article by MDN, didn't understand anything, but it said better
    //     to use strict on function-to-function basis, instead of applying it 
    //     to the whole document.
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Strict_mode
    'use strict';

    // Part 1: make paragraph disappear after a click
    // Note: disappear is interpreted as making text disappear but 
    //     not the element itself
    var part1_p = document.querySelector(".part1 > p");
    part1_p.addEventListener('click', () => {
        part1_p.classList.add("invisible");
    });

    // Part 2: change the background to 'Russian Violet' when any of the list 
    //     items are clicked. Listener is hooked to the ul parent element.
    // Note: copied from slides :( 
    var part2_ul = document.querySelector(".part2 > ul");
    part2_ul.addEventListener('click', (ev) => {
        if (ev.target.nodeName == "LI") {
            part2_ul.classList.add("purple");
        }
    });
    
    // Part 3: change the text color on single click (to red) and 
    //     on double click (to pink)
    var part3_p = document.querySelector(".part3 > p");
    part3_p.addEventListener('click', () => {
       part3_p.classList.toggle("red"); 
    });
    part3_p.addEventListener('dblclick', () => {
       part3_p.classList.toggle("pink"); 
    });
    
    // Part 4: clone the text from input box to the paragraph
    var part4_input = document.querySelector(".part4 > input");
    var part4_p = document.querySelector(".part4 > p");
    
    part4_input.addEventListener('keyup', () => {
        // Note: getAttribute does not update after each keypress, so
        //     a direct access using .value is used.
        part4_p.innerHTML = part4_input.value;
    });
    
    // Part 5: change the size of the div element by given values
    var part5_button = document.querySelector(".part5 > button");
    var part5_div = document.querySelector(".part5 > div");
    // Get initial size of the elements 
    // Note: all calculations are done in em 
    var div_height = parseFloat(part5_div.style.height);
    var div_width = parseFloat(part5_div.style.width);
    
    part5_button.addEventListener('click', () => {
        // Fetch the value and parse them to float
        // Note: function Number is used to enforce a stricter parsing,
        //     so that NaN is returned if any invalid characters are given
        let add_height = Number(document.getElementById("height").value);
        let add_width = Number(document.getElementById("width").value);
        // Check if numbers by comparing to NaN (what parseFloat returns if not
        //     a number)
        if (isNaN(add_height)|| isNaN(add_width)) {
            window.alert("Inputs for height/width are not numberic values.");
            return;
        }
        // Check the boundaries (between -10 and 10)
        if (add_height > 10.0 || add_height < -10.0) {
            window.alert("Height is out of bounds.");
            return;
        }
        if (add_width > 10.0 || add_width < -10.0) {
            window.alert("Width is out of bounds.");
            return;
        }
        // Bonus mark: check the minimum/maximum limit and increase/decrease 
        //    size (height and width are changed separatly)
        let new_height = div_height + add_height;
        let new_width = div_width + add_width;
        
        if (new_height <= 20.0 && new_height >= 0.0) {
            part5_div.style.height = new_height.toString() + "em";
            div_height = new_height;
        }
        if (new_width <= 20.0 && new_width >= 0.0) {
            part5_div.style.width = new_width.toString() + "em";
            div_width = new_width;
        }
    });
    
    // Part 6: adding children when any of the list items are pressed
    // Note: copied from slides again :(
    var part6_ul = document.querySelector(".part6 > ul");
    part6_ul.addEventListener('click', (ev) => {
        if (ev.target.nodeName == "LI") {
            let new_item = document.createElement("li");
            new_item.appendChild(document.createTextNode("I am born!"));
            part6_ul.appendChild(new_item);
        }
    });
    
    // Part 7: convoluted list operations
    var part7_ul = document.querySelector(".part7 > ul");
    
    part7_ul.addEventListener('click', (ev) => {
        if (ev.target.nodeName == "LI") {
            // Get the total number of list elements (should be 6)
            let num_children = part7_ul.childNodes.length;
            // Set foundIndex to NaN if we don't find it (failsafe check)
            let found_index = NaN;
            // Find the child's index that sent an event
            for (let i = 0;i < num_children; i++) {
                if (part7_ul.childNodes[i] === ev.target) {
                    found_index = i;
                    break;
                }
            }
            
            // Failsafe check
            if (isNaN(found_index)) {
                window.alert("Script for convoluted operations does not work.\n"
                    + "Punish Alisher for bad work.");
            }    
            // Note: found index is 0-based, so even numbers % 2 = 1, 
            //    and odd - otherwise. I did not change it because we are using
            //    found_index later when deleting/adding list items
            else if (found_index % 2 == 0) {
                let new_item = document.createElement("li");
                new_item.appendChild(
                    document.createTextNode("I have risen from the ashes.")
                );
                // To not store a child that needs to be removed I just do the 
                //     replacement in one line
                part7_ul.replaceChild(
                    new_item, 
                    part7_ul.childNodes.item(found_index)
                );
            }
            else {
                part7_ul.childNodes[found_index].classList.add("pink");
            }
        }
    });
    
    // Part 8: fetch header and text from another HTML file and 
    //     replace div contents on click
    var part8_h3 = document.querySelector(".part8 h3");
    // Failsafe mechanism:
    //     If can't fetch (server connection lost, server problem, etc.)
    //     an error is thrown and caught at the same time.
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise/then#Chaining
    part8_h3.addEventListener('click', () => 
        fetch("kazakhstan.html")
        .then((response) => {
            if (!response.ok) {
                throw new Error(response.status + " " + response.statusText);
            } 
            // This solution was found on Stackoverflow:
            // https://stackoverflow.com/questions/36631762/returning-html-with-fetch
            return response.text();
        })
        .then((html) => {
            console.log("came here");
            // Navigate to div using parentNode
            let parent_div = part8_h3.parentNode;
            // innerHTML is simply replaced with fetched data
            parent_div.innerHTML = html;
        }, e => {
                    console.error(e);
                    window.alert("Fetching error: " + e.message + "\n"
                        + "Punish Alisher for bad work.");
        }), 
        { once: true }
    );
});