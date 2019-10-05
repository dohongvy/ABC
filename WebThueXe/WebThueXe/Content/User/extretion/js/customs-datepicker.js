
$(document).ready(function () {
	
	//disable typing in date picker input
    $('#pickup,#dropoff').ready(function () {
        var minDate = new Date();
        $("#pickup").datepicker({
            showAnim: 'drop',
            numberOfMonths: 1,
            minDate: minDate,
            dateFormat: 'dd-mm-yyyy',
            onClose: function (selectedDate) {
                $('#dropoff').datepicker("option", "minDate", selectedDate);
            }
        });
         $("#dropoff").datepicker({
                showAnim: 'drop',
                numberOfMonths: 1,
                minDate: minDate,
                dateFormat: 'dd-mm-yyyy',
                onClose: function (selectedDate) {
                $('#pickup').datepicker("option", "minDate", selectedDate);
            }            
	//disable typing in date picker input end
});