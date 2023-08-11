const connection = new signalR.HubConnectionBuilder().withUrl("/update").build();

connection.on("UpdateJobs", function () {
    
    let model = {
        Category: document.getElementById("Category").value,
        JobsPerPage: document.getElementById("JobsPerPage").value,
        SearchTerm: document.getElementById("SearchTerm").value,
        JobSorting: document.getElementById("JobSorting").value
    };

    const params = new Proxy(new URLSearchParams(window.location.search), {
        get: (searchParams, prop) => searchParams.get(prop),
    });
    let value = params.currentPage;
    if (value !== null) model.CurrentPage = value;
    
    $.ajax({
        type: 'GET',
        url: '/Job/All/',
        data: model,
        success: function (response) {
            document.body.innerHTML = response;
        },
        error: function (response) {
            console.log(response);
        }
    });
});

connection.on("UpdateArticles", function () {

    $.ajax({
        type: 'GET',
        url: '/Article/All/',
        success: function (response) {
            document.body.innerHTML = response;
        },
        error: function (response) {
            console.log(response);
        }
    });
});

connection.start().then().catch(function (err) {
    console.log(err.toString());
});