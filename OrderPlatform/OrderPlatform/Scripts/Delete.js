$(document).ready(function () {
    $(".deleteRow").click(function () {
        if (confirm("Are you sure you want to delete this row?")) {
            var $row = $(this).closest('tr');
            $.ajax({
                url: this.href,
                cache: false,
                success: function (html) {
                    if (html == '') {
                        $row.remove();
                    }
                    else
                        alert(html);
                }
            });
        }
        return false;
    });
});