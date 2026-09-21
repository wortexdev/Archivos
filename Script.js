function cargarTabla() {
    fetch('/Home/TablaProductos')
        .then(r => r.text())
        .then(html => {
            document.getElementById('panel-datos').innerHTML = html;
        });
}


function cargarCategorias() {
    fetch('/Home/Categorias')
        .then(r => r.text())
        .then(html => {
            document.getElementById('panel-datos').innerHTML = html;
        });
}

function mostrarFiltroEmployees() {
    document.getElementById('panel-datos').innerHTML = `
            <h3>Filtro de Employees (Case-Sensitive)</h3>
            <input type="text" id="txtFiltro" placeholder="Filtrar por nombre o apellido"
                   style="padding:8px; width:250px;" onkeyup="filtrarEmployees()" />

            <div id="tabla-employees" style="margin-top:20px;"></div>
        `;

    // 🔥 Cargar la tabla completa al entrar
    filtrarEmployees();
}

function filtrarEmployees() {
    let filtro = document.getElementById('txtFiltro')?.value || "";

    fetch('/Home/Employees?filtro=' + filtro)
        .then(r => r.text())
        .then(html => {
            document.getElementById('tabla-employees').innerHTML = html;
        });
}

function mostrarCustomers() {
    document.getElementById('panel-datos').innerHTML = `
            <h3>Customers con CRUD y Paginación</h3>

            <button onclick="nuevo()">Nuevo Cliente</button>

            <div id="formulario" style="margin-top:20px;"></div>
            <div id="tabla-customers" style="margin-top:20px;"></div>
        `;

    cargarCustomers(1);
}

function cargarCustomers(page) {
    fetch('/Home/Customers?page=' + page)
        .then(r => r.text())
        .then(html => {
            document.getElementById('tabla-customers').innerHTML = html;
        });
}

function nuevo() {
    document.getElementById('formulario').innerHTML = `
            <input id="cid" placeholder="ID"><br>
            <input id="cname" placeholder="Nombre de la empresa"><br>
            <input id="contact" placeholder="Nombre del contacto"><br>
            <input id="city" placeholder="Ciudad"><br>
            <input id="country" placeholder="País"><br>
            <button onclick="insertar()">Guardar</button>
            <button onclick="cancelar()">Cancelar</button>
        `;
}

function insertar() {
    let c = {
        CustomerID: cid.value,
        CompanyName: cname.value,
        ContactName: contact.value,
        City: city.value,
        Country: country.value
    };

    fetch('/Home/RegistraCliente', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(c)
    }).then(() => {
        cargarCustomers(1);                               // refresca la tabla
        document.getElementById('formulario').innerHTML = "";   // 🔥 oculta el formulario
    });
}

function editar(id, emp, cont, city, country) {
    document.getElementById('formulario').innerHTML = `
            <input id="cid" value="${id}" placeholder="ID" readonly><br>
            <input id="cname" value="${emp}" placeholder="Empresa"><br>
            <input id="contact" value="${cont}" placeholder="Contacto"><br>
            <input id="city" value="${city}" placeholder="Ciudad"><br>
            <input id="country" value="${country}" placeholder=Pais"><br>
            <button onclick="actualizar()">Actualizar</button>
            <button onclick="cancelar()">Cancelar</button>
        `;
}

function actualizar() {
    let c = {
        CustomerID: cid.value,
        CompanyName: cname.value,
        ContactName: contact.value,
        City: city.value,
        Country: country.value
    };

    fetch('/Home/ActualizaCliente', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(c)
    }).then(() => {
        cargarCustomers(1);              // refresca la tabla
        document.getElementById('formulario').innerHTML = "";   // 🔥 oculta el formulario
    });
}

function eliminar(id) {
    if (!confirm("¿Eliminar cliente?")) return;

    fetch('/Home/EliminaCliente', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ id })
    }).then(() => cargarCustomers(1));
}

function cancelar() {
    document.getElementById('formulario').innerHTML = "";
}