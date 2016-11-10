Type.registerNamespace("SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer.EUDossierGridWidgetDesigner");

SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer.EUDossierGridWidgetDesigner = function (element) {

    /* Initialize daysToDisplayUpdatesWithin fields */
    this._daysToDisplayUpdatesWithin = null;

    /* Initialize displayOtherUpdates fields */
    this._displayOtherUpdates = null;

    /* Calls the base constructor */
    SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer.EUDossierGridWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer.EUDossierGridWidgetDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer.EUDossierGridWidgetDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer.EUDossierGridWidgetDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */
       
        /* RefreshUI DaysToDisplayUpdatesWithin */
        jQuery(this.get_daysToDisplayUpdatesWithin()).val(controlData.DaysToDisplayUpdatesWithin);

        /* RefreshUI DisplayOtherUpdates */
        jQuery(this.get_displayOtherUpdates()).attr("checked", controlData.DisplayOtherUpdates);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges DaysToDisplayUpdatesWithin */
        controlData.DaysToDisplayUpdatesWithin = jQuery(this.get_daysToDisplayUpdatesWithin()).val();

        /* ApplyChanges DisplayOtherUpdates */
        controlData.DisplayOtherUpdates = jQuery(this.get_displayOtherUpdates()).is(":checked");
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* --------------------------------- properties -------------------------------------- */

    /* InitialItemsCount properties */
    get_daysToDisplayUpdatesWithin: function () { return this._daysToDisplayUpdatesWithin; },
    set_daysToDisplayUpdatesWithin: function (value) { this._daysToDisplayUpdatesWithin = value; },

    /* IsDetailsMode properties */
    get_displayOtherUpdates: function () { return this._displayOtherUpdates; },
    set_displayOtherUpdates: function (value) { this._displayOtherUpdates = value; }
}

SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer.EUDossierGridWidgetDesigner.registerClass('SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.Designer.EUDossierGridWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
