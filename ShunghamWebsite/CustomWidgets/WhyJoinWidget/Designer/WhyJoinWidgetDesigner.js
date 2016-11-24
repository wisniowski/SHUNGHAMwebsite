Type.registerNamespace("SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer");

SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer.WhyJoinWidgetDesigner = function (element) {
    /* Initialize Title fields */
    this._title = null;
    
    /* Initialize Content fields */
    this._content = null;
    
    /* Initialize FirstButtonText fields */
    this._firstButtonText = null;
    
    /* Initialize FirstButtonLandingPage fields */
    this._pageSelectorFirstButtonLandingPage = null;
    this._selectorTagFirstButtonLandingPage = null;
    this._FirstButtonLandingPageDialog = null;
 
    this._showPageSelectorFirstButtonLandingPageDelegate = null;
    this._pageSelectedFirstButtonLandingPageDelegate = null;
    
    /* Initialize SecondButtonText fields */
    this._secondButtonText = null;
    
    /* Initialize SecondButtonLandingPage fields */
    this._pageSelectorSecondButtonLandingPage = null;
    this._selectorTagSecondButtonLandingPage = null;
    this._SecondButtonLandingPageDialog = null;
 
    this._showPageSelectorSecondButtonLandingPageDelegate = null;
    this._pageSelectedSecondButtonLandingPageDelegate = null;
    
    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer.WhyJoinWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer.WhyJoinWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer.WhyJoinWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize FirstButtonLandingPage */
        this._showPageSelectorFirstButtonLandingPageDelegate = Function.createDelegate(this, this._showPageSelectorFirstButtonLandingPageHandler);
        $addHandler(this.get_pageSelectButtonFirstButtonLandingPage(), "click", this._showPageSelectorFirstButtonLandingPageDelegate);

        this._pageSelectedFirstButtonLandingPageDelegate = Function.createDelegate(this, this._pageSelectedFirstButtonLandingPageHandler);
        this.get_pageSelectorFirstButtonLandingPage().add_doneClientSelection(this._pageSelectedFirstButtonLandingPageDelegate);

        if (this._selectorTagFirstButtonLandingPage) {
            this._FirstButtonLandingPageDialog = jQuery(this._selectorTagFirstButtonLandingPage).dialog({
                autoOpen: false,
                modal: false,
                width: 395,
                closeOnEscape: true,
                resizable: false,
                draggable: false,
                zIndex: 5000
            });
        }

        /* Initialize SecondButtonLandingPage */
        this._showPageSelectorSecondButtonLandingPageDelegate = Function.createDelegate(this, this._showPageSelectorSecondButtonLandingPageHandler);
        $addHandler(this.get_pageSelectButtonSecondButtonLandingPage(), "click", this._showPageSelectorSecondButtonLandingPageDelegate);

        this._pageSelectedSecondButtonLandingPageDelegate = Function.createDelegate(this, this._pageSelectedSecondButtonLandingPageHandler);
        this.get_pageSelectorSecondButtonLandingPage().add_doneClientSelection(this._pageSelectedSecondButtonLandingPageDelegate);

        if (this._selectorTagSecondButtonLandingPage) {
            this._SecondButtonLandingPageDialog = jQuery(this._selectorTagSecondButtonLandingPage).dialog({
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
        SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer.WhyJoinWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose FirstButtonLandingPage */
        if (this._showPageSelectorFirstButtonLandingPageDelegate) {
            $removeHandler(this.get_pageSelectButtonFirstButtonLandingPage(), "click", this._showPageSelectorFirstButtonLandingPageDelegate);
            delete this._showPageSelectorFirstButtonLandingPageDelegate;
        }

        if (this._pageSelectedFirstButtonLandingPageDelegate) {
            this.get_pageSelectorFirstButtonLandingPage().remove_doneClientSelection(this._pageSelectedFirstButtonLandingPageDelegate);
            delete this._pageSelectedFirstButtonLandingPageDelegate;
        }

        /* Dispose SecondButtonLandingPage */
        if (this._showPageSelectorSecondButtonLandingPageDelegate) {
            $removeHandler(this.get_pageSelectButtonSecondButtonLandingPage(), "click", this._showPageSelectorSecondButtonLandingPageDelegate);
            delete this._showPageSelectorSecondButtonLandingPageDelegate;
        }

        if (this._pageSelectedSecondButtonLandingPageDelegate) {
            this.get_pageSelectorSecondButtonLandingPage().remove_doneClientSelection(this._pageSelectedSecondButtonLandingPageDelegate);
            delete this._pageSelectedSecondButtonLandingPageDelegate;
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

        /* RefreshUI FirstButtonText */
        jQuery(this.get_firstButtonText()).val(controlData.FirstButtonText);

        /* RefreshUI FirstButtonLandingPage */
        if (controlData.FirstButtonLandingPage && controlData.FirstButtonLandingPage !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorFirstButtonLandingPage = this.get_pageSelectorFirstButtonLandingPage().get_pageSelector();
            var selectedPageLabelFirstButtonLandingPage = this.get_selectedFirstButtonLandingPageLabel();
            var selectedPageButtonFirstButtonLandingPage = this.get_pageSelectButtonFirstButtonLandingPage();
            pagesSelectorFirstButtonLandingPage.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorFirstButtonLandingPage.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelFirstButtonLandingPage.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelFirstButtonLandingPage).show();
                    selectedPageButtonFirstButtonLandingPage.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorFirstButtonLandingPage.set_selectedItems([{ Id: controlData.FirstButtonLandingPage}]);
        }

        /* RefreshUI FirstButtonBackground */
        jQuery("#FirstBtnBackgroundSelector").val(controlData.FirstButtonBackground);

        /* RefreshUI SecondButtonText */
        jQuery(this.get_secondButtonText()).val(controlData.SecondButtonText);

        /* RefreshUI SecondButtonLandingPage */
        if (controlData.SecondButtonLandingPage && controlData.SecondButtonLandingPage !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorSecondButtonLandingPage = this.get_pageSelectorSecondButtonLandingPage().get_pageSelector();
            var selectedPageLabelSecondButtonLandingPage = this.get_selectedSecondButtonLandingPageLabel();
            var selectedPageButtonSecondButtonLandingPage = this.get_pageSelectButtonSecondButtonLandingPage();
            pagesSelectorSecondButtonLandingPage.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorSecondButtonLandingPage.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelSecondButtonLandingPage.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelSecondButtonLandingPage).show();
                    selectedPageButtonSecondButtonLandingPage.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorSecondButtonLandingPage.set_selectedItems([{ Id: controlData.SecondButtonLandingPage}]);
        }

        /* RefreshUI SecondButtonBackground */
        jQuery("#SecondBtnBackgroundSelector").val(controlData.SecondButtonBackground);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges Title */
        controlData.Title = this.get_title().control.get_value();

        /* ApplyChanges Content */
        controlData.Content = this.get_content().control.get_value();

        /* ApplyChanges FirstButtonText */
        controlData.FirstButtonText = jQuery(this.get_firstButtonText()).val();

        /* ApplyChanges FirstButtonBackground */
        controlData.FirstButtonBackground = jQuery("#FirstBtnBackgroundSelector").val();

        /* ApplyChanges SecondButtonText */
        controlData.SecondButtonText = jQuery(this.get_secondButtonText()).val();

        /* ApplyChanges FirstButtonBackground */
        controlData.SecondButtonBackground = jQuery("#SecondBtnBackgroundSelector").val();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* FirstButtonLandingPage private methods */
    _showPageSelectorFirstButtonLandingPageHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorFirstButtonLandingPage().get_pageSelector();
        if (controlData.FirstButtonLandingPage) {
            pagesSelector.set_selectedItems([{ Id: controlData.FirstButtonLandingPage }]);
        }
        this._FirstButtonLandingPageDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._FirstButtonLandingPageDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedFirstButtonLandingPageHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorFirstButtonLandingPage().get_pageSelector();
        this._FirstButtonLandingPageDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPage = pagesSelector.get_selectedItem();
        if (selectedPage) {
            this.get_selectedFirstButtonLandingPageLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedFirstButtonLandingPageLabel()).show();
            this.get_pageSelectButtonFirstButtonLandingPage().innerHTML = '<span>Change</span>';
            controlData.FirstButtonLandingPage = selectedPage.Id;
        }
        else {
            jQuery(this.get_selectedFirstButtonLandingPageLabel()).hide();
            this.get_pageSelectButtonFirstButtonLandingPage().innerHTML = '<span>Select...</span>';
            controlData.FirstButtonLandingPage = "00000000-0000-0000-0000-000000000000";
        }
    },

    /* SecondButtonLandingPage private methods */
    _showPageSelectorSecondButtonLandingPageHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorSecondButtonLandingPage().get_pageSelector();
        if (controlData.SecondButtonLandingPage) {
            pagesSelector.set_selectedItems([{ Id: controlData.SecondButtonLandingPage }]);
        }
        this._SecondButtonLandingPageDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._SecondButtonLandingPageDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedSecondButtonLandingPageHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorSecondButtonLandingPage().get_pageSelector();
        this._SecondButtonLandingPageDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPage = pagesSelector.get_selectedItem();
        if (selectedPage) {
            this.get_selectedSecondButtonLandingPageLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedSecondButtonLandingPageLabel()).show();
            this.get_pageSelectButtonSecondButtonLandingPage().innerHTML = '<span>Change</span>';
            controlData.SecondButtonLandingPage = selectedPage.Id;
        }
        else {
            jQuery(this.get_selectedSecondButtonLandingPageLabel()).hide();
            this.get_pageSelectButtonSecondButtonLandingPage().innerHTML = '<span>Select...</span>';
            controlData.SecondButtonLandingPage = "00000000-0000-0000-0000-000000000000";
        }
    },

    /* --------------------------------- properties -------------------------------------- */

    /* Title properties */
    get_title: function () { return this._title; }, 
    set_title: function (value) { this._title = value; },

    /* Content properties */
    get_content: function () { return this._content; }, 
    set_content: function (value) { this._content = value; },

    /* FirstButtonText properties */
    get_firstButtonText: function () { return this._firstButtonText; }, 
    set_firstButtonText: function (value) { this._firstButtonText = value; },

    /* FirstButtonLandingPage properties */
    get_pageSelectButtonFirstButtonLandingPage: function () {
        if (this._pageSelectButtonFirstButtonLandingPage == null) {
            this._pageSelectButtonFirstButtonLandingPage = this.findElement("pageSelectButtonFirstButtonLandingPage");
        }
        return this._pageSelectButtonFirstButtonLandingPage;
    },
    get_selectedFirstButtonLandingPageLabel: function () {
        if (this._selectedFirstButtonLandingPageLabel == null) {
            this._selectedFirstButtonLandingPageLabel = this.findElement("selectedFirstButtonLandingPageLabel");
        }
        return this._selectedFirstButtonLandingPageLabel;
    },
    get_pageSelectorFirstButtonLandingPage: function () {
        return this._pageSelectorFirstButtonLandingPage;
    },
    set_pageSelectorFirstButtonLandingPage: function (val) {
        this._pageSelectorFirstButtonLandingPage = val;
    },
    get_selectorTagFirstButtonLandingPage: function () {
        return this._selectorTagFirstButtonLandingPage;
    },
    set_selectorTagFirstButtonLandingPage: function (value) {
        this._selectorTagFirstButtonLandingPage = value;
    },

    /* SecondButtonText properties */
    get_secondButtonText: function () { return this._secondButtonText; }, 
    set_secondButtonText: function (value) { this._secondButtonText = value; },

    /* SecondButtonLandingPage properties */
    get_pageSelectButtonSecondButtonLandingPage: function () {
        if (this._pageSelectButtonSecondButtonLandingPage == null) {
            this._pageSelectButtonSecondButtonLandingPage = this.findElement("pageSelectButtonSecondButtonLandingPage");
        }
        return this._pageSelectButtonSecondButtonLandingPage;
    },
    get_selectedSecondButtonLandingPageLabel: function () {
        if (this._selectedSecondButtonLandingPageLabel == null) {
            this._selectedSecondButtonLandingPageLabel = this.findElement("selectedSecondButtonLandingPageLabel");
        }
        return this._selectedSecondButtonLandingPageLabel;
    },
    get_pageSelectorSecondButtonLandingPage: function () {
        return this._pageSelectorSecondButtonLandingPage;
    },
    set_pageSelectorSecondButtonLandingPage: function (val) {
        this._pageSelectorSecondButtonLandingPage = val;
    },
    get_selectorTagSecondButtonLandingPage: function () {
        return this._selectorTagSecondButtonLandingPage;
    },
    set_selectorTagSecondButtonLandingPage: function (value) {
        this._selectorTagSecondButtonLandingPage = value;
    }
}

SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer.WhyJoinWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.WhyJoinWidget.Designer.WhyJoinWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
