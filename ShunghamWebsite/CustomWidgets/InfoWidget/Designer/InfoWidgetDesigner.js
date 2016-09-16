Type.registerNamespace("SitefinityWebApp.CustomWidgets.InfoWidget.Designer");

SitefinityWebApp.CustomWidgets.InfoWidget.Designer.InfoWidgetDesigner = function (element) {
    /* Initialize Title fields */
    this._title = null;
    
    /* Initialize Summary fields */
    this._summary = null;
    
    /* Initialize Content fields */
    this._content = null;
    
    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.InfoWidget.Designer.InfoWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.InfoWidget.Designer.InfoWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.InfoWidget.Designer.InfoWidgetDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.CustomWidgets.InfoWidget.Designer.InfoWidgetDesigner.callBaseMethod(this, 'dispose');
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

        /* RefreshUI Summary */
        jQuery(this.get_summary()).val(controlData.Summary);

        /* RefreshUI Content */
        var htmlText = controlData.Content ? controlData.Content : "";
        this.get_content().control.set_value(htmlText);

        this._resizeControlDesigner();
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges Title */
        controlData.Title = jQuery(this.get_title()).val();

        /* ApplyChanges Summary */
        controlData.Summary = jQuery(this.get_summary()).val();

        /* ApplyChanges Content */
        controlData.Content = this.get_content().control.get_value();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    _resizeControlDesigner: function () {
        setTimeout("dialogBase.setWndWidth(800)", 300);
    },

    /* --------------------------------- properties -------------------------------------- */

    /* Title properties */
    get_title: function () { return this._title; }, 
    set_title: function (value) { this._title = value; },

    /* Summary properties */
    get_summary: function () { return this._summary; }, 
    set_summary: function (value) { this._summary = value; },

    /* Content properties */
    get_content: function () { return this._content; }, 
    set_content: function (value) { this._content = value; }
}

SitefinityWebApp.CustomWidgets.InfoWidget.Designer.InfoWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.InfoWidget.Designer.InfoWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
