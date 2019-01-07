//Admin---------------
$("#ImageUpload").change(function () {
    var formData = new FormData();
    var file = document.getElementById("ImageUpload").files[0];
    formData.append("ImageUpload", file);
    $.ajax({
        type: "POST",
        url: "/Home/Upload",
        data: formData,
        dataType: "json",
        contentType: false,
        processData: false,
        success: function (data, status) {
            alert("Add " + status + " " + data.UploadedFilename);
            $("#imgFile").html("<img src='/img/Admin/" + data.UploadedFilename + "'style='width: 200px; height: 200px;'>");
        },
        error: function (error, xhr, status, statusTxt) {
            alert(error + ": " + statusTxt + "\n" + status + "\n" + xhr.status);
        }
    });
});