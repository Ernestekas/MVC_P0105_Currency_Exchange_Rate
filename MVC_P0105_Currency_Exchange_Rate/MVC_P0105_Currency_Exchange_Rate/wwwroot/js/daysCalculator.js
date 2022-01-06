function changed() {
    let yearDD = document.getElementById('year').value;
    let monthDD = document.getElementById("month").value;
    let dayDD = document.getElementById("day").value;

    let maxDaysPerMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]

    if (yearDD % 4 === 0) {
        maxDaysPerMonth[1] = 29;
    }

    let day = document.getElementById("day");
    for (let i = day.options.length - 1; i >= 0; i--) {
        day.remove(i);
    }

    for (let i = 0; i < maxDaysPerMonth[monthDD - 1]; i++) {
        day.options[i] = new Option(i + 1, i + 1);
    }
}