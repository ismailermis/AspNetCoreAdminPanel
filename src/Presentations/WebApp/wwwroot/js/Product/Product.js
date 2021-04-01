

var filetype = 'video';

CKEDITOR.replace('ProductDesc', {
    customConfig: '/ckeditor/Config.js',
    filebrowserBrowseUrl: '/CropImage/BrowseImage?ftype=' + filetype,
    filebrowserUploadUrl: '/CropImage/UploadImage',
    filebrowserFlashBrowseUrl: '/CropImage/BrowseImage?ftype=flv',
    filebrowserFlashUploadUrl: '/CropImage/UploadImage'
});

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-center",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "3000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

CKEDITOR.on('dialogDefinition', function (event) {
    var dialogName = event.data.name,
        dialogDefinition = event.data.definition,
        infoTab,
        browse;

    // Check if the definition is from the dialog window you are interested in (the "Image" dialog window).
    if (dialogName == 'image' || dialogName == 'link' || dialogName == 'html5video') {
        // Get a reference to the "Image Info" tab.
        infoTab = dialogDefinition.getContents('info');

        // Get the "Browse" button
        browse = infoTab.get('browse');
        browseposter = infoTab.get('browseposter');
        // Override the "onClick" function
        browse.onClick = function () {
            var dialog = this.getDialog();
            var editor = dialog.getParentEditor();
            editor._.filebrowserSe = this;

            var params = this.filebrowser.params || {};
            params.CKEditor = editor.name;
            params.CKEditorFuncNum = editor._.filebrowserFn;
            if (!params.langCode)
                params.langCode = editor.langCode;

            var url = this.filebrowser.url + "&CKEditor=" + params.CKEditor + "&CKEditorFuncNum=" + params.CKEditorFuncNum;

            if (dialogName == 'link') {
                url = url.replace("video", "");
            } else if (dialogName == 'html5video') {
                if (url.indexOf("image") > 0) {
                    url = url.replace("image", "video");
                }
            } else {
                url = url.replace("video", "image");
            }

            editor.popup(url, 800, 600, editor.config.filebrowserWindowFeatures || editor.config.fileBrowserWindowFeatures);

        }
        if (browseposter != null) {
            browseposter.onClick = function () {

                var dialog = this.getDialog();
                var editor = dialog.getParentEditor();
                editor._.filebrowserSe = this;

                var params = this.filebrowser.params || {};
                params.CKEditor = editor.name;
                params.CKEditorFuncNum = editor._.filebrowserFn;
                if (!params.langCode)
                    params.langCode = editor.langCode;

                var url = this.filebrowser.url + "&CKEditor=" + params.CKEditor + "&CKEditorFuncNum=" + params.CKEditorFuncNum;

                url = url.replace("video", "image");

                editor.popup(url, 800, 600, editor.config.filebrowserWindowFeatures || editor.config.fileBrowserWindowFeatures);

            }
        }
    }


});

CKEDITOR.on('fileUploadRequest', function (evt) {
    var fileLoader = evt.data.fileLoader,
        formData = new FormData(),
        xhr = fileLoader.xhr;

    xhr.open('PUT', fileLoader.uploadUrl, true);
    formData.append('upload', fileLoader.file, fileLoader.fileName);
    fileLoader.xhr.send(formData);

    // Prevented the default behavior.
    evt.stop();
}, null, null, 4);


    $(':input').val('');
    var form = $("#productAddForm");
    
    $('#productSubmitBtn').click(function (evt) {

        if (form.valid()) {
            var fileName = $('#File')[0].files[0].name;
            var getFileExt = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
            if (CKEDITOR.instances['ProductDesc'].getData()=="") {
                toastr["warning"]("Description field cannot be empty", "Ürün Ekleme") 
                return;
            }  
             
            var formData = new FormData();

            formData.append("Name", $('#Name').val());
            formData.append("ProductDesc", CKEDITOR.instances['ProductDesc'].getData());
            formData.append("Quantity", $('#Quantity').val());
            formData.append("Price", $('#Price').val());
            formData.append("ProductTypeId", $("#ProductTypeId").val());
            formData.append("ProductBrandId", $("#ProductBrandId").val());
            formData.append("File", $('#File')[0].files[0]);

            var _url = '/Product/AddProduct/';
            $.ajax({
                url: _url,
                type: 'POST',
                data: formData,
                async: false,
                processData: false,  // tell jQuery not to process the data
                contentType: false,  // tell jQuery not to set contentType
                success: function (result) {
                    if (result == "1") {
                        $('#validationMessage').html('Bir ürün seçmelisiniz.');
                         
                        toastr["success"]("Kayıt işlemi gerçekleşti", "Ürün Ekleme")
                    }
                    $(':input').val('');
                     
                    CKEDITOR.instances['ProductDesc'].updateElement();
                    CKEDITOR.instances['ProductDesc'].setData('');
                },
                error: function (jqXHR) {
                    swal({
                        title: "Ürün Ekleme hatası",
                        text: response.responseText,
                        type: "info",
                        showCancelButton: false,
                        closeOnConfirm: false,
                        showLoaderOnConfirm: true
                    });
                },
                complete: function (jqXHR, status) {
                }
            });

            
            //$.ajax({
            //    url: '/Product/AddProduct/',
            //    type: "POST",
            //    async: true,
            //    cache: false,
            //    type: 'POST',
            //    data: formData,
            //    contentType: 'application/json; charset=utf-8',
            //    processData: false,  // tell jQuery not to process the data
            //    success: function (result) {
            //        if (result == "1") {
            //            //swal({
            //            //    title: "Ürün Ekleme",
            //            //    text: "Kayıt işlemi gerçekleşti",
            //            //    type: "info",
            //            //    showCancelButton: false,
            //            //    closeOnConfirm: false,
            //            //    showLoaderOnConfirm: true
            //            //});
            //        }

            //        $(':input').val('');
            //        //location.reload(true);


            //    },
            //    failure: function (response) {

            //        //swal({
            //        //    title: "Ürün Ekleme hatası",
            //        //    text: response.responseText,
            //        //    type: "info",
            //        //    showCancelButton: false,
            //        //    closeOnConfirm: false,
            //        //    showLoaderOnConfirm: true
            //        //});
            //    },
            //    error: function (response) {
            //        //swal({
            //        //    title: "Ürün Ekleme hatası 2",
            //        //    text: response.responseText,
            //        //    type: "info",
            //        //    showCancelButton: false,
            //        //    closeOnConfirm: false,
            //        //    showLoaderOnConfirm: true
            //        //});
            //    }
            //});

        }

    });
 
