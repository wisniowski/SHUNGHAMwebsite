Type.registerNamespace("SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer");

SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer.ContactUsWidgetDesigner = function (element) {
    /* Initialize BackgroundImageId fields */
    this._selectButtonBackgroundImageId = null;
    this._selectButtonBackgroundImageIdClickDelegate = null;
    this._deselectButtonBackgroundImageId = null;
    this._deselectButtonBackgroundImageIdClickDelegate = null;
    this._selectorBackgroundImageIdCloseDelegate = null;
    this._selectorBackgroundImageIdUploaderViewFileChangedDelegate = null;

    this._BackgroundImageIdDialog = null;
    this._selectorBackgroundImageId = null;
    this._BackgroundImageIdId = null;

    /* Initialize the service url for the image thumbnails */
    this.imageServiceUrl = null;

    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer.ContactUsWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer.ContactUsWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer.ContactUsWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize BackgroundImageId */
        this._selectButtonBackgroundImageIdClickDelegate = Function.createDelegate(this, this._selectButtonBackgroundImageIdClicked);
        if (this._selectButtonBackgroundImageId) {
            $addHandler(this._selectButtonBackgroundImageId, "click", this._selectButtonBackgroundImageIdClickDelegate);
        }

        this._deselectButtonBackgroundImageIdClickDelegate = Function.createDelegate(this, this._deselectButtonBackgroundImageIdClicked);
        if (this._deselectButtonBackgroundImageId) {
            $addHandler(this._deselectButtonBackgroundImageId, "click", this._deselectButtonBackgroundImageIdClickDelegate);
        }

        if (this._selectorBackgroundImageId) {
            this._BackgroundImageIdDialog = jQuery(this._selectorBackgroundImageId.get_element()).dialog({
                autoOpen: false,
                modal: false,
                width: 655,
                height: "auto",
                closeOnEscape: true,
                resizable: false,
                draggable: false,
                zIndex: 5000,
                close: this._selectorBackgroundImageIdCloseDelegate
            });
        }

        jQuery("#previewBackgroundImageId").load(function () {
            dialogBase.resizeToContent();
        });

        this._selectorBackgroundImageIdInsertDelegate = Function.createDelegate(this, this._selectorBackgroundImageIdInsertHandler);
        this._selectorBackgroundImageId.set_customInsertDelegate(this._selectorBackgroundImageIdInsertDelegate);
        $addHandler(this._selectorBackgroundImageId._cancelLink, "click", this._selectorBackgroundImageIdCloseHandler);
        this._selectorBackgroundImageIdCloseDelegate = Function.createDelegate(this, this._selectorBackgroundImageIdCloseHandler);
        this._selectorBackgroundImageIdUploaderViewFileChangedDelegate = Function.createDelegate(this, this._selectorBackgroundImageIdUploaderViewFileChangedHandler);
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer.ContactUsWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose BackgroundImageId */
        if (this._selectButtonBackgroundImageId) {
            $removeHandler(this._selectButtonBackgroundImageId, "click", this._selectButtonBackgroundImageIdClickDelegate);
        }
        if (this._selectButtonBackgroundImageIdClickDelegate) {
            delete this._selectButtonBackgroundImageIdClickDelegate;
        }

        if (this._deselectButtonBackgroundImageId) {
            $removeHandler(this._deselectButtonBackgroundImageId, "click", this._deselectButtonBackgroundImageIdClickDelegate);
        }
        if (this._deselectButtonBackgroundImageIdClickDelegate) {
            delete this._deselectButtonBackgroundImageIdClickDelegate;
        }

        $removeHandler(this._selectorBackgroundImageId._cancelLink, "click", this._selectorBackgroundImageIdCloseHandler);

        if (this._selectorBackgroundImageIdCloseDelegate) {
            delete this._selectorBackgroundImageIdCloseDelegate;
        }

        if (this._selectorBackgroundImageIdUploaderViewFileChangedDelegate) {
            this._selectorBackgroundImageId._uploaderView.remove_onFileChanged(this._selectorBackgroundImageIdUploaderViewFileChangedDelegate);
            delete this._selectorBackgroundImageIdUploaderViewFileChangedDelegate;
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

        /* RefreshUI BackgroundImageId */
        this.get_selectedBackgroundImageId().innerHTML = controlData.BackgroundImageId;
        if (controlData.BackgroundImageId && controlData.BackgroundImageId != "00000000-0000-0000-0000-000000000000") {
            this.get_selectButtonBackgroundImageId().innerHTML = "<span class=\"sfLinkBtnIn\">Change</span>";
            jQuery(this.get_deselectButtonBackgroundImageId()).show()
            var url = this.imageServiceUrl + controlData.BackgroundImageId + "/?published=true";
            jQuery.ajax({
                url: url,
                type: "GET",
                contentType: "application/json",
                dataType: "json",
                success: function (data) {
                    jQuery("#previewBackgroundImageId").show();
                    jQuery("#previewBackgroundImageId").attr("src", data.Item.ThumbnailUrl);
                    dialogBase.resizeToContent();
                }
            });
        }
        else {
            jQuery(this.get_deselectButtonBackgroundImageId()).hide()
        }
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges BackgroundImageId */
        controlData.BackgroundImageId = this.get_selectedBackgroundImageId().innerHTML;
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* BackgroundImageId event handlers */
    _selectButtonBackgroundImageIdClicked: function (sender, args) {
        this._selectorBackgroundImageId._uploaderView.add_onFileChanged(this._selectorBackgroundImageIdUploaderViewFileChangedDelegate);
        this._BackgroundImageIdDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._BackgroundImageIdDialog.dialog().parent().css("min-width", "655px");
        dialogBase.resizeToContent();
        try {
            this._selectorBackgroundImageId.get_uploaderView().get_altTextField().set_value("");
        }
        catch (ex) { }
        jQuery(this._selectorBackgroundImageId.get_uploaderView().get_settingsPanel()).hide();
        return false;
    },

    _deselectButtonBackgroundImageIdClicked: function (sender, args) {
        jQuery("#previewBackgroundImageId").hide();
        jQuery("#previewBackgroundImageId").attr("src", "");
        this.get_selectedBackgroundImageId().innerHTML = "00000000-0000-0000-0000-000000000000";
        this.get_selectButtonBackgroundImageId().innerHTML = "<span class=\"sfLinkBtnIn\">Select...</span>";
        jQuery(this.get_deselectButtonBackgroundImageId()).hide()
        dialogBase.resizeToContent();
        return false;
    },

    /* --------------------------------- private methods --------------------------------- */

    /* BackgroundImageId private methods */
    _selectorBackgroundImageIdInsertHandler: function (selectedItem) {

        if (selectedItem) {
            this._BackgroundImageIdId = selectedItem.Id;
            this.get_selectedBackgroundImageId().innerHTML = this._BackgroundImageIdId;
            jQuery(this.get_deselectButtonBackgroundImageId()).show()
            this.get_selectButtonBackgroundImageId().innerHTML = "<span class=\"sfLinkBtnIn\">Change</span>";
            jQuery("#previewBackgroundImageId").show();
            jQuery("#previewBackgroundImageId").attr("src", selectedItem.ThumbnailUrl);
        }
        this._BackgroundImageIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    _selectorBackgroundImageIdCloseHandler: function () {
        if (this._BackgroundImageIdDialog) {
            this._BackgroundImageIdDialog.dialog("close");
        }
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    _selectorBackgroundImageIdUploaderViewFileChangedHandler: function () {
        dialogBase.resizeToContent();
    },

    /* --------------------------------- properties -------------------------------------- */

    /* BackgroundImageId properties */
    get_selectorBackgroundImageId: function () {
        return this._selectorBackgroundImageId;
    },
    set_selectorBackgroundImageId: function (value) {
        this._selectorBackgroundImageId = value;
    },
    get_selectButtonBackgroundImageId: function () {
        return this._selectButtonBackgroundImageId;
    },
    set_selectButtonBackgroundImageId: function (value) {
        this._selectButtonBackgroundImageId = value;
    },
    get_deselectButtonBackgroundImageId: function () {
        return this._deselectButtonBackgroundImageId;
    },
    set_deselectButtonBackgroundImageId: function (value) {
        this._deselectButtonBackgroundImageId = value;
    },
    get_selectedBackgroundImageId: function () {
        if (this._selectedBackgroundImageId == null) {
            this._selectedBackgroundImageId = this.findElement("selectedBackgroundImageId");
        }
        return this._selectedBackgroundImageId;
    }
}

SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer.ContactUsWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.ContactUsWidget.Designer.ContactUsWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
