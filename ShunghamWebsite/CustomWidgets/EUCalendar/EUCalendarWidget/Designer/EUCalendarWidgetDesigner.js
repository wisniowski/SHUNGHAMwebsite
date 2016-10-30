Type.registerNamespace("SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer.EUCalendarWidgetDesigner");

SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer.EUCalendarWidgetDesigner = function (element) {

    /* Initialize DetailsPageId fields */
    this._pageSelectorDetailsPageId = null;
    this._selectorTagDetailsPageId = null;
    this._DetailsPageIdDialog = null;

    this._showPageSelectorDetailsPageIdDelegate = null;
    this._pageSelectedDetailsPageIdDelegate = null;

    /* Initialize InitialItemsCount fields */
    this._initialItemsCount = null;

    /* Initialize IsDetailsMode fields */
    this._isDetailsMode = null;

    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer.EUCalendarWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer.EUCalendarWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer.EUCalendarWidgetDesigner.callBaseMethod(this, 'initialize');

        /* Initialize DetailsPageId */
        this._showPageSelectorDetailsPageIdDelegate = Function.createDelegate(this, this._showPageSelectorDetailsPageIdHandler);
        $addHandler(this.get_pageSelectButtonDetailsPageId(), "click", this._showPageSelectorDetailsPageIdDelegate);

        this._pageSelectedDetailsPageIdDelegate = Function.createDelegate(this, this._pageSelectedDetailsPageIdHandler);
        this.get_pageSelectorDetailsPageId().add_doneClientSelection(this._pageSelectedDetailsPageIdDelegate);

        if (this._selectorTagDetailsPageId) {
            this._DetailsPageIdDialog = jQuery(this._selectorTagDetailsPageId).dialog({
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
        SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer.EUCalendarWidgetDesigner.callBaseMethod(this, 'dispose');

        /* Dispose DetailsPageId */
        if (this._showPageSelectorDetailsPageIdDelegate) {
            $removeHandler(this.get_pageSelectButtonDetailsPageId(), "click", this._showPageSelectorDetailsPageIdDelegate);
            delete this._showPageSelectorDetailsPageIdDelegate;
        }

        if (this._pageSelectedDetailsPageIdDelegate) {
            this.get_pageSelectorDetailsPageId().remove_doneClientSelection(this._pageSelectedDetailsPageIdDelegate);
            delete this._pageSelectedDetailsPageIdDelegate;
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

        /* RefreshUI DetailsPageId */
        if (controlData.DetailsPageId && controlData.DetailsPageId !== "00000000-0000-0000-0000-000000000000") {
            var pagesSelectorDetailsPageId = this.get_pageSelectorDetailsPageId().get_pageSelector();
            var selectedPageLabelDetailsPageId = this.get_selectedDetailsPageIdLabel();
            var selectedPageButtonDetailsPageId = this.get_pageSelectButtonDetailsPageId();
            pagesSelectorDetailsPageId.add_selectionApplied(function (o, args) {
                var selectedPage = pagesSelectorDetailsPageId.get_selectedItem();
                if (selectedPage) {
                    selectedPageLabelDetailsPageId.innerHTML = selectedPage.Title.Value;
                    jQuery(selectedPageLabelDetailsPageId).show();
                    selectedPageButtonDetailsPageId.innerHTML = '<span>Change</span>';
                }
            });
            pagesSelectorDetailsPageId.set_selectedItems([{ Id: controlData.DetailsPageId }]);
        }

        /* RefreshUI InitialItemsCount */
        jQuery(this.get_initialItemsCount()).val(controlData.InitialItemsCount);

        /* RefreshUI IsDetailsMode */
        jQuery(this.get_isDetailsMode()).attr("checked", controlData.IsDetailsMode);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges DetailsPageId */

        /* ApplyChanges SignInPageId */

        /* ApplyChanges InitialItemsCount */
        controlData.InitialItemsCount = jQuery(this.get_initialItemsCount()).val();

        /* ApplyChanges IsDetailsMode */
        controlData.IsDetailsMode = jQuery(this.get_isDetailsMode()).is(":checked");
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* DetailsPageId private methods */
    _showPageSelectorDetailsPageIdHandler: function (selectedItem) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorDetailsPageId().get_pageSelector();
        if (controlData.DetailsPageId) {
            pagesSelector.set_selectedItems([{ Id: controlData.DetailsPageId }]);
        }
        this._DetailsPageIdDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._DetailsPageIdDialog.dialog().parent().css("min-width", "355px");
        dialogBase.resizeToContent();
    },

    _pageSelectedDetailsPageIdHandler: function (items) {
        var controlData = this._propertyEditor.get_control();
        var pagesSelector = this.get_pageSelectorDetailsPageId().get_pageSelector();
        this._DetailsPageIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
        if (items == null) {
            return;
        }
        var selectedPage = pagesSelector.get_selectedItem();
        if (selectedPage) {
            this.get_selectedDetailsPageIdLabel().innerHTML = selectedPage.Title.Value;
            jQuery(this.get_selectedDetailsPageIdLabel()).show();
            this.get_pageSelectButtonDetailsPageId().innerHTML = '<span>Change</span>';
            controlData.DetailsPageId = selectedPage.Id;
        }
        else {
            jQuery(this.get_selectedDetailsPageIdLabel()).hide();
            this.get_pageSelectButtonDetailsPageId().innerHTML = '<span>Select...</span>';
            controlData.DetailsPageId = "00000000-0000-0000-0000-000000000000";
        }
    },

    /* --------------------------------- properties -------------------------------------- */

    /* DetailsPageId properties */
    get_pageSelectButtonDetailsPageId: function () {
        if (this._pageSelectButtonDetailsPageId == null) {
            this._pageSelectButtonDetailsPageId = this.findElement("pageSelectButtonDetailsPageId");
        }
        return this._pageSelectButtonDetailsPageId;
    },
    get_selectedDetailsPageIdLabel: function () {
        if (this._selectedDetailsPageIdLabel == null) {
            this._selectedDetailsPageIdLabel = this.findElement("selectedDetailsPageIdLabel");
        }
        return this._selectedDetailsPageIdLabel;
    },
    get_pageSelectorDetailsPageId: function () {
        return this._pageSelectorDetailsPageId;
    },
    set_pageSelectorDetailsPageId: function (val) {
        this._pageSelectorDetailsPageId = val;
    },
    get_selectorTagDetailsPageId: function () {
        return this._selectorTagDetailsPageId;
    },
    set_selectorTagDetailsPageId: function (value) {
        this._selectorTagDetailsPageId = value;
    },

    /* InitialItemsCount properties */
    get_initialItemsCount: function () { return this._initialItemsCount; },
    set_initialItemsCount: function (value) { this._initialItemsCount = value; },

    /* IsDetailsMode properties */
    get_isDetailsMode: function () { return this._isDetailsMode; },
    set_isDetailsMode: function (value) { this._isDetailsMode = value; }
}

SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer.EUCalendarWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.Designer.EUCalendarWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
