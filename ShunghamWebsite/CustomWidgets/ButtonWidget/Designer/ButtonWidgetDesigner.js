Type.registerNamespace("SitefinityWebApp.CustomWidgets.ButtonWidget.Designer");

SitefinityWebApp.CustomWidgets.ButtonWidget.Designer.ButtonWidgetDesigner = function (element) {
    /* Initialize Text fields */
    this._text = null;
    
    /* Initialize LandingPageId fields */
    this._pageSelectorLandingPageId = null;
    this._selectorTagLandingPageId = null;
    this._LandingPageIdDialog = null;
 
    this._showPageSelectorLandingPageIdDelegate = null;
    this._pageSelectedLandingPageIdDelegate = null;
    
    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.ButtonWidget.Designer.ButtonWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.ButtonWidget.Designer.ButtonWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.ButtonWidget.Designer.ButtonWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize LandingPageId */
        this._showPageSelectorLandingPageIdDelegate = Function.createDelegate(this, this._showPageSelectorLandingPageIdHandler);
        $addHandler(this.get_pageSelectButtonLandingPageId(), "click", this._showPageSelectorLandingPageIdDelegate);

        this._pageSelectedLandingPageIdDelegate = Function.createDelegate(this, this._pageSelectedLandingPageIdHandler);
        this.get_pageSelectorLandingPageId().add_doneClientSelection(this._pageSelectedLandingPageIdDelegate);

        if (this._selectorTagLandingPageId) {
            this._LandingPageIdDialog = jQuery(this._selectorTagLandingPageId).dialog({
                autoOpen: false,
                modal: false,
                width: 395,
                closeOnEscape: true,
                resizable: false,
                draggable: false,
                zIndex: 5000
            });
        }
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.CustomWidgets.ButtonWidget.Designer.ButtonWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose LandingPageId */
        if (this._showPageSelectorLandingPageIdDelegate) {
            $removeHandler(this.get_pageSelectButtonLandingPageId(), "click", this._showPageSelectorLandingPageIdDelegate);
            delete this._showPageSelectorLandingPageIdDelegate;
        }

        if (this._pageSelectedLandingPageIdDelegate) {
            this.get_pageSelectorLandingPageId().remove_doneClientSelection(this._pageSelectedLandingPageIdDelegate);
            delete this._pageSelectedLandingPageIdDelegate;
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

        /* RefreshUI Text */
        jQuery(this.get_text()).val(controlData.Text);

        /* RefreshUI LandingPageId */
        if (controlData.LandingPageId && controlData.LandingPageId !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorLandingPageId = this.get_pageSelectorLandingPageId().get_pageSelector();
            var selectedPageLabelLandingPageId = this.get_selectedLandingPageIdLabel();
            var selectedPageButtonLandingPageId = this.get_pageSelectButtonLandingPageId();
            pagesSelectorLandingPageId.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorLandingPageId.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelLandingPageId.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelLandingPageId).show();
                    selectedPageButtonLandingPageId.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorLandingPageId.set_selectedItems([{ Id: controlData.LandingPageId}]);
        }
        else if (controlData.ExternalLink && controlData.LandingPageId !== "") {
            var externalPagesSelector = this.get_pageSelectorLandingPageId().get_extPagesSelector();
            var selectedPageLabelLandingPageId = this.get_selectedLandingPageIdLabel();
            var selectedPageButtonLandingPageId = this.get_pageSelectButtonLandingPageId();

            selectedPageLabelLandingPageId.innerHTML = controlData.ExternalLink;
            jQuery(selectedPageLabelLandingPageId).show();
            selectedPageButtonLandingPageId.innerHTML = '<span>Change</span>';
        }
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges Text */
        controlData.Text = jQuery(this.get_text()).val();

        /* ApplyChanges LandingPageId */
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* LandingPageId private methods */
    _showPageSelectorLandingPageIdHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorLandingPageId().get_pageSelector();
        var externalPagesSelector = this.get_pageSelectorLandingPageId().get_extPagesSelector();
        if (controlData.LandingPageId) {
            pagesSelector.set_selectedItems([{ Id: controlData.LandingPageId }]);
        }
        if (controlData.ExternalLink) {
            externalPagesSelector.get_urlTextBox().set_value(controlData.ExternalLink);
        }
        this._LandingPageIdDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        jQuery(".sfTxtUrlSeletor").hide();
        this._LandingPageIdDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedLandingPageIdHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorLandingPageId().get_pageSelector();
        this._LandingPageIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }

        var selectedPage = pagesSelector.get_selectedItem();
        var externalPagesSelector = this.get_pageSelectorLandingPageId().get_extPagesSelector();
        var externalUrl = externalPagesSelector.get_urlTextBox().get_value();

        if (selectedPage) {
            this.get_selectedLandingPageIdLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedLandingPageIdLabel()).show();
            this.get_pageSelectButtonLandingPageId().innerHTML = '<span>Change</span>';
            controlData.LandingPageId = selectedPage.Id;
            controlData.ExternalLink = "";
            externalPagesSelector.get_urlTextBox().set_value("");
        }
        else if (externalUrl && (externalUrl != "")) {
            controlData.ExternalLink = externalUrl;
            this.get_selectedLandingPageIdLabel().innerHTML = externalUrl;

            jQuery(this.get_selectedLandingPageIdLabel()).show();
            this.get_pageSelectButtonLandingPageId().innerHTML = '<span>Change</span>';
            controlData.LandingPageId = "00000000-0000-0000-0000-000000000000";
        }
        else {
            jQuery(this.get_selectedLandingPageIdLabel()).hide();
            this.get_pageSelectButtonLandingPageId().innerHTML = '<span>Select...</span>';
            controlData.LandingPageId = "00000000-0000-0000-0000-000000000000";
            controlData.ExternalLink = "";
        }
    },

    /* --------------------------------- properties -------------------------------------- */

    /* Text properties */
    get_text: function () { return this._text; }, 
    set_text: function (value) { this._text = value; },

    /* LandingPageId properties */
    get_pageSelectButtonLandingPageId: function () {
        if (this._pageSelectButtonLandingPageId == null) {
            this._pageSelectButtonLandingPageId = this.findElement("pageSelectButtonLandingPageId");
        }
        return this._pageSelectButtonLandingPageId;
    },
    get_selectedLandingPageIdLabel: function () {
        if (this._selectedLandingPageIdLabel == null) {
            this._selectedLandingPageIdLabel = this.findElement("selectedLandingPageIdLabel");
        }
        return this._selectedLandingPageIdLabel;
    },
    get_pageSelectorLandingPageId: function () {
        return this._pageSelectorLandingPageId;
    },
    set_pageSelectorLandingPageId: function (val) {
        this._pageSelectorLandingPageId = val;
    },
    get_selectorTagLandingPageId: function () {
        return this._selectorTagLandingPageId;
    },
    set_selectorTagLandingPageId: function (value) {
        this._selectorTagLandingPageId = value;
    }
}

SitefinityWebApp.CustomWidgets.ButtonWidget.Designer.ButtonWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.ButtonWidget.Designer.ButtonWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
