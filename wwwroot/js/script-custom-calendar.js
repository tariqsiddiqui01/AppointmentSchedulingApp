$(document).ready(function () {
    InitializeCalendar()
});

function InitializeCalendar() {
    try {
        $('#calendar').fullCalendar({
            timezone: false,
            header: {
                left: 'prev, next, today',
                center:'title',
                right:'month,agendaWeek,agendaDay'
            },
            selectable:true,
            editable:false,
            select: function(event){
                onShowModal(event, null);
            }
        });
    }

    catch (ex) {
        alert(ex);
    }
}

function onSubmitForm(){
    var reqData = {
        Id: parseInt($("#id").val()),
        Title: $("#title").val(),
        Description: $("#description").val(),
        StartDate: $("#appointmentDate").val(),
        Duration: $("#duration").val(),
        PatientId: $("#patientId").val(),
        DoctorId: $("#doctorId").val()
    }
}

function onShowModal(obj, isEventDetail){
    $("#appointmentInput").modal("show");
}

function onCloseModal(){
    $("#appointmentInput").modal("hide");
}