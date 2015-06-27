function ReturnToDoListView() {
    "use strict";

    var ToDoList = [{
        Title: "Pick Up Dry Cleaning",
        IsDone: false,
    },
    {
        Title: "Get Haircut",
        IsDone: true,
    },
    {
        Title: "Learn Gulp!",
        IsDone: true,
    }
    ];

    for (var todoItem in ToDoList) {
        $.ajax({
            url: "api/ToDo/create",
            data: todoItem,
            success: success
        });
    }
}

function success() {
    alert("hurray!");
}