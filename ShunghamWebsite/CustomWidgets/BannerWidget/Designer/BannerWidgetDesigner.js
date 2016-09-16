Type.registerNamespace("SitefinityWebApp.CustomWidgets.BannerWidget.Designer");

SitefinityWebApp.CustomWidgets.BannerWidget.Designer.BannerWidgetDesigner = function (element) {
    /* Initialize Title fields */
    this._title = null;
    
    /* Initialize SubTitle fields */
    this._subTitle = null;
    
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
    
    /* Initialize FirstBtnText fields */
    this._firstBtnText = null;
    
    /* Initialize FirstBtnLandingPage fields */
    this._pageSelectorFirstBtnLandingPage = null;
    this._selectorTagFirstBtnLandingPage = null;
    this._FirstBtnLandingPageDialog = null;
 
    this._showPageSelectorFirstBtnLandingPageDelegate = null;
    this._pageSelectedFirstBtnLandingPageDelegate = null;
    
    /* Initialize SecondBtnText fields */
    this._secondBtnText = null;
    
    /* Initialize SecondBtnLandingPage fields */
    this._pageSelectorSecondBtnLandingPage = null;
    this._selectorTagSecondBtnLandingPage = null;
    this._SecondBtnLandingPageDialog = null;
 
    this._showPageSelectorSecondBtnLandingPageDelegate = null;
    this._pageSelectedSecondBtnLandingPageDelegate = null;
    
    /* Initialize the service url for the image thumbnails */
    this.imageServiceUrl = null;

    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.BannerWidget.Designer.BannerWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.BannerWidget.Designer.BannerWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.BannerWidget.Designer.BannerWidgetDesigner.callBaseMethod(this, 'initialize');

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

        /* Initialize FirstBtnLandingPage */
        this._showPageSelectorFirstBtnLandingPageDelegate = Function.createDelegate(this, this._showPageSelectorFirstBtnLandingPageHandler);
        $addHandler(this.get_pageSelectButtonFirstBtnLandingPage(), "click", this._showPageSelectorFirstBtnLandingPageDelegate);

        this._pageSelectedFirstBtnLandingPageDelegate = Function.createDelegate(this, this._pageSelectedFirstBtnLandingPageHandler);
        this.get_pageSelectorFirstBtnLandingPage().add_doneClientSelection(this._pageSelectedFirstBtnLandingPageDelegate);

        if (this._selectorTagFirstBtnLandingPage) {
            this._FirstBtnLandingPageDialog = jQuery(this._selectorTagFirstBtnLandingPage).dialog({
                autoOpen: false,
                modal: false,
                width: 395,
                closeOnEscape: true,
                resizable: false,
                draggable: false,
                zIndex: 5000
            });
        }

        /* Initialize SecondBtnLandingPage */
        this._showPageSelectorSecondBtnLandingPageDelegate = Function.createDelegate(this, this._showPageSelectorSecondBtnLandingPageHandler);
        $addHandler(this.get_pageSelectButtonSecondBtnLandingPage(), "click", this._showPageSelectorSecondBtnLandingPageDelegate);

        this._pageSelectedSecondBtnLandingPageDelegate = Function.createDelegate(this, this._pageSelectedSecondBtnLandingPageHandler);
        this.get_pageSelectorSecondBtnLandingPage().add_doneClientSelection(this._pageSelectedSecondBtnLandingPageDelegate);

        if (this._selectorTagSecondBtnLandingPage) {
            this._SecondBtnLandingPageDialog = jQuery(this._selectorTagSecondBtnLandingPage).dialog({
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
        SitefinityWebApp.CustomWidgets.BannerWidget.Designer.BannerWidgetDesigner.callBaseMethod(this, 'dispose');

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

        /* Dispose FirstBtnLandingPage */
        if (this._showPageSelectorFirstBtnLandingPageDelegate) {
            $removeHandler(this.get_pageSelectButtonFirstBtnLandingPage(), "click", this._showPageSelectorFirstBtnLandingPageDelegate);
            delete this._showPageSelectorFirstBtnLandingPageDelegate;
        }

        if (this._pageSelectedFirstBtnLandingPageDelegate) {
            this.get_pageSelectorFirstBtnLandingPage().remove_doneClientSelection(this._pageSelectedFirstBtnLandingPageDelegate);
            delete this._pageSelectedFirstBtnLandingPageDelegate;
        }

        /* Dispose SecondBtnLandingPage */
        if (this._showPageSelectorSecondBtnLandingPageDelegate) {
            $removeHandler(this.get_pageSelectButtonSecondBtnLandingPage(), "click", this._showPageSelectorSecondBtnLandingPageDelegate);
            delete this._showPageSelectorSecondBtnLandingPageDelegate;
        }

        if (this._pageSelectedSecondBtnLandingPageDelegate) {
            this.get_pageSelectorSecondBtnLandingPage().remove_doneClientSelection(this._pageSelectedSecondBtnLandingPageDelegate);
            delete this._pageSelectedSecondBtnLandingPageDelegate;
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
        jQuery(this.get_title()).val(controlData.Title);

        /* RefreshUI SubTitle */
        jQuery(this.get_subTitle()).val(controlData.SubTitle);

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

        /* RefreshUI FirstBtnText */
        jQuery(this.get_firstBtnText()).val(controlData.FirstBtnText);

        /* RefreshUI FirstBtnLandingPage */
        if (controlData.FirstBtnLandingPage && controlData.FirstBtnLandingPage !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorFirstBtnLandingPage = this.get_pageSelectorFirstBtnLandingPage().get_pageSelector();
            var selectedPageLabelFirstBtnLandingPage = this.get_selectedFirstBtnLandingPageLabel();
            var selectedPageButtonFirstBtnLandingPage = this.get_pageSelectButtonFirstBtnLandingPage();
            pagesSelectorFirstBtnLandingPage.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorFirstBtnLandingPage.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelFirstBtnLandingPage.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelFirstBtnLandingPage).show();
                    selectedPageButtonFirstBtnLandingPage.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorFirstBtnLandingPage.set_selectedItems([{ Id: controlData.FirstBtnLandingPage}]);
        }
        else if (controlData.FirstBtnExternalLink && controlData.FirstBtnLandingPage !== "") {
            var externalPagesSelector = this.get_pageSelectorFirstBtnLandingPage().get_extPagesSelector();
            var selectedPageLabelFirstBtnLandingPage = this.get_selectedFirstBtnLandingPageLabel();
            var selectedPageButtonFirstBtnLandingPage = this.get_pageSelectButtonFirstBtnLandingPage();

            selectedPageLabelFirstBtnLandingPage.innerHTML = controlData.FirstBtnExternalLink;
            jQuery(selectedPageLabelFirstBtnLandingPage).show();
            selectedPageButtonFirstBtnLandingPage.innerHTML = '<span>Change</span>';
        }

        /* RefreshUI SecondBtnText */
        jQuery(this.get_secondBtnText()).val(controlData.SecondBtnText);

        /* RefreshUI SecondBtnLandingPage */
        if (controlData.SecondBtnLandingPage && controlData.SecondBtnLandingPage !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorSecondBtnLandingPage = this.get_pageSelectorSecondBtnLandingPage().get_pageSelector();
            var selectedPageLabelSecondBtnLandingPage = this.get_selectedSecondBtnLandingPageLabel();
            var selectedPageButtonSecondBtnLandingPage = this.get_pageSelectButtonSecondBtnLandingPage();
            pagesSelectorSecondBtnLandingPage.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorSecondBtnLandingPage.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelSecondBtnLandingPage.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelSecondBtnLandingPage).show();
                    selectedPageButtonSecondBtnLandingPage.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorSecondBtnLandingPage.set_selectedItems([{ Id: controlData.SecondBtnLandingPage}]);
        }
        else if (controlData.SecondBtnExternalLink && controlData.SecondBtnLandingPage !== "") {
            var externalPagesSelector = this.get_pageSelectorSecondBtnLandingPage().get_extPagesSelector();
            var selectedPageLabelSecondBtnLandingPage = this.get_selectedSecondBtnLandingPageLabel();
            var selectedPageButtonSecondBtnLandingPage = this.get_pageSelectButtonSecondBtnLandingPage();

            selectedPageLabelSecondBtnLandingPage.innerHTML = controlData.SecondBtnExternalLink;
            jQuery(selectedPageLabelSecondBtnLandingPage).show();
            selectedPageButtonSecondBtnLandingPage.innerHTML = '<span>Change</span>';
        }

        this._resizeControlDesigner();
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();
        this._resizeControlDesigner();
        /* ApplyChanges Title */
        controlData.Title = jQuery(this.get_title()).val();

        /* ApplyChanges SubTitle */
        controlData.SubTitle = jQuery(this.get_subTitle()).val();

        /* ApplyChanges BackgroundImageId */
        controlData.BackgroundImageId = this.get_selectedBackgroundImageId().innerHTML;

        /* ApplyChanges FirstBtnText */
        controlData.FirstBtnText = jQuery(this.get_firstBtnText()).val();

        /* ApplyChanges FirstBtnLandingPage */

        /* ApplyChanges SecondBtnText */
        controlData.SecondBtnText = jQuery(this.get_secondBtnText()).val();

        /* ApplyChanges SecondBtnLandingPage */
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

    _resizeControlDesigner: function () {
        setTimeout("dialogBase.setWndWidth(800)", 800);
    },

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
        if(this._BackgroundImageIdDialog){
            this._BackgroundImageIdDialog.dialog("close");
        }
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    _selectorBackgroundImageIdUploaderViewFileChangedHandler: function () {
        dialogBase.resizeToContent();
    },

    /* FirstBtnLandingPage private methods */
    _showPageSelectorFirstBtnLandingPageHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorFirstBtnLandingPage().get_pageSelector();
        var externalPagesSelector = this.get_pageSelectorFirstBtnLandingPage().get_extPagesSelector();
        if (controlData.FirstBtnLandingPage) {
            pagesSelector.set_selectedItems([{ Id: controlData.FirstBtnLandingPage }]);
        }
        if (controlData.FirstBtnExternalLink) {
            externalPagesSelector.get_urlTextBox().set_value(controlData.FirstBtnExternalLink);
        }
        this._FirstBtnLandingPageDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        jQuery(".sfTxtUrlSeletor").hide();
        this._FirstBtnLandingPageDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedFirstBtnLandingPageHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorFirstBtnLandingPage().get_pageSelector();
        this._FirstBtnLandingPageDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPage = pagesSelector.get_selectedItem();
        var externalPagesSelector = this.get_pageSelectorFirstBtnLandingPage().get_extPagesSelector();

        if (selectedPage) {
            this.get_selectedFirstBtnLandingPageLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedFirstBtnLandingPageLabel()).show();
            this.get_pageSelectButtonFirstBtnLandingPage().innerHTML = '<span>Change</span>';
            controlData.FirstBtnLandingPage = selectedPage.Id;
            controlData.FirstBtnExternalLink = "";
            externalPagesSelector.get_urlTextBox().set_value("");
        }
        var externalUrl = externalPagesSelector.get_urlTextBox().get_value();

        if (externalUrl && (externalUrl != "")) {
            controlData.FirstBtnExternalLink = externalUrl;
            this.get_selectedFirstBtnLandingPageLabel().innerHTML = externalUrl;

            jQuery(this.get_selectedFirstBtnLandingPageLabel()).show();
            this.get_pageSelectButtonFirstBtnLandingPage().innerHTML = '<span>Change</span>';
            controlData.FirstBtnLandingPage = "00000000-0000-0000-0000-000000000000";
        }
        if (!selectedPage && !externalUrl) {
            jQuery(this.get_selectedFirstBtnLandingPageLabel()).hide();
            this.get_pageSelectButtonFirstBtnLandingPage().innerHTML = '<span>Select...</span>';
            controlData.FirstBtnLandingPage = "00000000-0000-0000-0000-000000000000";
            controlData.FirstBtnExternalLink = "";
        }
    },

    /* SecondBtnLandingPage private methods */
    _showPageSelectorSecondBtnLandingPageHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorSecondBtnLandingPage().get_pageSelector();
        var externalPagesSelector = this.get_pageSelectorSecondBtnLandingPage().get_extPagesSelector();
        if (controlData.SecondBtnLandingPage) {
            pagesSelector.set_selectedItems([{ Id: controlData.SecondBtnLandingPage }]);
        }
        if (controlData.SecondBtnExternalLink) {
            externalPagesSelector.get_urlTextBox().set_value(controlData.SecondBtnExternalLink);
        }
        this._SecondBtnLandingPageDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        jQuery(".sfTxtUrlSeletor").hide();
        this._SecondBtnLandingPageDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedSecondBtnLandingPageHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorSecondBtnLandingPage().get_pageSelector();
        this._SecondBtnLandingPageDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPage = pagesSelector.get_selectedItem();
        var externalPagesSelector = this.get_pageSelectorSecondBtnLandingPage().get_extPagesSelector();
        if (selectedPage) {
            this.get_selectedSecondBtnLandingPageLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedSecondBtnLandingPageLabel()).show();
            this.get_pageSelectButtonSecondBtnLandingPage().innerHTML = '<span>Change</span>';
            controlData.SecondBtnLandingPage = selectedPage.Id;
            controlData.SecondBtnExternalLink = "";
            externalPagesSelector.get_urlTextBox().set_value("");
        }
        var externalUrl = externalPagesSelector.get_urlTextBox().get_value();

        if (externalUrl && (externalUrl != "")) {
            controlData.SecondBtnExternalLink = externalUrl;
            this.get_selectedSecondBtnLandingPageLabel().innerHTML = externalUrl;

            jQuery(this.get_selectedSecondBtnLandingPageLabel()).show();
            this.get_pageSelectButtonSecondBtnLandingPage().innerHTML = '<span>Change</span>';
            controlData.SecondBtnLandingPage = "00000000-0000-0000-0000-000000000000";
        }
        if (!selectedPage && !externalUrl) {
            jQuery(this.get_selectedSecondBtnLandingPageLabel()).hide();
            this.get_pageSelectButtonSecondBtnLandingPage().innerHTML = '<span>Select...</span>';
            controlData.SecondBtnLandingPage = "00000000-0000-0000-0000-000000000000";
            controlData.SecondBtnExternalLink = "";
        }
    },

    /* --------------------------------- properties -------------------------------------- */

    /* Title properties */
    get_title: function () { return this._title; }, 
    set_title: function (value) { this._title = value; },

    /* SubTitle properties */
    get_subTitle: function () { return this._subTitle; }, 
    set_subTitle: function (value) { this._subTitle = value; },

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
    },

    /* FirstBtnText properties */
    get_firstBtnText: function () { return this._firstBtnText; }, 
    set_firstBtnText: function (value) { this._firstBtnText = value; },

    /* FirstBtnLandingPage properties */
    get_pageSelectButtonFirstBtnLandingPage: function () {
        if (this._pageSelectButtonFirstBtnLandingPage == null) {
            this._pageSelectButtonFirstBtnLandingPage = this.findElement("pageSelectButtonFirstBtnLandingPage");
        }
        return this._pageSelectButtonFirstBtnLandingPage;
    },
    get_selectedFirstBtnLandingPageLabel: function () {
        if (this._selectedFirstBtnLandingPageLabel == null) {
            this._selectedFirstBtnLandingPageLabel = this.findElement("selectedFirstBtnLandingPageLabel");
        }
        return this._selectedFirstBtnLandingPageLabel;
    },
    get_pageSelectorFirstBtnLandingPage: function () {
        return this._pageSelectorFirstBtnLandingPage;
    },
    set_pageSelectorFirstBtnLandingPage: function (val) {
        this._pageSelectorFirstBtnLandingPage = val;
    },
    get_selectorTagFirstBtnLandingPage: function () {
        return this._selectorTagFirstBtnLandingPage;
    },
    set_selectorTagFirstBtnLandingPage: function (value) {
        this._selectorTagFirstBtnLandingPage = value;
    },

    /* SecondBtnText properties */
    get_secondBtnText: function () { return this._secondBtnText; }, 
    set_secondBtnText: function (value) { this._secondBtnText = value; },

    /* SecondBtnLandingPage properties */
    get_pageSelectButtonSecondBtnLandingPage: function () {
        if (this._pageSelectButtonSecondBtnLandingPage == null) {
            this._pageSelectButtonSecondBtnLandingPage = this.findElement("pageSelectButtonSecondBtnLandingPage");
        }
        return this._pageSelectButtonSecondBtnLandingPage;
    },
    get_selectedSecondBtnLandingPageLabel: function () {
        if (this._selectedSecondBtnLandingPageLabel == null) {
            this._selectedSecondBtnLandingPageLabel = this.findElement("selectedSecondBtnLandingPageLabel");
        }
        return this._selectedSecondBtnLandingPageLabel;
    },
    get_pageSelectorSecondBtnLandingPage: function () {
        return this._pageSelectorSecondBtnLandingPage;
    },
    set_pageSelectorSecondBtnLandingPage: function (val) {
        this._pageSelectorSecondBtnLandingPage = val;
    },
    get_selectorTagSecondBtnLandingPage: function () {
        return this._selectorTagSecondBtnLandingPage;
    },
    set_selectorTagSecondBtnLandingPage: function (value) {
        this._selectorTagSecondBtnLandingPage = value;
    }
}

SitefinityWebApp.CustomWidgets.BannerWidget.Designer.BannerWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.BannerWidget.Designer.BannerWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
