"use strict";
var blog = {}; //My application object

//Validate Blog form Inputs
blog.Validate = function () {
    "use strict";
    var blogger = document.getElementById("Blogger").value;
    var blogTitle = document.getElementById("BlogTitle").value;
    var msg = document.getElementById("Msg").value;

    //Validate the inputs before sending it to the server
    if (!(blogger && blogTitle && msg)) {
        //Alert
        alert("Some inputs are empty")
    } else {
        //submit the form
        document.getElementById("blogForm").submit();
    }

};

//Confirm Delete operation
blog.ValidComment = function () {
    "use strict";
    var blogger = document.getElementById("Blogger").value;
    var msg = document.getElementById("Msg").value;

    //Validate the inputs before sending it to the server
    if (!(blogger && msg)) {
        //Alert
        alert("Some inputs are empty")
    } else {
        //submit the form
        document.getElementById("blogForm").submit();
    }
};

