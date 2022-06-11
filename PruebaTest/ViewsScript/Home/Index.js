
let selectMarca;
$(document).ready(function () {
    llenarSelectTipoGastoCopago()
    const selectMarca = document.getElementById('selectMarca');
    const selectSubmarca = document.getElementById('selectSubmarca');
    const selectModelo = document.getElementById('selectModelo');
    const selectDescripcion = document.getElementById('selectDescripcion');

    selectMarca.addEventListener('change', async (event) => {
        let value = event.target.value;
        console.log('value es =>', value)
        cleanSelect(selectSubmarca)
        if (value>0) {
       
            let reqSubmarca = {
                NombreCatalogo: "Submarca",
                Filtro: event.target.value,
                IdAplication: 2
            }
            let data = await getData(reqSubmarca);
            addOptions('selectSubmarca', data, 'sSubMarca', 'iIdSubMarca')
            console.log('miEvent', value);

        }     
    });



});

async function llenarSelectTipoGastoCopago(isNew) {
    var req = {
        NombreCatalogo: "Marca",
        Filtro: "2",
        IdAplication: 2
    };
   
    let dataMarca = [];
    console.log('req', req);
    let data =await getData(req);
    console.log('optionsData',data)
    addOptions('selectMarca', data, 'sMarca', 'iIdMarca')




}

async function getData(req) {
    let data;
    let urlApi = 'https://apitestcotizamatico.azurewebsites.net/api/catalogos';
 const requests  =await fetch(urlApi, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(req)
 })
    const res = await requests.json();

    data = JSON.parse(res.CatalogoJsonString)
    console.log('data',data)
    return data;
      
}
function addOptions(domElement, data, value, id) {
    var select = document.getElementsByName(domElement)[0];

    for (let i = 0; i < data.length; i++) {
        console.log(data[i])
        var option = document.createElement("option");
        option.text = data[i][value];
        option.value = data[i][id];
        select.add(option);
    }


}

function cleanSelect($select) {
    
        for (let i = $select.options.length; i >= 1; i--) {
            $select.remove(i);
        }
    
}