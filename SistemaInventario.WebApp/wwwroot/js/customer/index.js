$(document).ready(function () {


    $.ajax({
        url: "customer/list",
        success: function (data) {

            //var jsonObject = JSON.parse(data);//A la variable le asigno el json decodificado
            console.log(data);
            if (data.length > 0) {

                $('#table_view').dataTable({
                    data: data,
                    columns: [
                        {
                            name: 'customerName',
                            data: 'customerName',
                            title: "Cliente",
                            sortable: true,
                            searchable: false
                        },
                        {
                            name: 'phone',
                            data: 'phone',
                            title: "Celular",
                            sortable: true,
                            searchable: false
                        },
                        {
                            name: 'email',
                            data: 'email',
                            title: "Email",
                            sortable: true,
                            searchable: false
                        },
                        {
                            name: 'customerId',
                            data: 'customerId',
                            title: "Acción",
                            sortable: false,
                            searchable: false,
                            render: function (data, type, row) {
                                var html = '<span >' +
                                    '<a href="/Customer/Detalle/' + data + '" ><i class="zmdi zmdi-eye zmdi-hc-lg"></i></a>';

                               
                                html += '<a href="/customer/Edit/' + data + '"><i class="zmdi zmdi-edit zmdi-hc-lg"></i></a>';
                                
                                html += '</span >';

                                return html;
                            }
                        }
                    ],
                });

            }

        }
    });


    //$('#table_view').DataTable({
    //    responsive: true,
    //    language: { url: "/www/lib/DataTables/datatables.net/i18n/es.json" },
    //    "info": true,
    //    "fixedHeader": true,
    //    "processing": true,
    //    "serverSide": true,
    //    "ajax": "/iniciativas/iniciativa/list/",
    //    stateSave: true,
    //    order: [[2, "desc"], [0, "desc"]],
    //    columns: [
    //        {
    //            name: 'numero',
    //            data: 'numero',
    //            title: "Número",
    //            sortable: true,
    //            searchable: true,
    //            className: 'text-nowrap',
    //            render: function (data, type, row) {
    //                var html = '<a href="/Iniciativas/Iniciativa/Detalle/' + row.id + '" sil-action="detalle" data-bind="' + row.id + '">' + data + '</a>';

    //                return html;
    //            }
    //        },
    //        {
    //            name: 'descripcion',
    //            data: 'descripcion',
    //            title: "Descripción",
    //            sortable: true,
    //            searchable: false
    //        },
    //        {
    //            name: 'fechaDeposito',
    //            data: 'fechaDeposito',
    //            title: "Fecha Depósito",
    //            sortable: true,
    //            searchable: false,
    //            render: function (data, type, row) {
    //                return moment(data).format("DD/MM/YYYY");
    //            }
    //        },
    //        {
    //            name: 'Estado.Descripcion',
    //            data: 'estado.descripcion',
    //            title: "Estado",
    //            sortable: false,
    //            searchable: false
    //        },
    //        {
    //            name: 'CondicionActual.Descripcion',
    //            data: 'condicionActual.descripcion',
    //            title: "Condición Actual",
    //            sortable: false,
    //            searchable: false
    //        },
    //        {
    //            name: 'id',
    //            data: 'id',
    //            title: "Acción",
    //            sortable: false,
    //            searchable: false,
    //            render: function (data, type, row) {
    //                var html = '<span class="files-more-link">' +
    //                    '<a href="/Iniciativas/Iniciativa/Detalle/' + data + '" sil-action="detalle" data-bind="' + data + '"><i class="zmdi zmdi-eye"></i></a>';

    //                if (!row.cerrada) {
    //                    html += '<a href="/Iniciativas/Iniciativa/Edit/' + data + '" sil-action="edit" data-bind="' + data + '"><i class="zmdi zmdi-edit"></i></a>';
    //                }
    //                html += '</span >';

    //                return html;
    //            }
    //        }
    //    ]
    //});
});