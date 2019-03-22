$('#btnSelectImg').on('click', function (e) {
    e.preventDefault();
    var finder = new CKFinder();
    finder.selectActionFunction = function (url) {
        $('#txtImg').val(url);
    };
    finder.popup();
});