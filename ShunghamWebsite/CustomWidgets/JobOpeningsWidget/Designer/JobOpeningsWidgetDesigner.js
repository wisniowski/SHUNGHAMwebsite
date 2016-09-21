Type.registerNamespace("SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer");

SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer.JobOpeningsWidgetDesigner = function (element) {
    /* Initialize ApplyNowLandingPage fields */
    this._pageSelectorApplyNowLandingPage = null;
    this._selectorTagApplyNowLandingPage = null;
    this._ApplyNowLandingPageDialog = null;
 
    this._showPageSelectorApplyNowLandingPageDelegate = null;
    this._pageSelectedApplyNowLandingPageDelegate = null;
    
    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer.JobOpeningsWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer.JobOpeningsWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer.JobOpeningsWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize ApplyNowLandingPage */
        this._showPageSelectorApplyNowLandingPageDelegate = Function.createDelegate(this, this._showPageSelectorApplyNowLandingPageHandler);
        $addHandler(this.get_pageSelectButtonApplyNowLandingPage(), "click", this._showPageSelectorApplyNowLandingPageDelegate);

        this._pageSelectedApplyNowLandingPageDelegate = Function.createDelegate(this, this._pageSelectedApplyNowLandingPageHandler);
        this.get_pageSelectorApplyNowLandingPage().add_doneClientSelection(this._pageSelectedApplyNowLandingPageDelegate);

        if (this._selectorTagApplyNowLandingPage) {
            this._ApplyNowLandingPageDialog = jQuery(this._selectorTagApplyNowLandingPage).dialog({
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
        SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer.JobOpeningsWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose ApplyNowLandingPage */
        if (this._showPageSelectorApplyNowLandingPageDelegate) {
            $removeHandler(this.get_pageSelectButtonApplyNowLandingPage(), "click", this._showPageSelectorApplyNowLandingPageDelegate);
            delete this._showPageSelectorApplyNowLandingPageDelegate;
        }

        if (this._pageSelectedApplyNowLandingPageDelegate) {
            this.get_pageSelectorApplyNowLandingPage().remove_doneClientSelection(this._pageSelectedApplyNowLandingPageDelegate);
            delete this._pageSelectedApplyNowLandingPageDelegate;
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

        /* RefreshUI ApplyNowLandingPage */
        if (controlData.ApplyNowLandingPage && controlData.ApplyNowLandingPage !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorApplyNowLandingPage = this.get_pageSelectorApplyNowLandingPage().get_pageSelector();
            var selectedPageLabelApplyNowLandingPage = this.get_selectedApplyNowLandingPageLabel();
            var selectedPageButtonApplyNowLandingPage = this.get_pageSelectButtonApplyNowLandingPage();
            pagesSelectorApplyNowLandingPage.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorApplyNowLandingPage.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelApplyNowLandingPage.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelApplyNowLandingPage).show();
                    selectedPageButtonApplyNowLandingPage.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorApplyNowLandingPage.set_selectedItems([{ Id: controlData.ApplyNowLandingPage}]);
        }        
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges ApplyNowLandingPage */
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* ApplyNowLandingPage private methods */
    _showPageSelectorApplyNowLandingPageHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorApplyNowLandingPage().get_pageSelector();
        if (controlData.ApplyNowLandingPage) {
            pagesSelector.set_selectedItems([{ Id: controlData.ApplyNowLandingPage }]);
        }
        this._ApplyNowLandingPageDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._ApplyNowLandingPageDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedApplyNowLandingPageHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorApplyNowLandingPage().get_pageSelector();
        this._ApplyNowLandingPageDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPage = pagesSelector.get_selectedItem();
        if (selectedPage) {
            this.get_selectedApplyNowLandingPageLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedApplyNowLandingPageLabel()).show();
            this.get_pageSelectButtonApplyNowLandingPage().innerHTML = '<span>Change</span>';
            controlData.ApplyNowLandingPage = selectedPage.Id;
        }
        else {
            jQuery(this.get_selectedApplyNowLandingPageLabel()).hide();
            this.get_pageSelectButtonApplyNowLandingPage().innerHTML = '<span>Select...</span>';
            controlData.ApplyNowLandingPage = "00000000-0000-0000-0000-000000000000";
        }
    },

    /* --------------------------------- properties -------------------------------------- */

    /* ApplyNowLandingPage properties */
    get_pageSelectButtonApplyNowLandingPage: function () {
        if (this._pageSelectButtonApplyNowLandingPage == null) {
            this._pageSelectButtonApplyNowLandingPage = this.findElement("pageSelectButtonApplyNowLandingPage");
        }
        return this._pageSelectButtonApplyNowLandingPage;
    },
    get_selectedApplyNowLandingPageLabel: function () {
        if (this._selectedApplyNowLandingPageLabel == null) {
            this._selectedApplyNowLandingPageLabel = this.findElement("selectedApplyNowLandingPageLabel");
        }
        return this._selectedApplyNowLandingPageLabel;
    },
    get_pageSelectorApplyNowLandingPage: function () {
        return this._pageSelectorApplyNowLandingPage;
    },
    set_pageSelectorApplyNowLandingPage: function (val) {
        this._pageSelectorApplyNowLandingPage = val;
    },
    get_selectorTagApplyNowLandingPage: function () {
        return this._selectorTagApplyNowLandingPage;
    },
    set_selectorTagApplyNowLandingPage: function (value) {
        this._selectorTagApplyNowLandingPage = value;
    }
}

SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer.JobOpeningsWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.JobOpeningsWidget.Designer.JobOpeningsWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
