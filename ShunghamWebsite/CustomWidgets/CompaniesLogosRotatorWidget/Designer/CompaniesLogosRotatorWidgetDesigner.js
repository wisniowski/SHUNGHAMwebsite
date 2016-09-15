Type.registerNamespace("SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer");

SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer.CompaniesLogosRotatorWidgetDesigner = function (element) {
    /* Initialize AlbumId fields */
    this._selectButtonAlbumId = null;
    this._selectButtonAlbumIdClickDelegate = null;
    this._deselectButtonAlbumId = null;
    this._deselectButtonAlbumIdClickDelegate = null;
    this._lnkDoneAlbumId = null;
    this._lnkCancelAlbumId = null;
    this._selectAlbumIdDialog = null;
    this._AlbumIdItemSelector = null;
    this._AlbumIdSelectedKeys = null;
    this._AlbumIdSelectedItems = null;
    this._AlbumIdBinderBound = false;
    this._doneSelectingAlbumIdDelegate = null;
    this._cancelAlbumIdDelegate = null;
    this._AlbumIdItemSelectorCloseDelegate = null;
    
    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer.CompaniesLogosRotatorWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer.CompaniesLogosRotatorWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer.CompaniesLogosRotatorWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize AlbumId */
        if (this._selectButtonAlbumId) {
            this._selectButtonAlbumIdClickDelegate = Function.createDelegate(this, this._selectButtonAlbumIdClicked);
            $addHandler(this._selectButtonAlbumId, "click", this._selectButtonAlbumIdClickDelegate);
        }
        
        if (this._deselectButtonAlbumId) {
            this._deselectButtonAlbumIdClickDelegate = Function.createDelegate(this, this._deselectButtonAlbumIdClicked);
            $addHandler(this._deselectButtonAlbumId, "click", this._deselectButtonAlbumIdClickDelegate);
        }

        if (this._lnkDoneAlbumId) {
            this._AlbumIdDoneSelectingDelegate = Function.createDelegate(this, this._AlbumIdDoneSelecting);
            $addHandler(this._lnkDoneAlbumId, "click", this._AlbumIdDoneSelectingDelegate);
        }

        if (this._lnkCancelAlbumId) {
            this._AlbumIdCancelDelegate = Function.createDelegate(this, this._AlbumIdItemSelectorCloseHandler);
            $addHandler(this._lnkCancelAlbumId, "click", this._AlbumIdCancelDelegate);
        }

        this._selectAlbumIdDialog = jQuery("#AlbumIdSelector").dialog({
            autoOpen: false,
            modal: false,
            width: 540,
            height: "auto",
            closeOnEscape: true,
            resizable: false,
            draggable: false,
            zIndex: 5000,
        });
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer.CompaniesLogosRotatorWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose AlbumId */
        
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI AlbumId */
        this.get_selectedAlbumId().innerHTML = controlData.AlbumId;
        if (controlData.AlbumId && controlData.AlbumId != "00000000-0000-0000-0000-000000000000") {
            this.get_selectButtonAlbumId().innerHTML = '<span class=\"sfLinkBtnIn\">Change</span>';
            $(this.get_deselectButtonAlbumId()).show()
        }
        else {
            $(this.get_deselectButtonAlbumId()).hide()
        }
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges AlbumId */
        controlData.AlbumId = this.get_selectedAlbumId().innerHTML;
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* AlbumId event handlers */


    /* --------------------------------- private methods --------------------------------- */

    /* AlbumId private methods */
    _selectButtonAlbumIdClicked: function (sender, args) {
        var itemSelector = this.get_AlbumIdItemSelector();
        if (itemSelector) {
            // dynamic items don't support fallback, the binder search should work as in monolingual 
            //itemSelector._selectorSearchBox.get_binderSearch()._multilingual = false;
            itemSelector.dataBind();
        }

        this._selectAlbumIdDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._selectAlbumIdDialog.dialog().parent().css("min-width", "525px");
        dialogBase.resizeToContent();
        return false;
    },
    
    _deselectButtonAlbumIdClicked: function (sender, args) {
        this.get_selectedAlbumId().innerHTML = "00000000-0000-0000-0000-000000000000";
        this.get_selectButtonAlbumId().innerHTML = '<span class=\"sfLinkBtnIn\">Select...</span>';
        $(this.get_deselectButtonAlbumId()).hide()
        return false;
    },

    _AlbumIdItemSelectorCloseHandler: function (sender, args) {
        this._selectAlbumIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    _AlbumIdDoneSelecting: function (sender, args) {
        var selectedItem = this.get_AlbumIdSelectedItems()[0];
        if (selectedItem != null) {
            this.get_selectedAlbumId().innerHTML = selectedItem.Id;
            this.get_selectButtonAlbumId().innerHTML = '<span class=\"sfLinkBtnIn\">Change</span>';
            $(this.get_deselectButtonAlbumId()).show()
        }
        this._selectAlbumIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    /* --------------------------------- properties -------------------------------------- */

    /* AlbumId properties */
    get_selectButtonAlbumId: function () {
        return this._selectButtonAlbumId;
    },
    set_selectButtonAlbumId: function (value) {
        this._selectButtonAlbumId = value;
    },
    
    get_deselectButtonAlbumId: function () {
        return this._deselectButtonAlbumId;
    },
    set_deselectButtonAlbumId: function (value) {
        this._deselectButtonAlbumId = value;
    },

    get_AlbumIdItemSelector: function () {
        return this._AlbumIdItemSelector;
    },
    set_AlbumIdItemSelector: function (value) {
        this._AlbumIdItemSelector = value;
    },

    get_AlbumIdBinder: function () {
        return this._AlbumIdItemSelector.get_binder();
    },

    get_AlbumIdSelectedKeys: function () {
        return this._AlbumIdItemSelector.get_selectedKeys();
    },
    set_AlbumIdSelectedKeys: function (keys) {
        this._selectedKeys = keys;
    },

    get_AlbumIdSelectedItems: function () {
        return this._AlbumIdItemSelector.getSelectedItems();
    },
    set_AlbumIdSelectedItems: function (items) {
        this._AlbumIdSelectedItems = items;
        if (this._AlbumIdBinderBound) {
            this._AlbumIdItemSelector.bindSelector();
        }
    },

    get_lnkDoneAlbumId: function () {
        return this._lnkDoneAlbumId;
    },
    set_lnkDoneAlbumId: function (value) {
        this._lnkDoneAlbumId = value;
    },
    get_lnkCancelAlbumId: function () {
        return this._lnkCancelAlbumId;
    },
    set_lnkCancelAlbumId: function (value) {
        this._lnkCancelAlbumId = value;
    },
    get_selectedAlbumId: function () {
        if (this._selectedAlbumIdLabel == null) {
            this._selectedAlbumIdLabel = jQuery(this.get_element()).find('#selectedAlbumIdLabel').get(0);
        }
        return this._selectedAlbumIdLabel;
    }
}

SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer.CompaniesLogosRotatorWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.CompaniesLogosRotatorWidget.Designer.CompaniesLogosRotatorWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
