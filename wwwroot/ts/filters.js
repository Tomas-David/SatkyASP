const Filters = (menu, items) => {
    let textDataset = [];
    let dataset = [];
    //vezme datasety a da je do pole
    for (const item of items) {
        textDataset.push(item.dataset.filtertext);
        dataset.push(item.dataset.filter);
    }
    //seřazené pole s vyfiltrovanýmy daty
    let filtertextDataset = FilterData(textDataset);
    let filterDataset = FilterData(dataset);
    let btn = document.createElement("li");
    ;
    let btnLink = document.createElement("a");
    //vytvoří <li> s odkazem, názvem a datasetem
    for (let i = 0; i < filterDataset.length; i++) {
        if (menu === null) {
            throw new Error("Proměná menu je prázdná");
        }
        else {
            //vytvoření li, a 
            btn = document.createElement("li");
            btnLink = document.createElement("a");
            //přídání atributů
            if (filterDataset[i] !== undefined) {
                btnLink.setAttribute("href", "#");
                btnLink.setAttribute("class", "btn btn__filter btn__filter--active");
                btnLink.setAttribute("data-filter", filterDataset[i]);
                btnLink.textContent = filtertextDataset[i];
            }
            btn.addEventListener('click', (even) => {
                even.preventDefault();
                history.pushState(null, '', window.location.pathname + '?' + filterDataset[i].toString());
                const url = new URLSearchParams(window.location.search);
                let curretUrl;
                curretUrl = url.toString();
                for (const item of items) {
                    //pokud elemnent obsahuje aspoň jeden dataset 
                    let itemDataset = `${item.dataset.filter}=`;
                    if (itemDataset.includes(curretUrl.split("=")[0])) {
                        item.classList.remove("hide-element");
                        item.classList.add("show-element");
                    }
                    else {
                        item.classList.remove("show-element");
                        item.classList.add("hide-element");
                    }
                }
            });
            btn.appendChild(btnLink);
            menu.appendChild(btn);
        }
    }
};
//úprava kolekcí
const FilterData = (Collection) => {
    let filteredData = [];
    let splitedData = [];
    let data = [];
    //Vyfiltruje proměné které jsou undefine
    filteredData = Collection.filter((OneCollectionItem) => {
        return OneCollectionItem !== undefined;
    });
    filteredData.forEach((OneFilteredData) => {
        if (OneFilteredData === undefined) {
            throw new Error("Proměná je nedefinovaná");
        }
        else {
            //pushuje jen data ne pole co vznikli při split()
            splitedData.push(...OneFilteredData.split(";"));
        }
    });
    //seřadí data a vyfilturje jen unikátní
    splitedData.sort();
    for (let i = 0; i < splitedData.length; i++) {
        if (splitedData[i] !== splitedData[i - 1]) {
            data.push(splitedData[i]);
        }
    }
    return data.sort((a, b) => a.localeCompare(b));
};
Filters(document.querySelector(".sub-menu"), document.querySelectorAll(".card"));
//# sourceMappingURL=filters.js.map