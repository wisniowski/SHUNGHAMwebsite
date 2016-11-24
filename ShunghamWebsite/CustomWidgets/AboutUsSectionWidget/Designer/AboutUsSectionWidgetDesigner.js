Type.registerNamespace("SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.Designer");

SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.Designer.AboutUsSectionWidgetDesigner = function (element) {
    /* Initialize Title fields */
    this._title = null;
    
    /* Initialize Content fields */
    this._content = null;
    
    /* Initialize Image fields */
    this._selectButtonImage = null;
    this._selectButtonImageClickDelegate = null;
    this._deselectButtonImage = null;
    this._deselectButtonImageClickDelegate = null;
    this._selectorImageCloseDelegate = null;
    this._selectorImageUploaderViewFileChangedDelegate = null;
    
    this._ImageDialog = null;
    this._selectorImage = null;
    this._ImageId = null;
    
    /* Initialize the service url for the image thumbnails */
    this.imageServiceUrl = null;

    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.Designer.AboutUsSectionWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.Designer.AboutUsSectionWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.Designer.AboutUsSectionWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize Image */
        this._selectButtonImageClickDelegate = Function.createDelegate(this, this._selectButtonImageClicked);
        if (this._selectButtonImage) {
            $addHandler(this._selectButtonImage, "click", this._selectButtonImageClickDelegate);
        }

        this._deselectButtonImageClickDelegate = Function.createDelegate(this, this._deselectButtonImageClicked);
        if (this._deselectButtonImage) {
            $addHandler(this._deselectButtonImage, "click", this._deselectButtonImageClickDelegate);
        }

        if (this._selectorImage) {
            this._ImageDialog = jQuery(this._selectorImage.get_element()).dialog({
                autoOpen: false,
                modal: false,
                width: 655,
                height: "auto",
                closeOnEscape: true,
                resizable: false,
                draggable: false,
                zIndex: 5000,
                close: this._selectorImageCloseDelegate
            });
        } 

        jQuery("#previewImage").load(function () {
            dialogBase.resizeToContent();
        });

        this._selectorImageInsertDelegate = Function.createDelegate(this, this._selectorImageInsertHandler);
        this._selectorImage.set_customInsertDelegate(this._selectorImageInsertDelegate);
        $addHandler(this._selectorImage._cancelLink, "click", this._selectorImageCloseHandler);
        this._selectorImageCloseDelegate = Function.createDelegate(this, this._selectorImageCloseHandler);
        this._selectorImageUploaderViewFileChangedDelegate = Function.createDelegate(this, this._selectorImageUploaderViewFileChangedHandler);
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.Designer.AboutUsSectionWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose Image */
        if (this._selectButtonImage) {
            $removeHandler(this._selectButtonImage, "click", this._selectButtonImageClickDelegate);
        }
        if (this._selectButtonImageClickDelegate) {
            delete this._selectButtonImageClickDelegate;
        }
        
        if (this._deselectButtonImage) {
            $removeHandler(this._deselectButtonImage, "click", this._deselectButtonImageClickDelegate);
        }
        if (this._deselectButtonImageClickDelegate) {
            delete this._deselectButtonImageClickDelegate;
        }

        $removeHandler(this._selectorImage._cancelLink, "click", this._selectorImageCloseHandler);

        if (this._selectorImageCloseDelegate) {
            delete this._selectorImageCloseDelegate;
        }

        if (this._selectorImageUploaderViewFileChangedDelegate) {
            this._selectorImage._uploaderView.remove_onFileChanged(this._selectorImageUploaderViewFileChangedDelegate);
            delete this._selectorImageUploaderViewFileChangedDelegate;
        }
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI Title */
        this.get_title().control.set_value(controlData.Title);

        /* RefreshUI Content */
        this.get_content().control.set_value(controlData.Content);

        /* RefreshUI Image */
        this.get_selectedImage().innerHTML = controlData.Image;
        if (controlData.Image && controlData.Image != "00000000-0000-0000-0000-000000000000") {
            this.get_selectButtonImage().innerHTML = "<span class=\"sfLinkBtnIn\">Change</span>";
            jQuery(this.get_deselectButtonImage()).show()
            var url = this.imageServiceUrl + controlData.Image + "/?published=true";
            jQuery.ajax({
                url: url,
                type: "GET",
                contentType: "application/json",
                dataType: "json",
                success: function (data) {
                    jQuery("#previewImage").show();
                    jQuery("#previewImage").attr("src", data.Item.ThumbnailUrl);
                    dialogBase.resizeToContent();
                }
            });
        }
        else {
            jQuery(this.get_deselectButtonImage()).hide()
        }

        /* RefreshUI ImageAlignment */
        jQuery("#AlignmentSelector").val(controlData.ImageAlignment);

        /* RefreshUI TextBackgroundColor */
        jQuery("#TextBackgroundColorSelector").val(controlData.TextBackgroundColor);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges Title */
        controlData.Title = this.get_title().control.get_value();

        /* ApplyChanges Content */
        controlData.Content = this.get_content().control.get_value();

        /* ApplyChanges Image */
        controlData.Image = this.get_selectedImage().innerHTML;

        /* ApplyChanges ImageAlignment */
        controlData.ImageAlignment = jQuery("#AlignmentSelector").val();

        /* ApplyChanges TextBackgroundColor */
        controlData.TextBackgroundColor = jQuery("#TextBackgroundColorSelector").val();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* Image event handlers */
    _selectButtonImageClicked: function (sender, args) {
        this._selectorImage._uploaderView.add_onFileChanged(this._selectorImageUploaderViewFileChangedDelegate);
        this._ImageDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._ImageDialog.dialog().parent().css("min-width", "655px");
        dialogBase.resizeToContent();
        try {
            this._selectorImage.get_uploaderView().get_altTextField().set_value("");
        }
        catch (ex) { }
        jQuery(this._selectorImage.get_uploaderView().get_settingsPanel()).hide();
        return false;
    },

    _deselectButtonImageClicked: function (sender, args) {
        jQuery("#previewImage").hide();
                    jQuery("#previewImage").attr("src", "");
        this.get_selectedImage().innerHTML = "00000000-0000-0000-0000-000000000000";
        this.get_selectButtonImage().innerHTML = "<span class=\"sfLinkBtnIn\">Select...</span>";
        jQuery(this.get_deselectButtonImage()).hide()
		dialogBase.resizeToContent();
        return false;
    },

    /* --------------------------------- private methods --------------------------------- */

    /* Image private methods */
    _selectorImageInsertHandler: function (selectedItem) {

        if (selectedItem) {
            this._ImageId = selectedItem.Id;
            this.get_selectedImage().innerHTML = this._ImageId;
            jQuery(this.get_deselectButtonImage()).show()
            this.get_selectButtonImage().innerHTML = "<span class=\"sfLinkBtnIn\">Change</span>";
            jQuery("#previewImage").show();
                    jQuery("#previewImage").attr("src", selectedItem.ThumbnailUrl);
        }
        this._ImageDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    _selectorImageCloseHandler: function () {
        if(this._ImageDialog){
            this._ImageDialog.dialog("close");
        }
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    _selectorImageUploaderViewFileChangedHandler: function () {
        dialogBase.resizeToContent();
    },

    /* --------------------------------- properties -------------------------------------- */

    /* Title properties */
    get_title: function () { return this._title; }, 
    set_title: function (value) { this._title = value; },

    /* Content properties */
    get_content: function () { return this._content; }, 
    set_content: function (value) { this._content = value; },

    /* Image properties */
    get_selectorImage: function () {
        return this._selectorImage;
    },
    set_selectorImage: function (value) {
        this._selectorImage = value;
    },
    get_selectButtonImage: function () {
        return this._selectButtonImage;
    },
    set_selectButtonImage: function (value) {
        this._selectButtonImage = value;
    },
    get_deselectButtonImage: function () {
        return this._deselectButtonImage;
    },
    set_deselectButtonImage: function (value) {
        this._deselectButtonImage = value;
    },
    get_selectedImage: function () {
        if (this._selectedImage == null) {
            this._selectedImage = this.findElement("selectedImage");
        }
        return this._selectedImage;
    }
}

SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.Designer.AboutUsSectionWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.Designer.AboutUsSectionWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
