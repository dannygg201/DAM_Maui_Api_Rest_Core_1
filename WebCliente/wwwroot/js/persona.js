window.onload = function () {

    listar();
}

function listar() {

    pintar({

        url: "Persona/ListarPersonas",
        cabeceras: ["Nombre Completo", "Fecha de nacimiento", "Correo"],
        //Propiedades de PersonaCLS
        propiedades: ["nombrecompleto", "fechanacimientocadena", "correo"],
        propiedadId: "iidpersona",
        popup: true,
        titlePopup: "Persona",
        editar: true,
        eliminar: true
    },
        {
            url: "Persona/FiltrarPersonas",
            formulario: [[{

                class: "col-md-6",
                label: "Ingrese el nombre completo",
                type:  "text",
                name:  "nombrecompleto"

            }]]
        },

        {

            type: "popup",
            urlrecuperar: "Persona/RecuperarPersona",
            parametrorecuperar: "id",
            guardar: {
                url: "Persona/ActualizarPersona",
                method: "POST"
            },
            eliminar: {
                url: "Persona/EliminarPersona",
                method: "DELETE"
            },
            formulario: [[
                {
                    class: "col-md-6 d-none",
                    label: "Id persona",
                    type: "text",
                    name: "iidpersona"
                },
                {
                    class: "col-md-6",
                    label: "Nombre",
                    type: "text",
                    name: "nombre"
                },
                {
                    class: "col-md-6",
                    label: "Apellido Paterno",
                    type: "text",
                    name: "appaterno"
                },
                {
                    class: "col-md-6",
                    label: "Apellido Materno",
                    type: "text",
                    name: "apmaterno"
                },
                {
                    class: "col-md-6",
                    label: "Fecha de Nacimiento",
                    type: "date",
                    name: "fechanacimientocadena"
                },
                {
                    class: "col-md-6",
                    label: "Correo Electrónico",
                    type: "text",
                    name: "correo"
                },
                {
                    class: "col-md-6",
                    label: "Sexo",
                    type: "radio",
                    labels: ["Masculino", "Femenino"],
                    values: ["1", "2"],
                    ids: ["rbMasculino", "rbFemenino"],
                    checked: "rbMasculino",
                    name: "iidsexo"
                }
            ]]
        }