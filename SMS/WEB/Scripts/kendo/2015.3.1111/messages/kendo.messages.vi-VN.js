(function ($, undefined) {
    /* FlatColorPicker messages */

    if (kendo.ui.FlatColorPicker) {
        kendo.ui.FlatColorPicker.prototype.options.messages =
        $.extend(true, kendo.ui.FlatColorPicker.prototype.options.messages, {
            "apply": "Áp Dụng",
            "cancel": "Hủy"
        });
    }

    /* ColorPicker messages */

    if (kendo.ui.ColorPicker) {
        kendo.ui.ColorPicker.prototype.options.messages =
        $.extend(true, kendo.ui.ColorPicker.prototype.options.messages, {
            "apply": "Áp Dụng",
            "cancel": "Hủy"
        });
    }

    /* ColumnMenu messages */

    if (kendo.ui.ColumnMenu) {
        kendo.ui.ColumnMenu.prototype.options.messages =
        $.extend(true, kendo.ui.ColumnMenu.prototype.options.messages, {
            "sortAscending": "Sắp Xếp Tăng Dần",
            "sortDescending": "Sắp Xếp Giảm Dần",
            "filter": "Lọc",
            "columns": "Cột",
            "done": "Xong",
            "settings": "Column Settings",
            "lock": "Lock",
            "unlock": "Unlock"
        });
    }

    /* Editor messages */

    if (kendo.ui.Editor) {
        kendo.ui.Editor.prototype.options.messages =
        $.extend(true, kendo.ui.Editor.prototype.options.messages, {
            "bold": "Bold",
            "italic": "Italic",
            "underline": "Underline",
            "strikethrough": "Strikethrough",
            "superscript": "Superscript",
            "subscript": "Subscript",
            "justifyCenter": "Center text",
            "justifyLeft": "Align text left",
            "justifyRight": "Align text right",
            "justifyFull": "Justify",
            "insertUnorderedList": "Insert unordered list",
            "insertOrderedList": "Insert ordered list",
            "indent": "Indent",
            "outdent": "Outdent",
            "createLink": "Insert hyperlink",
            "unlink": "Remove hyperlink",
            "insertImage": "Insert image",
            "insertFile": "Insert file",
            "insertHtml": "Insert HTML",
            "viewHtml": "View HTML",
            "fontName": "Chọn font family",
            "fontNameInherit": "(inherited font)",
            "fontSize": "Chọn font size",
            "fontSizeInherit": "(inherited size)",
            "formatBlock": "Format",
            "formatting": "Format",
            "foreColor": "Color",
            "backColor": "Background color",
            "style": "Styles",
            "emptyFolder": "Empty Folder",
            "uploadFile": "Upload",
            "orderBy": "Arrange by:",
            "orderBySize": "Size",
            "orderByName": "Name",
            "invalidFileType": "The selected file \"{0}\" is not valid. Supported file types are {1}.",
            "deleteFile": 'Are you sure you want to delete "{0}"?',
            "overwriteFile": 'A file with name "{0}" already exists in the current directory. Do you want to overwrite it?',
            "directoryNotFound": "A directory with this name was not found.",
            "imageWebAddress": "Web address",
            "imageAltText": "Alternate text",
            "imageWidth": "Width (px)",
            "imageHeight": "Height (px)",
            "fileWebAddress": "Web address",
            "fileTitle": "Title",
            "linkWebAddress": "Web address",
            "linkText": "Text",
            "linkToolTip": "ToolTip",
            "linkOpenInNewWindow": "Open link in new window",
            "dialogUpdate": "Cập Nhật",
            "dialogInsert": "Insert",
            "dialogButtonSeparator": "or",
            "dialogCancel": "Hủy",
            "createTable": "Create table",
            "addColumnLeft": "Add column on the left",
            "addColumnRight": "Add column on the right",
            "addRowAbove": "Add row above",
            "addRowBelow": "Add row below",
            "deleteRow": "Xóa row",
            "deleteColumn": "Xóa column"
        });
    }

    /* FileBrowser messages */

    if (kendo.ui.FileBrowser) {
        kendo.ui.FileBrowser.prototype.options.messages =
        $.extend(true, kendo.ui.FileBrowser.prototype.options.messages, {
            "uploadFile": "Upload",
            "orderBy": "Arrange by",
            "orderByName": "Name",
            "orderBySize": "Size",
            "directoryNotFound": "A directory with this name was not found.",
            "emptyFolder": "Empty Folder",
            "deleteFile": 'Are you sure you want to delete "{0}"?',
            "invalidFileType": "The selected file \"{0}\" is not valid. Supported file types are {1}.",
            "overwriteFile": "A file with name \"{0}\" already exists in the current directory. Do you want to overwrite it?",
            "dropFilesHere": "drop file here to upload",
            "search": "Search"
        });
    }

    /* FilterCell messages */

    if (kendo.ui.FilterCell) {
        kendo.ui.FilterCell.prototype.options.messages =
        $.extend(true, kendo.ui.FilterCell.prototype.options.messages, {
            "isTrue": "true",
            "isFalse": "false",
            "filter": "Lọc",
            "clear": "Clear",
            "operator": "Operator"
        });
    }

    /* FilterCell operators */

    if (kendo.ui.FilterCell) {
        kendo.ui.FilterCell.prototype.options.operators =
        $.extend(true, kendo.ui.FilterCell.prototype.options.operators, {
            "string": {
                "eq": "Bằng Với",
                "neq": "Không Bằng Với",
                "startswith": "Bắt Đầu Với",
                "contains": "Chứa",
                "doesnotcontain": "Không Chứa",
                "endswith": "Kết Thúc Với"
            },
            "number": {
                "eq": "Bằng Với",
                "neq": "Không Bằng Với",
                "gte": "Lớn Hơn Hoặc Bằng",
                "gt": "Lớn Hơn",
                "lte": "Nhỏ Hơn Hoặc Bằng",
                "lt": "Nhỏ Hơn"
            },
            "date": {
                "eq": "Bằng Với",
                "neq": "Không Bằng Với",
                "gte": "Sau Hoặc Bằng Ngày",
                "gt": "Sau Ngày",
                "lte": "Trước Hoặc Bằng Ngày",
                "lt": "Trước Ngày"
            },
            "enums": {
                "eq": "Bằng Với",
                "neq": "Không Bằng Với"
            }
        });
    }

    /* FilterMenu messages */

    if (kendo.ui.FilterMenu) {
        kendo.ui.FilterMenu.prototype.options.messages =
        $.extend(true, kendo.ui.FilterMenu.prototype.options.messages, {
            "info": "Hiển thị item có giá trị:",
            "isTrue": "true",
            "isFalse": "false",
            "filter": "Lọc",
            "clear": "Clear",
            "and": "Và",
            "or": "Hoặc",
            "selectValue": "-Chọn value-",
            "operator": "Operator",
            "value": "Giá Trị",
            "cancel": "Hủy"
        });
    }

    /* FilterMenu operator messages */

    if (kendo.ui.FilterMenu) {
        kendo.ui.FilterMenu.prototype.options.operators =
        $.extend(true, kendo.ui.FilterMenu.prototype.options.operators, {
            "string": {
                "eq": "Bằng Với",
                "neq": "Không Bằng Với",
                "startswith": "Bắt Đầu Với",
                "contains": "Chứa",
                "doesnotcontain": "Không Chứa",
                "endswith": "Kết Thúc Với"
            },
            "number": {
                "eq": "Bằng Với",
                "neq": "Không Bằng Với",
                "gte": "Lớn Hơn Hoặc Bằng",
                "gt": "Lớn Hơn",
                "lte": "Nhỏ Hơn Hoặc Bằng",
                "lt": "Nhỏ Hơn"
            },
            "date": {
                "eq": "Bằng Với",
                "neq": "Không Bằng Với",
                "gte": "Sau Hoặc Bằng Ngày",
                "gt": "Sau Ngày",
                "lte": "Trước Hoặc Bằng Ngày",
                "lt": "Trước Ngày"
            },
            "enums": {
                "eq": "Bằng Với",
                "neq": "Không Bằng Với"
            }
        });
    }

    /* FilterMultiCheck messages */

    if (kendo.ui.FilterMultiCheck) {
        kendo.ui.FilterMultiCheck.prototype.options.messages =
        $.extend(true, kendo.ui.FilterMultiCheck.prototype.options.messages, {
            "checkAll": "Chọn Tất cả",
            "clear": "Clear",
            "filter": "Lọc"
        });
    }

    /* Gantt messages */

    if (kendo.ui.Gantt) {
        kendo.ui.Gantt.prototype.options.messages =
        $.extend(true, kendo.ui.Gantt.prototype.options.messages, {
            "actions": {
                "addChild": "Add Child",
                "append": "Add Task",
                "insertAfter": "Add Below",
                "insertBefore": "Add Above",
                "pdf": "Xuất ra PDF"
            },
            "cancel": "Hủy",
            "deleteDependencyWindowTitle": "Xóa dependency",
            "deleteTaskWindowTitle": "Xóa task",
            "destroy": "Xóa",
            "editor": {
                "assingButton": "Assign",
                "editorTitle": "Task",
                "end": "End",
                "percentComplete": "Complete",
                "resources": "Resources",
                "resourcesEditorTitle": "Resources",
                "resourcesHeader": "Resources",
                "start": "Start",
                "title": "Title",
                "unitsHeader": "Units"
            },
            "save": "Save",
            "views": {
                "day": "Day",
                "end": "End",
                "month": "Month",
                "start": "Start",
                "week": "Week",
                "year": "Year"
            }
        });
    }

    /* Grid messages */

    if (kendo.ui.Grid) {
        kendo.ui.Grid.prototype.options.messages =
        $.extend(true, kendo.ui.Grid.prototype.options.messages, {
            "commands": {
                "cancel": "Hủy Thay Đổi",
                "canceledit": "Hủy",
                "create": "Thêm mới",
                "destroy": "Xóa",
                "edit": "Sửa",
                "excel": "Xuất ra Excel",
                "pdf": "Xuất ra PDF",
                "save": "Lưu Thay Đổi",
                "select": "Chọn",
                "update": "Cập Nhật"
            },
            "editable": {
                "cancelDelete": "Hủy",
                "confirmation": "Bạn có chắc muốn xóa record này?",
                "confirmDelete": "Xóa"
            },
            "noRecords": "Không có record nào."
        });
    }

    /* Groupable messages */

    if (kendo.ui.Groupable) {
        kendo.ui.Groupable.prototype.options.messages =
        $.extend(true, kendo.ui.Groupable.prototype.options.messages, {
            "empty": "Drag a column header and drop it here to group by that column"
        });
    }

    /* NumericTextBox messages */

    if (kendo.ui.NumericTextBox) {
        kendo.ui.NumericTextBox.prototype.options =
        $.extend(true, kendo.ui.NumericTextBox.prototype.options, {
            "upArrowText": "Increase value",
            "downArrowText": "Decrease value"
        });
    }

    /* Pager messages */

    if (kendo.ui.Pager) {
        kendo.ui.Pager.prototype.options.messages =
        $.extend(true, kendo.ui.Pager.prototype.options.messages, {
            "allPages": "Tất cả",
            "display": "{0} - {1} của {2} items",
            "empty": "Không có item nào để hiển thị",
            "page": "Page",
            "of": "of {0}",
            "itemsPerPage": "item mỗi trang",
            "first": "Đi tới trang đầu",
            "previous": "Đi tới trang trước",
            "next": "Đi tới trang tiếp theo",
            "last": "Đi tới trang cuối",
            "refresh": "Refresh",
            "morePages": "More pages"
        });
    }

    /* PivotGrid messages */

    if (kendo.ui.PivotGrid) {
        kendo.ui.PivotGrid.prototype.options.messages =
        $.extend(true, kendo.ui.PivotGrid.prototype.options.messages, {
            "measureFields": "Drop Data Fields Here",
            "columnFields": "Drop Column Fields Here",
            "rowFields": "Drop Rows Fields Here"
        });
    }

    /* PivotFieldMenu messages */

    if (kendo.ui.PivotFieldMenu) {
        kendo.ui.PivotFieldMenu.prototype.options.messages =
        $.extend(true, kendo.ui.PivotFieldMenu.prototype.options.messages, {
            "info": "Hiển thị item có giá trị:",
            "filterFields": "Fields Lọc",
            "filter": "Lọc",
            "include": "Include Fields...",
            "title": "Fields to include",
            "clear": "Clear",
            "ok": "Ok",
            "cancel": "Hủy",
            "operators": {
                "contains": "Chứa",
                "doesnotcontain": "Không Chứa",
                "startswith": "Bắt Đầu Với",
                "endswith": "Kết Thúc Với",
                "eq": "Bằng Với",
                "neq": "Không Bằng Với"
            }
        });
    }

    /* RecurrenceEditor messages */

    if (kendo.ui.RecurrenceEditor) {
        kendo.ui.RecurrenceEditor.prototype.options.messages =
        $.extend(true, kendo.ui.RecurrenceEditor.prototype.options.messages, {
            "frequencies": {
                "never": "Never",
                "hourly": "Hourly",
                "daily": "Daily",
                "weekly": "Weekly",
                "monthly": "Monthly",
                "yearly": "Yearly"
            },
            "hourly": {
                "repeatEvery": "Repeat every: ",
                "interval": " hour(s)"
            },
            "daily": {
                "repeatEvery": "Repeat every: ",
                "interval": " day(s)"
            },
            "weekly": {
                "interval": " week(s)",
                "repeatEvery": "Repeat every: ",
                "repeatOn": "Repeat on: "
            },
            "monthly": {
                "repeatEvery": "Repeat every: ",
                "repeatOn": "Repeat on: ",
                "interval": " month(s)",
                "day": "Day "
            },
            "yearly": {
                "repeatEvery": "Repeat every: ",
                "repeatOn": "Repeat on: ",
                "interval": " year(s)",
                "of": " of "
            },
            "end": {
                "label": "End:",
                "mobileLabel": "Ends",
                "never": "Never",
                "after": "After ",
                "occurrence": " occurrence(s)",
                "on": "On "
            },
            "offsetPositions": {
                "first": "first",
                "second": "second",
                "third": "third",
                "fourth": "fourth",
                "last": "last"
            },
            "weekdays": {
                "day": "day",
                "weekday": "weekday",
                "weekend": "weekend day"
            }
        });
    }

    /* Scheduler messages */

    if (kendo.ui.Scheduler) {
        kendo.ui.Scheduler.prototype.options.messages =
        $.extend(true, kendo.ui.Scheduler.prototype.options.messages, {
            "allDay": "all day",
            "date": "Date",
            "event": "Event",
            "time": "Time",
            "showFullDay": "Show full day",
            "showWorkDay": "Show business hours",
            "today": "Today",
            "save": "Save",
            "cancel": "Hủy",
            "destroy": "Xóa",
            "deleteWindowTitle": "Xóa event",
            "ariaSlotLabel": "Selected from {0:t} to {1:t}",
            "ariaEventLabel": "{0} on {1:D} at {2:t}",
            "editable": {
                "confirmation": "Are you sure you want to delete this event?"
            },
            "views": {
                "day": "Day",
                "week": "Week",
                "workWeek": "Work Week",
                "agenda": "Agenda",
                "month": "Month"
            },
            "recurrenceMessages": {
                "deleteWindowTitle": "Xóa Recurring Item",
                "deleteWindowOccurrence": "Xóa current occurrence",
                "deleteWindowSeries": "Xóa the series",
                "editWindowTitle": "Sửa Recurring Item",
                "editWindowOccurrence": "Sửa current occurrence",
                "editWindowSeries": "Sửa the series",
                "deleteRecurring": "Do you want to delete only this event occurrence or the whole series?",
                "editRecurring": "Do you want to edit only this event occurrence or the whole series?"
            },
            "editor": {
                "title": "Title",
                "start": "Start",
                "end": "End",
                "allDayEvent": "Tất cả day event",
                "description": "Description",
                "repeat": "Repeat",
                "timezone": " ",
                "startTimezone": "Start timezone",
                "endTimezone": "End timezone",
                "separateTimezones": "Use separate start and end time zones",
                "timezoneEditorTitle": "Timezones",
                "timezoneEditorButton": "Time zone",
                "timezoneTitle": "Time zones",
                "noTimezone": "No timezone",
                "editorTitle": "Event"
            }
        });
    }

    /* Spreadsheet messages */

    if (kendo.spreadsheet && kendo.spreadsheet.messages.borderPalette) {
        kendo.spreadsheet.messages.borderPalette =
        $.extend(true, kendo.spreadsheet.messages.borderPalette, {
            "allBorders": "Tất cả borders",
            "insideBorders": "Inside borders",
            "insideHorizontalBorders": "Inside horizontal borders",
            "insideVerticalBorders": "Inside vertical borders",
            "outsideBorders": "Outside borders",
            "leftBorder": "Left border",
            "topBorder": "Top border",
            "rightBorder": "Right border",
            "bottomBorder": "Bottom border",
            "noBorders": "No border"
        });
    }

    if (kendo.spreadsheet && kendo.spreadsheet.messages.dialogs) {
        kendo.spreadsheet.messages.dialogs =
        $.extend(true, kendo.spreadsheet.messages.dialogs, {
            "apply": "Áp Dụng",
            "save": "Save",
            "cancel": "Hủy",
            "remove": "Remove",
            "okText": "OK",
            "formatCellsDialog": {
                "title": "Format",
                "categories": {
                    "number": "Number",
                    "currency": "Currency",
                    "date": "Date"
                }
            },
            "fontFamilyDialog": {
                "title": "Font"
            },
            "fontSizeDialog": {
                "title": "Font size"
            },
            "bordersDialog": {
                "title": "Borders"
            },
            "alignmentDialog": {
                "title": "Alignment",
                "buttons": {
                    "justtifyLeft": "Align left",
                    "justifyCenter": "Center",
                    "justifyRight": "Align right",
                    "justifyFull": "Justify",
                    "alignTop": "Align top",
                    "alignMiddle": "Align middle",
                    "alignBottom": "Align bottom"
                }
            },
            "mergeDialog": {
                "title": "Merge cells",
                "buttons": {
                    "mergeCells": "Merge all",
                    "mergeHorizontally": "Merge horizontally",
                    "mergeVertically": "Merge vertically",
                    "unmerge": "Unmerge"
                }
            },
            "freezeDialog": {
                "title": "Freeze panes",
                "buttons": {
                    "freezePanes": "Freeze panes",
                    "freezeRows": "Freeze rows",
                    "freezeColumns": "Freeze columns",
                    "unfreeze": "Unfreeze panes"
                }
            },
            "validationDialog": {
                "title": "Data Validation",
                "hintMessage": "Please enter a valid {0} value {1}.",
                "hintTitle": "Validation {0}",
                "criteria": {
                    "any": "Any value",
                    "number": "Number",
                    "text": "Text",
                    "date": "Date",
                    "custom": "Custom Formula"
                },
                "comparers": {
                    "greaterThan": "greater than",
                    "lessThan": "less than",
                    "between": "between",
                    "notBetween": "not between",
                    "equalTo": "equal to",
                    "notEqualTo": "not equal to",
                    "greaterThanOrEqualTo": "greater than or equal to",
                    "lessThanOrEqualTo": "less than or equal to"
                },
                "comparerMessages": {
                    "greaterThan": "greater than {0}",
                    "lessThan": "less than {0}",
                    "between": "between {0} and {1}",
                    "notBetween": "not between {0} and {1}",
                    "equalTo": "equal to {0}",
                    "notEqualTo": "not equal to {0}",
                    "greaterThanOrEqualTo": "greater than or equal to {0}",
                    "lessThanOrEqualTo": "less than or equal to {0}",
                    "custom": "that satisfies the formula: {0}"
                },
                "labels": {
                    "criteria": "Criteria",
                    "comparer": "Comparer",
                    "min": "Min",
                    "max": "Max",
                    "value": "Giá Trị",
                    "start": "Start",
                    "end": "End",
                    "onInvalidData": "On invalid data",
                    "rejectInput": "Reject input",
                    "showWarning": "Show warning",
                    "showHint": "Show hint",
                    "hintTitle": "Hint title",
                    "hintMessage": "Hint message"
                },
                "placeholders": {
                    "typeTitle": "Type title",
                    "typeMessage": "Type message"
                }
            },
            "saveAsDialog": {
                "title": "Save As...",
                "labels": {
                    "fileName": "File name",
                    "saveAsType": "Save as type"
                }
            },
            "excelExportDialog": {
                "title": "Xuất ra Excel..."
            },
            "modifyMergedDialog": {
                "errorMessage": "Cannot change part of a merged cell."
            },
            "useKeyboardDialog": {
                "title": "Copying and pasting",
                "errorMessage": "These actions cannot be invoked through the menu. Please use the keyboard shortcuts instead:",
                "labels": {
                    "forCopy": "for copy",
                    "forCut": "for cut",
                    "forPaste": "for paste"
                }
            },
            "unsupportedSelectionDialog": {
                "errorMessage": "That action cannot be performed on multiple selection."
            }
        });
    }

    if (kendo.spreadsheet && kendo.spreadsheet.messages.toolbar) {
        kendo.spreadsheet.messages.toolbar =
        $.extend(true, kendo.spreadsheet.messages.toolbar, {
            "addColumnLeft": "Add column left",
            "addColumnRight": "Add column right",
            "addRowAbove": "Add row above",
            "addRowBelow": "Add row below",
            "alignment": "Alignment",
            "alignmentButtons": {
                "justtifyLeft": "Align left",
                "justifyCenter": "Center",
                "justifyRight": "Align right",
                "justifyFull": "Justify",
                "alignTop": "Align top",
                "alignMiddle": "Align middle",
                "alignBottom": "Align bottom"
            },
            "backgroundColor": "Background",
            "bold": "Bold",
            "borders": "Borders",
            "copy": "Copy",
            "cut": "Cut",
            "deleteColumn": "Xóa column",
            "deleteRow": "Xóa row",
            "excelExport": "Xuất ra Excel...",
            "filter": "Lọc",
            "fontFamily": "Font",
            "fontSize": "Font size",
            "format": "Custom format...",
            "formatTypes": {
                "automatic": "Automatic",
                "number": "Number",
                "percent": "Percent",
                "financial": "Financial",
                "currency": "Currency",
                "date": "Date",
                "time": "Time",
                "dateTime": "Date time",
                "duration": "Duration",
                "moreFormats": "More formats..."
            },
            "formatDecreaseDecimal": "Decrease decimal",
            "formatIncreaseDecimal": "Increase decimal",
            "freeze": "Freeze panes",
            "freezeButtons": {
                "freezePanes": "Freeze panes",
                "freezeRows": "Freeze rows",
                "freezeColumns": "Freeze columns",
                "unfreeze": "Unfreeze panes"
            },
            "italic": "Italic",
            "merge": "Merge cells",
            "mergeButtons": {
                "mergeCells": "Merge all",
                "mergeHorizontally": "Merge horizontally",
                "mergeVertically": "Merge vertically",
                "unmerge": "Unmerge"
            },
            "paste": "Paste",
            "quickAccess": {
                "redo": "Redo",
                "undo": "Undo"
            },
            "sortAsc": "Sort ascending",
            "sortDesc": "Sort descending",
            "sortButtons": {
                "sortSheetAsc": "Sort sheet A to Z",
                "sortSheetDesc": "Sort sheet Z to A",
                "sortRangeAsc": "Sort range A to Z",
                "sortRangeDesc": "Sort range Z to A"
            },
            "textColor": "Text Color",
            "textWrap": "Wrap text",
            "underline": "Underline",
            "validation": "Data validation..."
        });
    }

    if (kendo.spreadsheet && kendo.spreadsheet.messages.view) {
        kendo.spreadsheet.messages.view =
        $.extend(true, kendo.spreadsheet.messages.view, {
            "errors": {
                "shiftingNonblankCells": "Cannot insert cells due to data loss possibility. Chọn another insert location or delete the data from the end of your worksheet."
            },
            "tabs": {
                "home": "Home",
                "insert": "Insert",
                "data": "Data"
            }
        });
    }

    /* Slider messages */

    if (kendo.ui.Slider) {
        kendo.ui.Slider.prototype.options =
        $.extend(true, kendo.ui.Slider.prototype.options, {
            "increaseButtonTitle": "Increase",
            "decreaseButtonTitle": "Decrease"
        });
    }

    /* TreeList messages */

    if (kendo.ui.TreeList) {
        kendo.ui.TreeList.prototype.options.messages =
        $.extend(true, kendo.ui.TreeList.prototype.options.messages, {
            "noRows": "No records to display",
            "loading": "Loading...",
            "requestFailed": "Request failed.",
            "retry": "Retry",
            "commands": {
                "edit": "Sửa",
                "update": "Cập Nhật",
                "canceledit": "Hủy",
                "create": "Add new record",
                "createchild": "Add child record",
                "destroy": "Xóa",
                "excel": "Xuất ra Excel",
                "pdf": "Xuất ra PDF"
            }
        });
    }

    /* TreeView messages */

    if (kendo.ui.TreeView) {
        kendo.ui.TreeView.prototype.options.messages =
        $.extend(true, kendo.ui.TreeView.prototype.options.messages, {
            "loading": "Loading...",
            "requestFailed": "Request failed.",
            "retry": "Retry"
        });
    }

    /* Upload messages */

    if (kendo.ui.Upload) {
        kendo.ui.Upload.prototype.options.localization =
        $.extend(true, kendo.ui.Upload.prototype.options.localization, {
            "select": "Chọn files...",
            "cancel": "Hủy",
            "retry": "Retry",
            "remove": "Remove",
            "uploadSelectedFiles": "Upload files",
            "dropFilesHere": "drop files here to upload",
            "statusUploading": "uploading",
            "statusUploaded": "uploaded",
            "statusWarning": "warning",
            "statusFailed": "failed",
            "headerStatusUploading": "Uploading...",
            "headerStatusUploaded": "Xong"
        });
    }

    /* Validator messages */

    if (kendo.ui.Validator) {
        kendo.ui.Validator.prototype.options.messages =
        $.extend(true, kendo.ui.Validator.prototype.options.messages, {
            "required": "{0} is required",
            "pattern": "{0} is not valid",
            "min": "{0} should be greater than or equal to {1}",
            "max": "{0} should be smaller than or equal to {1}",
            "step": "{0} is not valid",
            "email": "{0} is not valid email",
            "url": "{0} is not valid URL",
            "date": "{0} is not valid date",
            "dateCompare": "End date should be greater than or equal to the start date"
        });
    }
})(window.kendo.jQuery);