$(function () {
    // Button click event handler
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this); // Button elementini seç
        bootbox.confirm("Departmanı silmek istediğinize emin misiniz?", function (result) {
            if (result) {
                var Id = btn.data("id"); // 'id' küçük harfle olmalı
                $.ajax({
                    type: "GET", // HTTP metodu büyük harfle yazılmalı
                    url: "/Departman/Sil/" + Id,
                    success: function () {
                        btn.closest('tr').remove(); // Satırı kaldır
                    }
                });
            }
        });
    });
});

function CheckDateTypeIsValid(dateElement) {
    var value = $(dateElement).val();
    if (value === '') {
        $(dateElement).valid(); // Boş olanları 'false' yapma
    } else {
        $(dateElement).valid();
    }
}
