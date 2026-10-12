// Plain JavaScript helpers

// Hide success messages automatically after 4 seconds
document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".auto-dismiss").forEach(function (alertBox) {
        setTimeout(function () {
            alertBox.classList.remove("show");
            setTimeout(function () { alertBox.remove(); }, 300);
        }, 4000);
    });

    // Allow only digits while typing in the phone field
    var phone = document.getElementById("Phone");
    if (phone) {
        phone.addEventListener("input", function () {
            phone.value = phone.value.replace(/\D/g, "");
        });
    }
});
