(function ($) {

    'use strict'; // Start of use strict

    let connection = new SignalR
        .HubConnectionBuilder()
        .withUrl('/signalRServer')
        .build();

    connection.start();
    connection.on('refreshTypes', function () {
        loadTypes();
    });
     
    async function loadTypes() {

        const response = await fetch('http://localhost:5086/api/types');
        cons0t data = await response.json();

        const template = data.map(item => {

        });

        console.log(template);
    }

    loadTypes();
})(jQuery);