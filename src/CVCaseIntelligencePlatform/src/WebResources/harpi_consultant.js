var CVCI = CVCI || {};

CVCI.Consultant = {

    onLoad: function (executionContext) {

        const formContext =
            executionContext.getFormContext();

        CVCI.Consultant.updateFormState(formContext);
    },

    onProfileStatusChange: function (executionContext) {

        const formContext =
            executionContext.getFormContext();

        CVCI.Consultant.updateFormState(formContext);
    },

    onSave: function (executionContext) {

        console.log("Consultant record saved");
    },

    updateFormState: function (formContext) {

        const statusAttribute =
            formContext.getAttribute("harpi_profilestatus");

        if (!statusAttribute) {

            console.log(
                "Profile Status field not found"
            );

            return;
        }

        const summaryAttribute =
            formContext.getAttribute("harpi_professionalsummary");

        if (!summaryAttribute) {

            console.log(
                "Professional Summary attribute not found"
            );

            return;
        }

        const summaryControl =
            formContext.getControl("harpi_professionalsummary");

        if (!summaryControl) {

            console.log(
                "Professional Summary control not found"
            );

            return;
        }

        const status =
            statusAttribute.getValue();

        const summary =
            summaryAttribute.getValue();

        if (status === 312820001) {

            summaryControl.setDisabled(true);

            console.log(
                "Professional Summary locked"
            );

            if (!summary) {

                formContext.ui.setFormNotification(
                    "Professional Summary is required before review.",
                    "WARNING",
                    "summaryWarning"
                );

                console.log(
                    "Validation warning displayed"
                );

            } else {

                formContext.ui.clearFormNotification(
                    "summaryWarning"
                );
            }

        } else {

            summaryControl.setDisabled(false);

            formContext.ui.clearFormNotification(
                "summaryWarning"
            );

            console.log(
                "Professional Summary unlocked"
            );
        }
    }
};