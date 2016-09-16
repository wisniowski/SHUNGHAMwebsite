Type.registerNamespace("SitefinityWebApp.CustomWidgets.FooterWidget.Designer");

SitefinityWebApp.CustomWidgets.FooterWidget.Designer.FooterWidgetDesigner = function (element) {
    /* Initialize WhoWeArePageIds fields */
    this._pageSelectorWhoWeArePageIds = null;
    this._selectorTagWhoWeArePageIds = null;
    this._WhoWeArePageIdsDialog = null;
 
    this._showPageSelectorWhoWeArePageIdsDelegate = null;
    this._pageSelectedWhoWeArePageIdsDelegate = null;
    
    /* Initialize LinkedInButtonExternalLink fields */
    this._linkedInButtonExternalLink = null;
    
    /* Initialize TwitterButtonExternalLink fields */
    this._twitterButtonExternalLink = null;
    
    /* Initialize FacebookButtonExternalLink fields */
    this._facebookButtonExternalLink = null;
    
    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.FooterWidget.Designer.FooterWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.FooterWidget.Designer.FooterWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.FooterWidget.Designer.FooterWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize WhoWeArePageIds */
        this._showPageSelectorWhoWeArePageIdsDelegate = Function.createDelegate(this, this._showPageSelectorWhoWeArePageIdsHandler);
        $addHandler(this.get_pageSelectButtonWhoWeArePageIds(), "click", this._showPageSelectorWhoWeArePageIdsDelegate);

        this._pageSelectedWhoWeArePageIdsDelegate = Function.createDelegate(this, this._pageSelectedWhoWeArePageIdsHandler);
        this.get_pageSelectorWhoWeArePageIds().add_doneClientSelection(this._pageSelectedWhoWeArePageIdsDelegate);

        if (this._selectorTagWhoWeArePageIds) {
            this._WhoWeArePageIdsDialog = jQuery(this._selectorTagWhoWeArePageIds).dialog({
                autoOpen: false,
                modal: false,
                closeOnEscape: true,
                resizable: false,
                draggable: false,
                zIndex: 5000
            });
        }
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.CustomWidgets.FooterWidget.Designer.FooterWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose WhoWeArePageIds */
        if (this._showPageSelectorWhoWeArePageIdsDelegate) {
            $removeHandler(this.get_pageSelectButtonWhoWeArePageIds(), "click", this._showPageSelectorWhoWeArePageIdsDelegate);
            delete this._showPageSelectorWhoWeArePageIdsDelegate;
        }

        if (this._pageSelectedWhoWeArePageIdsDelegate) {
            this.get_pageSelectorWhoWeArePageIds().remove_doneClientSelection(this._pageSelectedWhoWeArePageIdsDelegate);
            delete this._pageSelectedWhoWeArePageIdsDelegate;
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

        /* RefreshUI WhoWeArePageIds */
        if (controlData.WhoWeArePagesValue && controlData.WhoWeArePagesValue !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorWhoWeArePageIds = this.get_pageSelectorWhoWeArePageIds().get_pageSelector();
            var selectedPageLabelWhoWeArePageIds = this.get_selectedWhoWeArePageIdsLabel();
            var selectedPageButtonWhoWeArePageIds = this.get_pageSelectButtonWhoWeArePageIds();
            pagesSelectorWhoWeArePageIds.add_selectionApplied(function (o, args) {
                var selectedPages = pagesSelectorWhoWeArePageIds.get_selectedItems();
                if (selectedPages) {
                    selectedPageLabelWhoWeArePageIds.innerHTML = selectedPages.map(function (a) { return a.Title.Value; }).join();
                    jQuery(selectedPageLabelWhoWeArePageIds).show();
                    selectedPageButtonWhoWeArePageIds.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorWhoWeArePageIds.set_selectedItemIds(controlData.WhoWeArePagesValue.split(","));
        }        

        /* RefreshUI LinkedInButtonExternalLink */
        jQuery(this.get_linkedInButtonExternalLink()).val(controlData.LinkedInButtonExternalLink);

        /* RefreshUI TwitterButtonExternalLink */
        jQuery(this.get_twitterButtonExternalLink()).val(controlData.TwitterButtonExternalLink);

        /* RefreshUI FacebookButtonExternalLink */
        jQuery(this.get_facebookButtonExternalLink()).val(controlData.FacebookButtonExternalLink);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges WhoWeArePageIds */

        /* ApplyChanges LinkedInButtonExternalLink */
        controlData.LinkedInButtonExternalLink = jQuery(this.get_linkedInButtonExternalLink()).val();

        /* ApplyChanges TwitterButtonExternalLink */
        controlData.TwitterButtonExternalLink = jQuery(this.get_twitterButtonExternalLink()).val();

        /* ApplyChanges FacebookButtonExternalLink */
        controlData.FacebookButtonExternalLink = jQuery(this.get_facebookButtonExternalLink()).val();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* WhoWeArePageIds private methods */
    _showPageSelectorWhoWeArePageIdsHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorWhoWeArePageIds().get_pageSelector();

        if (controlData.WhoWeArePagesValue != null) {
            pagesSelector.set_selectedItems(controlData.WhoWeArePagesValue.split(","));
        }

        this._WhoWeArePageIdsDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._WhoWeArePageIdsDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedWhoWeArePageIdsHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorWhoWeArePageIds().get_pageSelector();
        this._WhoWeArePageIdsDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPages = pagesSelector.get_selectedItems();
        if (selectedPages) {
            this.get_selectedWhoWeArePageIdsLabel().innerHTML = selectedPages.map(function (a) { return a.Title.Value; });
            jQuery(this.get_selectedWhoWeArePageIdsLabel()).show();
            this.get_pageSelectButtonWhoWeArePageIds().innerHTML = '<span>Change</span>';
            controlData.WhoWeArePagesValue = selectedPages.map(function (a) { return a.Id; }).join();
        }
        else {
            jQuery(this.get_selectedWhoWeArePageIdsLabel()).hide();
            this.get_pageSelectButtonWhoWeArePageIds().innerHTML = '<span>Select...</span>';
            controlData.WhoWeArePagesValue = "00000000-0000-0000-0000-000000000000";
        }
    },

    /* --------------------------------- properties -------------------------------------- */

    /* WhoWeArePageIds properties */
    get_pageSelectButtonWhoWeArePageIds: function () {
        if (this._pageSelectButtonWhoWeArePageIds == null) {
            this._pageSelectButtonWhoWeArePageIds = this.findElement("pageSelectButtonWhoWeArePageIds");
        }
        return this._pageSelectButtonWhoWeArePageIds;
    },
    get_selectedWhoWeArePageIdsLabel: function () {
        if (this._selectedWhoWeArePageIdsLabel == null) {
            this._selectedWhoWeArePageIdsLabel = this.findElement("selectedWhoWeArePageIdsLabel");
        }
        return this._selectedWhoWeArePageIdsLabel;
    },
    get_pageSelectorWhoWeArePageIds: function () {
        return this._pageSelectorWhoWeArePageIds;
    },
    set_pageSelectorWhoWeArePageIds: function (val) {
        this._pageSelectorWhoWeArePageIds = val;
    },
    get_selectorTagWhoWeArePageIds: function () {
        return this._selectorTagWhoWeArePageIds;
    },
    set_selectorTagWhoWeArePageIds: function (value) {
        this._selectorTagWhoWeArePageIds = value;
    },

    /* LinkedInButtonExternalLink properties */
    get_linkedInButtonExternalLink: function () { return this._linkedInButtonExternalLink; }, 
    set_linkedInButtonExternalLink: function (value) { this._linkedInButtonExternalLink = value; },

    /* TwitterButtonExternalLink properties */
    get_twitterButtonExternalLink: function () { return this._twitterButtonExternalLink; }, 
    set_twitterButtonExternalLink: function (value) { this._twitterButtonExternalLink = value; },

    /* FacebookButtonExternalLink properties */
    get_facebookButtonExternalLink: function () { return this._facebookButtonExternalLink; }, 
    set_facebookButtonExternalLink: function (value) { this._facebookButtonExternalLink = value; }
}

SitefinityWebApp.CustomWidgets.FooterWidget.Designer.FooterWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.FooterWidget.Designer.FooterWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
