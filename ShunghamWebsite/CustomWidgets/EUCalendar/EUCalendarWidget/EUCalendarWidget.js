Type.registerNamespace("SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget");

SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.EUCalendarWidget = function (element) {
    SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.EUCalendarWidget.initializeBase(this, [element]);
    this._initialItemsCount = null;
    this._isDetailsMode = null;
};

SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.EUCalendarWidget.prototype = {
    initialize: function () {
        SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.EUCalendarWidget.callBaseMethod(this, "initialize");
    },
    dispose: function () {
        SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.EUCalendarWidget.callBaseMethod(this, "dispose");
    },

    get_initialItemsCount: function () {
        return this._initialItemsCount;
    },
    set_initialItemsCount: function (value) {
        this._initialItemsCount = value;
    },
    get_isDetailsMode: function () {
        return this._isDetailsMode;
    },
    set_isDetailsMode: function (value) {
        this._isDetailsMode = value;
    }
};

SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.EUCalendarWidget.registerClass("SitefinityWebApp.CustomWidgets.EUCalendar.EUCalendarWidget.EUCalendarWidget.EventsWidget", Sys.UI.Control);
if (typeof (Sys) !== "undefined") Sys.Application.notifyScriptLoaded();