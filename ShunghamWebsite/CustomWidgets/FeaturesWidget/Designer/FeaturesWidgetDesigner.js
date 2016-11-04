Type.registerNamespace("SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer");

SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer.FeaturesWidgetDesigner = function (element) {
    /* Initialize ProductId fields */
    this._selectButtonProductId = null;
    this._selectButtonProductIdClickDelegate = null;
    this._deselectButtonProductId = null;
    this._deselectButtonProductIdClickDelegate = null;
    this._lnkDoneProductId = null;
    this._lnkCancelProductId = null;
    this._selectProductIdDialog = null;
    this._ProductIdItemSelector = null;
    this._ProductIdSelectedKeys = null;
    this._ProductIdSelectedItems = null;
    this._ProductIdBinderBound = false;
    this._doneSelectingProductIdDelegate = null;
    this._cancelProductIdDelegate = null;
    this._ProductIdItemSelectorCloseDelegate = null;
    
    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer.FeaturesWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer.FeaturesWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer.FeaturesWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize ProductId */
        if (this._selectButtonProductId) {
            this._selectButtonProductIdClickDelegate = Function.createDelegate(this, this._selectButtonProductIdClicked);
            $addHandler(this._selectButtonProductId, "click", this._selectButtonProductIdClickDelegate);
        }
        
        if (this._deselectButtonProductId) {
            this._deselectButtonProductIdClickDelegate = Function.createDelegate(this, this._deselectButtonProductIdClicked);
            $addHandler(this._deselectButtonProductId, "click", this._deselectButtonProductIdClickDelegate);
        }

        if (this._lnkDoneProductId) {
            this._ProductIdDoneSelectingDelegate = Function.createDelegate(this, this._ProductIdDoneSelecting);
            $addHandler(this._lnkDoneProductId, "click", this._ProductIdDoneSelectingDelegate);
        }

        if (this._lnkCancelProductId) {
            this._ProductIdCancelDelegate = Function.createDelegate(this, this._ProductIdItemSelectorCloseHandler);
            $addHandler(this._lnkCancelProductId, "click", this._ProductIdCancelDelegate);
        }

        this._selectProductIdDialog = jQuery("#ProductIdSelector").dialog({
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
        SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer.FeaturesWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose ProductId */
        
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI ProductId */
        this.get_selectedProductId().innerHTML = controlData.ProductId;
        if (controlData.ProductId && controlData.ProductId != "00000000-0000-0000-0000-000000000000") {
            this.get_selectButtonProductId().innerHTML = '<span class=\"sfLinkBtnIn\">Change</span>';
            $(this.get_deselectButtonProductId()).show()
        }
        else {
            $(this.get_deselectButtonProductId()).hide()
        }
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges ProductId */
        controlData.ProductId = this.get_selectedProductId().innerHTML;
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* ProductId event handlers */


    /* --------------------------------- private methods --------------------------------- */

    /* ProductId private methods */
    _selectButtonProductIdClicked: function (sender, args) {
        var itemSelector = this.get_ProductIdItemSelector();
        if (itemSelector) {
            // dynamic items don't support fallback, the binder search should work as in monolingual 
            itemSelector._selectorSearchBox.get_binderSearch()._multilingual = false;
            itemSelector.dataBind();
        }

        this._selectProductIdDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._selectProductIdDialog.dialog().parent().css("min-width", "525px");
        dialogBase.resizeToContent();
        return false;
    },
    
    _deselectButtonProductIdClicked: function (sender, args) {
        this.get_selectedProductId().innerHTML = "00000000-0000-0000-0000-000000000000";
        this.get_selectButtonProductId().innerHTML = '<span class=\"sfLinkBtnIn\">Select...</span>';
        $(this.get_deselectButtonProductId()).hide()
        return false;
    },

    _ProductIdItemSelectorCloseHandler: function (sender, args) {
        this._selectProductIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    _ProductIdDoneSelecting: function (sender, args) {
        var selectedItem = this.get_ProductIdSelectedItems()[0];
        if (selectedItem != null) {
            this.get_selectedProductId().innerHTML = selectedItem.OriginalContentId;
            this.get_selectButtonProductId().innerHTML = '<span class=\"sfLinkBtnIn\">Change</span>';
            $(this.get_deselectButtonProductId()).show()
        }
        this._selectProductIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    /* --------------------------------- properties -------------------------------------- */

    /* ProductId properties */
    get_selectButtonProductId: function () {
        return this._selectButtonProductId;
    },
    set_selectButtonProductId: function (value) {
        this._selectButtonProductId = value;
    },
    
    get_deselectButtonProductId: function () {
        return this._deselectButtonProductId;
    },
    set_deselectButtonProductId: function (value) {
        this._deselectButtonProductId = value;
    },

    get_ProductIdItemSelector: function () {
        return this._ProductIdItemSelector;
    },
    set_ProductIdItemSelector: function (value) {
        this._ProductIdItemSelector = value;
    },

    get_ProductIdBinder: function () {
        return this._ProductIdItemSelector.get_binder();
    },

    get_ProductIdSelectedKeys: function () {
        return this._ProductIdItemSelector.get_selectedKeys();
    },
    set_ProductIdSelectedKeys: function (keys) {
        this._selectedKeys = keys;
    },

    get_ProductIdSelectedItems: function () {
        return this._ProductIdItemSelector.getSelectedItems();
    },
    set_ProductIdSelectedItems: function (items) {
        this._ProductIdSelectedItems = items;
        if (this._ProductIdBinderBound) {
            this._ProductIdItemSelector.bindSelector();
        }
    },

    get_lnkDoneProductId: function () {
        return this._lnkDoneProductId;
    },
    set_lnkDoneProductId: function (value) {
        this._lnkDoneProductId = value;
    },
    get_lnkCancelProductId: function () {
        return this._lnkCancelProductId;
    },
    set_lnkCancelProductId: function (value) {
        this._lnkCancelProductId = value;
    },
    get_selectedProductId: function () {
        if (this._selectedProductIdLabel == null) {
            this._selectedProductIdLabel = jQuery(this.get_element()).find('#selectedProductIdLabel').get(0);
        }
        return this._selectedProductIdLabel;
    }
}

SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer.FeaturesWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.FeaturesWidget.Designer.FeaturesWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
