let chartData = [
    {
        title: "HTML",
        percent: 70
    },
    {
        title: "CSS",
        percent: 65
    },
    {
        title: "Javascript",
        percent: 50
    },
    {
        title: "Mobile First Design",
        percent: 50
    },
    {
        title: "Responsive Design",
        percent: 60
    }
];

function populateData() {
    for (let i = 0; i < chartData.length; i++) {

        let chart = document.getElementById("graph");
        let progressBar = document.createElement("div");
        let barLabel = document.createElement("label");
        let progressTrack = document.createElement("div");
        let progressFill = document.createElement("div");

        progressBar.setAttribute("id", chartData[i].title);
        progressBar.setAttribute("class", "progressBar");
        barLabel.setAttribute("class", "barLabel");
        progressTrack.setAttribute("class", "progressTrack");
        progressFill.setAttribute("class", "progressFill");

        chart.appendChild(progressBar);
        progressBar.appendChild(barLabel);
        progressBar.appendChild(progressTrack);
        progressTrack.appendChild(progressFill);
        barLabel.appendChild(document.createTextNode(chartData[i].title));

        setTimeout(function () { progressFill.style.width = chartData[i].percent + "%" });

    }
}

populateData();


