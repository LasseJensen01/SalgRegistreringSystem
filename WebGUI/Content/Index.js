let startSelect = document.getElementById("startTime");
let endSelect = document.getElementById("endTime");
let startDatePicker = document.getElementById("startDate")
let endDatePicker = document.getElementById("endDate")
let departmentSelector = document.querySelector("select")
let caseList = document.getElementById("caseList")
let employeeList = document.getElementById("employeeList")
let hiddenCaseID = document.getElementById("selectedCaseID")
let hiddenEmployeeID = document.getElementById("selectedEmployeeID")
let hiddenDepartmentID = document.getElementById("selectedDepartmentID")

let c = null;
let employee = null;


caseList.addEventListener('click', (event) => {
if (event.target.tagName === 'LI'){
    caseList.querySelectorAll('li').forEach(li => {
        li.classList.remove('selected-li')
    })
    event.target.classList.add('selected-li')
    c = event.target.getAttribute('data-id')
    hiddenCaseID.value = c
    console.log("CaseID: " + hiddenCaseID.value);
}
})

employeeList.addEventListener('click', (event) => {
    if (event.target.tagName === 'LI'){
        employeeList.querySelectorAll('li').forEach(li => {
            li.classList.remove('selected-li')
        })
        event.target.classList.add('selected-li')
        employee = event.target.getAttribute('data-id')
        hiddenEmployeeID.value = employee
        departmentSelector.querySelectorAll('option').forEach(o => {
            if (o.selected){
                console.log(o.value);
                hiddenDepartmentID.value = o.value
            }
        })
        console.log("DepID: " + hiddenDepartmentID.value);
        console.log("EmpID: " + hiddenEmployeeID.value);
}
})

let today = new Date();
const yyyy = today.getFullYear();
const mm = String(today.getMonth()+1).padStart(2,'0');
const dd = String(today.getDay()).padStart(2,'0');
const formattedDate = `${yyyy}-${mm}-${dd}`; // Actually magic

startDatePicker.value = formattedDate;
endDatePicker.value = formattedDate;


//Fills the time pickers
for (let h = 0; h < 24; h++) {
    for (let m = 0; m < 60; m += 15) {
        let hour = h.toString().padStart(2, '0');
        let minute = m.toString().padStart(2, '0');
        let option = document.createElement("option");
        option.value = `${hour}:${minute}`;
        option.textContent = `${hour}:${minute}`;
        startSelect.appendChild(option);
    }
}

for (let h = 0; h < 24; h++) {
    for (let m = 0; m < 60; m += 15) {
        let hour = h.toString().padStart(2, '0');
        let minute = m.toString().padStart(2, '0');
        let option = document.createElement("option");
        option.value = `${hour}:${minute}`;
        option.textContent = `${hour}:${minute}`;
        endSelect.appendChild(option);
    }
}