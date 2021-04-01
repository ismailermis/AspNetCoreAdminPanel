/**
 * @license Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'tr,fr,en';
    //config.uiColor = '#AADC6E';
    config.removeDialogTabs = 'link:target;link:advanced;image:Link;image:advanced';
    config.removeButtons = 'Underline,JustifyCenter,ImageButton';
    config.removePlugins = 'elementspath,save,font,videodetector,zamanager';
      config.extraPlugins = 'video,youtube,html5video,filebrowser';
};

