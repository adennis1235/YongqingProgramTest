$(function () {
    $('#btnSearch').click(function (e) {
        document.getElementById("SearchForm").submit();
    });
});

function btnEdit(CustomerId, ActionType) 
{
    $("input[name='CustomerId']").val(CustomerId);
    $("input[name='ActionType']").val(ActionType);

    document.getElementById("EditForm").submit();
}

function btnTrash(CustomerId, ActionType) {
    if (confirm("確定要刪除 客戶編號 : " + CustomerId + " ??")) {
        $("input[name='CustomerId']").val(CustomerId);
        $("input[name='ActionType']").val(ActionType);
        document.getElementById("SaveEditForm").submit();
    }
}