function showAlert(name) {
    alert('Hello ' + name);
}

function callStaticCsharpMethod() {
    await DotNet.invokeMethodAsync('BooksStore', 'Sum', 3, 5)
        .then(data => {
            console.log(data);
        })
        .catch(error => {
            console.log(error);
        });
}

function triggerOnWindowResized(dotnetObjRef) {
    window.onresize = function () {
        dotnetObjRef.invokeMethodAsync('OnWindowResized',
            window.innerWidth, window.innerHeight);
    }
}