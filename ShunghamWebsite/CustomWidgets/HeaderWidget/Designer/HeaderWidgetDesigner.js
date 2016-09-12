Type.registerNamespace("SitefinityWebApp.CustomWidgets.HeaderWidget.Designer");

SitefinityWebApp.CustomWidgets.HeaderWidget.Designer.HeaderWidgetDesigner = function (element) {
    /* Initialize LogInButtonLandingPage fields */
    this._pageSelectorLogInButtonLandingPage = null;
    this._selectorTagLogInButtonLandingPage = null;
    this._LogInButtonLandingPageDialog = null;

    this._showPageSelectorLogInButtonLandingPageDelegate = null;
    this._pageSelectedLogInButtonLandingPageDelegate = null;

    /* Initialize TrialButtonLandingPage fields */
    this._pageSelectorTrialButtonLandingPage = null;
    this._selectorTagTrialButtonLandingPage = null;
    this._TrialButtonLandingPageDialog = null;

    this._showPageSelectorTrialButtonLandingPageDelegate = null;
    this._pageSelectedTrialButtonLandingPageDelegate = null;

    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.HeaderWidget.Designer.HeaderWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.HeaderWidget.Designer.HeaderWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.HeaderWidget.Designer.HeaderWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize LogInButtonLandingPage */
        this._showPageSelectorLogInButtonLandingPageDelegate = Function.createDelegate(this, this._showPageSelectorLogInButtonLandingPageHandler);
        $addHandler(this.get_pageSelectButtonLogInButtonLandingPage(), "click", this._showPageSelectorLogInButtonLandingPageDelegate);

        this._pageSelectedLogInButtonLandingPageDelegate = Function.createDelegate(this, this._pageSelectedLogInButtonLandingPageHandler);
        this.get_pageSelectorLogInButtonLandingPage().add_doneClientSelection(this._pageSelectedLogInButtonLandingPageDelegate);

        if (this._selectorTagLogInButtonLandingPage) {
            this._LogInButtonLandingPageDialog = jQuery(this._selectorTagLogInButtonLandingPage).dialog({
                autoOpen: false,
                modal: false,
                width: 395,
                closeOnEscape: true,
                resizable: false,
                draggable: false,
                zIndex: 5000
            });
        }

        /* Initialize TrialButtonLandingPage */
        this._showPageSelectorTrialButtonLandingPageDelegate = Function.createDelegate(this, this._showPageSelectorTrialButtonLandingPageHandler);
        $addHandler(this.get_pageSelectButtonTrialButtonLandingPage(), "click", this._showPageSelectorTrialButtonLandingPageDelegate);

        this._pageSelectedTrialButtonLandingPageDelegate = Function.createDelegate(this, this._pageSelectedTrialButtonLandingPageHandler);
        this.get_pageSelectorTrialButtonLandingPage().add_doneClientSelection(this._pageSelectedTrialButtonLandingPageDelegate);

        if (this._selectorTagTrialButtonLandingPage) {
            this._TrialButtonLandingPageDialog = jQuery(this._selectorTagTrialButtonLandingPage).dialog({
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
        SitefinityWebApp.CustomWidgets.HeaderWidget.Designer.HeaderWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose LogInButtonLandingPage */
        if (this._showPageSelectorLogInButtonLandingPageDelegate) {
            $removeHandler(this.get_pageSelectButtonLogInButtonLandingPage(), "click", this._showPageSelectorLogInButtonLandingPageDelegate);
            delete this._showPageSelectorLogInButtonLandingPageDelegate;
        }

        if (this._pageSelectedLogInButtonLandingPageDelegate) {
            this.get_pageSelectorLogInButtonLandingPage().remove_doneClientSelection(this._pageSelectedLogInButtonLandingPageDelegate);
            delete this._pageSelectedLogInButtonLandingPageDelegate;
        }

        /* Dispose TrialButtonLandingPage */
        if (this._showPageSelectorTrialButtonLandingPageDelegate) {
            $removeHandler(this.get_pageSelectButtonTrialButtonLandingPage(), "click", this._showPageSelectorTrialButtonLandingPageDelegate);
            delete this._showPageSelectorTrialButtonLandingPageDelegate;
        }

        if (this._pageSelectedTrialButtonLandingPageDelegate) {
            this.get_pageSelectorTrialButtonLandingPage().remove_doneClientSelection(this._pageSelectedTrialButtonLandingPageDelegate);
            delete this._pageSelectedTrialButtonLandingPageDelegate;
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

        /* RefreshUI LogInButtonLandingPage */
        if (controlData.LogInButtonLandingPage && controlData.LogInButtonLandingPage !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorLogInButtonLandingPage = this.get_pageSelectorLogInButtonLandingPage().get_pageSelector();
            var selectedPageLabelLogInButtonLandingPage = this.get_selectedLogInButtonLandingPageLabel();
            var selectedPageButtonLogInButtonLandingPage = this.get_pageSelectButtonLogInButtonLandingPage();
            pagesSelectorLogInButtonLandingPage.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorLogInButtonLandingPage.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelLogInButtonLandingPage.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelLogInButtonLandingPage).show();
                    selectedPageButtonLogInButtonLandingPage.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorLogInButtonLandingPage.set_selectedItems([{ Id: controlData.LogInButtonLandingPage }]);
        }
        else if (controlData.LogInButtonExternalLink && controlData.LogInButtonLandingPage !== "") {
            var externalPagesSelector = this.get_pageSelectorLogInButtonLandingPage().get_extPagesSelector();
            var selectedPageLabelLogInButtonLandingPage = this.get_selectedLogInButtonLandingPageLabel();
            var selectedPageButtonLogInButtonLandingPage = this.get_pageSelectButtonLogInButtonLandingPage();

            selectedPageLabelLogInButtonLandingPage.innerHTML = controlData.LogInButtonExternalLink;
            jQuery(selectedPageLabelLogInButtonLandingPage).show();
            selectedPageButtonLogInButtonLandingPage.innerHTML = '<span>Change</span>';
        }

        /* RefreshUI TrialButtonLandingPage */
        if (controlData.TrialButtonLandingPage && controlData.TrialButtonLandingPage !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorTrialButtonLandingPage = this.get_pageSelectorTrialButtonLandingPage().get_pageSelector();
            var selectedPageLabelTrialButtonLandingPage = this.get_selectedTrialButtonLandingPageLabel();
            var selectedPageButtonTrialButtonLandingPage = this.get_pageSelectButtonTrialButtonLandingPage();
            pagesSelectorTrialButtonLandingPage.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorTrialButtonLandingPage.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelTrialButtonLandingPage.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelTrialButtonLandingPage).show();
                    selectedPageButtonTrialButtonLandingPage.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorTrialButtonLandingPage.set_selectedItems([{ Id: controlData.TrialButtonLandingPage }]);
        }
        else if (controlData.TrialButtonExternalLink && controlData.TrialButtonLandingPage !== "") {
            var externalPagesSelector = this.get_pageSelectorTrialButtonLandingPage().get_extPagesSelector();
            var selectedPageLabelTrialButtonLandingPage = this.get_selectedTrialButtonLandingPageLabel();
            var selectedPageButtonTrialButtonLandingPage = this.get_pageSelectButtonTrialButtonLandingPage();

            selectedPageLabelTrialButtonLandingPage.innerHTML = controlData.TrialButtonExternalLink;
            jQuery(selectedPageLabelTrialButtonLandingPage).show();
            selectedPageButtonTrialButtonLandingPage.innerHTML = '<span>Change</span>';
        }
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges LogInButtonLandingPage */

        /* ApplyChanges TrialButtonLandingPage */
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* LogInButtonLandingPage private methods */
    _showPageSelectorLogInButtonLandingPageHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorLogInButtonLandingPage().get_pageSelector();
        var externalPagesSelector = this.get_pageSelectorLogInButtonLandingPage().get_extPagesSelector();
        if (controlData.LogInButtonLandingPage) {
            pagesSelector.set_selectedItems([{ Id: controlData.LogInButtonLandingPage }]);
        }
        if (controlData.LogInButtonExternalLink) {
            externalPagesSelector.get_urlTextBox().set_value(controlData.LogInButtonExternalLink);
        }
        this._LogInButtonLandingPageDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        jQuery(".sfTxtUrlSeletor").hide();
        this._LogInButtonLandingPageDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedLogInButtonLandingPageHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorLogInButtonLandingPage().get_pageSelector();
        this._LogInButtonLandingPageDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPage = pagesSelector.get_selectedItem();
        var externalPagesSelector = this.get_pageSelectorLogInButtonLandingPage().get_extPagesSelector();

        if (selectedPage) {
            this.get_selectedLogInButtonLandingPageLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedLogInButtonLandingPageLabel()).show();
            this.get_pageSelectButtonLogInButtonLandingPage().innerHTML = '<span>Change</span>';
            controlData.LogInButtonLandingPage = selectedPage.Id;
            controlData.LogInButtonExternalLink = "";
            externalPagesSelector.get_urlTextBox().set_value("");
        }

        var externalUrl = externalPagesSelector.get_urlTextBox().get_value();

        if (externalUrl && (externalUrl != "")) {
            controlData.LogInButtonExternalLink = externalUrl;
            this.get_selectedLogInButtonLandingPageLabel().innerHTML = externalUrl;

            jQuery(this.get_selectedLogInButtonLandingPageLabel()).show();
            this.get_pageSelectButtonLogInButtonLandingPage().innerHTML = '<span>Change</span>';
            controlData.LogInButtonLandingPage = "00000000-0000-0000-0000-000000000000";
        }
        if (!selectedPage && !externalUrl) {
            jQuery(this.get_selectedLogInButtonLandingPageLabel()).hide();
            this.get_pageSelectButtonLogInButtonLandingPage().innerHTML = '<span>Select...</span>';
            controlData.LogInButtonLandingPage = "00000000-0000-0000-0000-000000000000";
            controlData.LogInButtonExternalLink = "";
        }
    },

    /* TrialButtonLandingPage private methods */
    _showPageSelectorTrialButtonLandingPageHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorTrialButtonLandingPage().get_pageSelector();
        var externalPagesSelector = this.get_pageSelectorTrialButtonLandingPage().get_extPagesSelector();
        if (controlData.TrialButtonLandingPage) {
            pagesSelector.set_selectedItems([{ Id: controlData.TrialButtonLandingPage }]);
        }
        if (controlData.TrialButtonExternalLink) {
            externalPagesSelector.get_urlTextBox().set_value(controlData.TrialButtonExternalLink);
        }
        this._TrialButtonLandingPageDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._TrialButtonLandingPageDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedTrialButtonLandingPageHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorTrialButtonLandingPage().get_pageSelector();
        this._TrialButtonLandingPageDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPage = pagesSelector.get_selectedItem();
        var externalPagesSelector = this.get_pageSelectorTrialButtonLandingPage().get_extPagesSelector();
        if (selectedPage) {
            this.get_selectedTrialButtonLandingPageLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedTrialButtonLandingPageLabel()).show();
            this.get_pageSelectButtonTrialButtonLandingPage().innerHTML = '<span>Change</span>';
            controlData.TrialButtonLandingPage = selectedPage.Id;
            controlData.TrialButtonExternalLink = "";
            externalPagesSelector.get_urlTextBox().set_value("");
        }

        var externalUrl = externalPagesSelector.get_urlTextBox().get_value();

        if (externalUrl && (externalUrl != "")) {
            controlData.TrialButtonExternalLink = externalUrl;
            this.get_selectedTrialButtonLandingPageLabel().innerHTML = externalUrl;

            jQuery(this.get_selectedTrialButtonLandingPageLabel()).show();
            this.get_pageSelectButtonTrialButtonLandingPage().innerHTML = '<span>Change</span>';
            controlData.TrialButtonLandingPage = "00000000-0000-0000-0000-000000000000";
        }
        if (!selectedPage && !externalUrl) {
            jQuery(this.get_selectedTrialButtonLandingPageLabel()).hide();
            this.get_pageSelectButtonTrialButtonLandingPage().innerHTML = '<span>Select...</span>';
            controlData.TrialButtonLandingPage = "00000000-0000-0000-0000-000000000000";
            controlData.TrialButtonExternalLink = "";
        }
    },

    /* --------------------------------- properties -------------------------------------- */

    /* LogInButtonLandingPage properties */
    get_pageSelectButtonLogInButtonLandingPage: function () {
        if (this._pageSelectButtonLogInButtonLandingPage == null) {
            this._pageSelectButtonLogInButtonLandingPage = this.findElement("pageSelectButtonLogInButtonLandingPage");
        }
        return this._pageSelectButtonLogInButtonLandingPage;
    },
    get_selectedLogInButtonLandingPageLabel: function () {
        if (this._selectedLogInButtonLandingPageLabel == null) {
            this._selectedLogInButtonLandingPageLabel = this.findElement("selectedLogInButtonLandingPageLabel");
        }
        return this._selectedLogInButtonLandingPageLabel;
    },
    get_pageSelectorLogInButtonLandingPage: function () {
        return this._pageSelectorLogInButtonLandingPage;
    },
    set_pageSelectorLogInButtonLandingPage: function (val) {
        this._pageSelectorLogInButtonLandingPage = val;
    },
    get_selectorTagLogInButtonLandingPage: function () {
        return this._selectorTagLogInButtonLandingPage;
    },
    set_selectorTagLogInButtonLandingPage: function (value) {
        this._selectorTagLogInButtonLandingPage = value;
    },

    /* TrialButtonLandingPage properties */
    get_pageSelectButtonTrialButtonLandingPage: function () {
        if (this._pageSelectButtonTrialButtonLandingPage == null) {
            this._pageSelectButtonTrialButtonLandingPage = this.findElement("pageSelectButtonTrialButtonLandingPage");
        }
        return this._pageSelectButtonTrialButtonLandingPage;
    },
    get_selectedTrialButtonLandingPageLabel: function () {
        if (this._selectedTrialButtonLandingPageLabel == null) {
            this._selectedTrialButtonLandingPageLabel = this.findElement("selectedTrialButtonLandingPageLabel");
        }
        return this._selectedTrialButtonLandingPageLabel;
    },
    get_pageSelectorTrialButtonLandingPage: function () {
        return this._pageSelectorTrialButtonLandingPage;
    },
    set_pageSelectorTrialButtonLandingPage: function (val) {
        this._pageSelectorTrialButtonLandingPage = val;
    },
    get_selectorTagTrialButtonLandingPage: function () {
        return this._selectorTagTrialButtonLandingPage;
    },
    set_selectorTagTrialButtonLandingPage: function (value) {
        this._selectorTagTrialButtonLandingPage = value;
    }
}

SitefinityWebApp.CustomWidgets.HeaderWidget.Designer.HeaderWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.HeaderWidget.Designer.HeaderWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
