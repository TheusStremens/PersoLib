﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="PersoLib.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PersoLib- Biblioteca Pessoal</title>
    <link rel="shortcut icon" href="assets/ico/favicon.png">
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <link href="assets/css/main.css" rel="stylesheet">
    <link rel="stylesheet" href="assets/css/icomoon.css">
    <link href="assets/css/datepicker.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/animate-custom.css" rel="stylesheet">
    <link href="assets/css/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <%--<script type="text/javascript" src="assets/js/jquery-1.10.2.min.js"></script>--%>
    <script type="text/javascript" src="assets/js/jasny-bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="assets/js/dataTables.bootstrap.js"></script>
    <script type="text/javascript" src="assets/js/modernizr.custom.js"></script>
    <%--<script type="text/javascript" src="assets/js/bootstrap.min.js"></script>--%>
    <script type="text/javascript" src="assets/js/retina.js"></script>
    <script type="text/javascript" src="assets/js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="assets/js/jquery-func.js"></script>
    <script type="text/javascript" src="assets/js/smoothscroll.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#grid_livros').dataTable();
            $('#grid_emprestimos').dataTable();
            $('#<%= txt_nova_data_prazo.ClientID %>').datepicker({
                dateFormat: 'dd-mm-yy'
            });
            $('#<%= txt_nova_data.ClientID %>').datepicker({
                dateFormat: 'dd-mm-yy'
            });

        });
    </script>
    <script type="text/javascript">
        function selecionar_livro(id, acao, nome) {
            $.ajax({
                type: "POST",
                url: window.location.href + "/selecao_livro",
                data: "{codigo: '" + id + "'}",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    if (acao == 'EDITAR') {
                        $('#<%= txt_editar_livro_nome.ClientID %>').val(nome);
                        $('#edit').modal('show');
                    }
                    else if (acao == 'EXCLUIR') {
                        $('#delete').modal('show');
                    }
                    else if (acao == 'EMPRESTAR') {
                        $('#<%= txt_label_livro.ClientID %>').val(nome);
                        $('#modal_novo_emprestimo').modal('show');
                    }
                }
            });
}
    </script>
    <script type="text/javascript">
        function selecionar_emprestimo(id, acao, data) {
            $.ajax({
                type: "POST",
                url: window.location.href + "/selecao_emprestimo",
                data: "{codigo: '" + id + "'}",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    if (acao == 'PRAZO') {
                        $('#<%= txt_nova_data_prazo.ClientID %>').val(data);
                        $('#modal_alterar_prazo').modal('show');
                    }
                    else if (acao == 'FINALIZAR') {
                        $('#modal_finalizar_emprestimo').modal('show');
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        function selecionar_aba(aba) {
            $.ajax({
                type: "POST",
                url: window.location.href + "/selecao_aba",
                data: "{codigo: '" + aba + "'}",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    if (aba == "aba1") {
                        $("#div_aba1").tab("show");
                        $("#li_aba1").addClass("active");
                        $("#li_aba2").removeClass("active");
                        $("#li_aba3").removeClass("active");
                    } else if (aba == "aba2") {
                        $("#div_aba2").tab("show");
                        $("#li_aba1").removeClass("active");
                        $("#li_aba2").addClass("active");
                        $("#li_aba3").removeClass("active");
                    } else if (aba == "aba3") {
                        $("#div_aba3").tab("show");
                        $("#li_aba1").removeClass("active");
                        $("#li_aba2").removeClass("active");
                        $("#li_aba3").addClass("active");
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .login {
            padding-top: 7px;
        }

        .email {
            padding-top: 15px;
            color: White;
            text-align: right;
        }

        .datepicker {
            z-index: 1151 !important;
        }

        @media (min-width: 768px) {
            .acao {
                width: 60px !important;
                max-width: 60px !important;
                min-width: 60px !important;
            }
        }
    </style>
    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic'
        rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,300,700' rel='stylesheet'
        type='text/css'>
</head>
<body data-spy="scroll" data-offset="0" data-target="#navbar-main">
    <form id="form_body" runat="server">
        <div id="navbar-main">
            <div class="navbar navbar-inverse navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon icon-shield" style="font-size: 30px; color: #3498db;"></span>
                        </button>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li runat="server" id="li_aba1" class="active"><a href="" class="smoothScroll" onclick="selecionar_aba('aba1');">Meus Livros</a></li>
                            <li runat="server" id="li_aba2"><a href="" class="smoothScroll" onclick="selecionar_aba('aba2');">Meus Emprestimos</a></li>
                            <li runat="server" id="li_aba3"><a href="" class="smoothScroll" onclick="selecionar_aba('aba3');">Meu Perfil</a></li>
                            <li>
                                <div class="col-lg-2 login">
                                    <a href="PaginaInicial.aspx" id="btn_login" class="btn btn-danger login">Fazer Logout
                                    </a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3>Principal</h3>
                    <div class="tabbable-panel">
                        <div class="tabbable-line">
                            <div class="tab-content">
                                <div class="tab-pane fade in active" runat="server" id="div_aba1">
                                    <div style="padding-top: 20px; padding-left: 15px;">
                                        <div runat="server" id="alert_topo_livro" visible="false" class="alert alert-success alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <span class="sr-only"></span>
                                            <asp:Label runat="server" ID="lbl_alert_topo_livro" Text=""> </asp:Label>
                                        </div>
                                        <div runat="server" id="alert_erro_topo_livro" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <span class="sr-only"></span>
                                            <asp:Label runat="server" ID="lbl_alert_erro_topo_livro" Text=""> </asp:Label>
                                        </div>
                                        <h1>Biblioteca</h1>
                                        <h4 class="text-justify">Aqui se encontram todos os seus livros. Você pode cadastrar novos livros sempre que quiser. Na aba Ações é possível
                                            editar, excluir ou emprestar um livro. Um livro emprestado não poderá ser excluido ou alterado
                                        </h4>
                                        <a class="btn btn-success" data-toggle="modal" data-target="#modal_novo_livro">Cadastrar novo livro</a>
                                    </div>
                                    <div class="container" style="padding-top: 20px;">
                                        <asp:Literal runat="server" ID="literal_grid_livros"></asp:Literal>
                                        <%--<table id="grid_livros" visible="false" runat="server" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>Nome do Livro
                                                    </th>
                                                    <th>Quantidade
                                                    </th>
                                                    <th>Quantidade Emprestada
                                                    </th>
                                                    <th class="acao">Ações
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>O Símbolo Perdido
                                                    </td>
                                                    <td>5
                                                    </td>
                                                    <td>2
                                                    </td>
                                                    <td>
                                                        <a title="Editar este livro" class="btn btn-primary btn-xs" data-toggle="modal"
                                                            data-target="#edit">
                                                            <span class="glyphicon glyphicon-pencil"></span>
                                                        </a>
                                                        <a title="Excluir este livro" class="btn btn-danger btn-xs" data-toggle="modal"
                                                            data-target="#delete">
                                                            <span class="glyphicon glyphicon-trash"></span>
                                                        </a>
                                                        <a title="Empreste este livro" class="btn btn-warning btn-xs" data-toggle="modal"
                                                            data-target="#modal_novo_emprestimo">
                                                            <span class="glyphicon glyphicon-new-window"></span>
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Assassinato no Expresso do Oriente
                                                    </td>
                                                    <td>1
                                                    </td>
                                                    <td>0
                                                    </td>
                                                    <td>
                                                        <a title="Editar este livro" class="btn btn-primary btn-xs" data-toggle="modal"
                                                            data-target="#edit">
                                                            <span class="glyphicon glyphicon-pencil"></span>
                                                        </a>
                                                        <a title="Excluir este livro" class="btn btn-danger btn-xs" data-toggle="modal"
                                                            data-target="#delete">
                                                            <span class="glyphicon glyphicon-trash"></span>
                                                        </a>
                                                        <a title="Empreste este livro" class="btn btn-warning btn-xs" data-toggle="modal"
                                                            data-target="#modal_novo_emprestimo">
                                                            <span class="glyphicon glyphicon-new-window"></span>
                                                        </a>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>--%>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="div_aba2" runat="server">
                                    <div style="padding-top: 20px; padding-left: 15px;">
                                        <div runat="server" id="alert_topo_emprestimo" visible="false" class="alert alert-success alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <span class="sr-only"></span>
                                            <asp:Label runat="server" ID="lbl_alert_topo_emprestimo" Text=""> </asp:Label>
                                        </div>
                                        <div runat="server" id="alert_topo_erro_emprestimo" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <span class="sr-only"></span>
                                            <asp:Label runat="server" ID="lbl_alert_topo_erro_emprestimo" Text=""> </asp:Label>
                                        </div>
                                        <h1>Com quem estão meus livros?</h1>
                                        <h4 class="text-justify">Aqui se encontram os seus empréstimos. Você sempre pode alterar um prazo de devolução ou finalizar o empréstimo caso alguém já tenha
                                            devolvido seu livro. Basta verificar a coluna Ações.
                                        </h4>
                                        <br />
                                    </div>
                                    <div class="container" style="padding-top: 20px;">
                                        <asp:Literal runat="server" ID="literal_grid_emprestimos"></asp:Literal>
                                        <%--<table id="grid_emprestimos2" visible="false" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>Nome do Livro
                                                    </th>
                                                    <th>Nome do Emprestante
                                                    </th>
                                                    <th>Email do Emprestante
                                                    </th>
                                                    <th>Data de Devolução
                                                    </th>
                                                    <th class="acao">Ações
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>Assassinato no Expresso do Oriente
                                                    </td>
                                                    <td>Matheus Magalhães
                                                    </td>
                                                    <td>matheus@magalhaes.com
                                                    </td>
                                                    <td>15/11/2014
                                                    </td>
                                                    <td>
                                                        <span style="padding-left: 14px;">
                                                            <a title="Alterar prazo" class="btn btn-warning btn-xs" data-toggle="modal"
                                                                data-target="#modal_alterar_prazo">
                                                                <span class="glyphicon glyphicon-calendar"></span>
                                                            </a>
                                                            <a title="Finalizar empréstimo" class="btn btn-success btn-xs" data-toggle="modal"
                                                                data-target="#modal_finalizar_emprestimo">
                                                                <span class="glyphicon glyphicon-ok"></span>
                                                            </a>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>--%>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="div_aba3" runat="server">
                                    <div style="padding-top: 20px; padding-left: 15px;">
                                        <h1>Meus dados</h1>
                                        <h4>Você pode alterar as informações da sua conta.
                                        </h4>
                                    </div>
                                    <div class="container" style="padding-top: 20px;">
                                        <div runat="server" id="div_mensagem_perfil" visible="false" class="alert alert-info alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <span class="sr-only"></span>
                                            <asp:Label runat="server" ID="lbl_mensagem_perfil" Text=""> </asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <h4>Nome
                                            </h4>
                                            <input runat="server" id="txt_nome" class="form-control" type="text" maxlength="50" placeholder="">
                                        </div>
                                        <div class="form-group">
                                            <h4>E-mail</h4>
                                            <input runat="server" id="txt_email" class="form-control " type="text" maxlength="50" placeholder="">
                                        </div>
                                        <div class="form-group">
                                            <h4>Nova Senha</h4>
                                            <input runat="server" id="txt_nova_senha" class="form-control " type="password" maxlength="20" placeholder="">
                                        </div>
                                        <div class="form-group">
                                            <h4>Confirme a nova senha</h4>
                                            <input runat="server" id="txt_nova_senha_confirmacao" class="form-control " type="password" maxlength="20" placeholder="">
                                        </div>
                                        <asp:LinkButton class="btn btn-info" runat="server" ID="LinkButton" OnClick="AtualizarPerfil" Text="Atualizar Perfil"></asp:LinkButton>
                                        <a class="btn btn-danger" data-toggle="modal" data-target="#modal_excluir_conta">Desativar conta
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">&nbsp;<br />&nbsp;&nbsp;<br />&nbsp;&nbsp;<br />&nbsp;&nbsp;<br />&nbsp;</div>
        <div id="footerwrap" class="navbar-fixed-bottom">
            <div class="container">
                <h4>Created by <a href="">Stremens Corp.</a> - TMA LTDA.</h4>
            </div>
        </div>
        <div class="modal fade" id="modal_novo_livro" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title custom_align" id="H1">Cadastre seu Livro</h4>
                    </div>
                    <div class="modal-body">
                        <div runat="server" id="div_mensagem_livro" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <span class="sr-only"></span>
                            <asp:Label runat="server" ID="lbl_mensagem_livro" Text=""> </asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="txt_nome_livro" CssClass="form-control " placeholder="Nome do Livro"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <asp:LinkButton runat="server" OnClick="CadastrarLivro" ID="btn_criar_livro" CssClass="btn btn-success" Style="width: 50%;">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Salvar</asp:LinkButton>
                        <asp:LinkButton ID="btn_cancelar_cadastro" runat="server" class="btn btn-danger" OnClick="FecharPopup" Text="Cancelar"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title custom_align">Editando...</h4>
                    </div>
                    <div class="modal-body">
                        <div runat="server" id="div_msg_alterar_livro" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <span class="sr-only"></span>
                            <asp:Label runat="server" ID="lbl_msg_alterar_livro" Text=""> </asp:Label>
                        </div>
                        <div class="form-group">
                            <input runat="server" id="txt_editar_livro_nome" class="form-control " type="text" placeholder="Nome do Livro">
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <asp:LinkButton runat="server" type="button" OnClick="AtualizarLivro" class="btn btn-warning" Style="width: 50%;">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Atualizar</asp:LinkButton>
                        <asp:LinkButton ID="btn_cancelar_edicao_livro" runat="server" class="btn btn-danger" OnClick="FecharPopup" Text="Cancelar"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_novo_emprestimo" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title custom_align">Emprestar Livro
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div runat="server" id="div_msg_emprestimo" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <span class="sr-only"></span>
                            <asp:Label runat="server" ID="lbl_emprestimo" Text=""> </asp:Label>
                        </div>
                        <div class="form-group">
                            <input class="form-control" runat="server" id="txt_label_livro" disabled type="text">
                        </div>
                        <div class="form-group">
                            <input runat="server" id="txt_nome_emprestante" class="form-control " type="text" placeholder="Nome do Emprestante">
                        </div>
                        <div class="form-group">
                            <input runat="server" id="txt_email_emprestante" class="form-control " type="text" placeholder="E-mail do Emprestante">
                        </div>
                        <div class="form-group">
                            <input runat="server" id="txt_nova_data" maxlength="10" class="form-control" data-mask="99/99/9999"
                                type="text" placeholder="Data de Devolução">
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <asp:LinkButton runat="server" ID="btn_emprestar_livro" OnClick="EmprestarLivro" type="button" class="btn btn-success">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Emprestar
                        </asp:LinkButton>
                        <asp:LinkButton ID="btn_cancelar_emprestimo" runat="server" class="btn btn-danger" OnClick="FecharPopup" Text="Cancelar"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <h4 class="modal-title custom_align">Deletar</h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-warning">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;&nbsp;Você tem certeza
                        que gostaria de deletar este livro e todas as suas cópias?
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <asp:LinkButton runat="server" class="btn btn-success" ID="btn_confirmar_exclusao_livro" OnClick="ExcluirLivro"><span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Sim
                        </asp:LinkButton>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Não</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_excluir_conta" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×
                        </button>
                        <h4 class="modal-title custom_align">Desativar Conta
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-warning">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;&nbsp;Caso deseje reativar sua conta, 
                            basta fazer o login na página inicial e sua conta será reativada automaticamente. Você tem certeza
                        que gostaria de desativar sua conta na Biblioteca Pessoal?
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <%--<button type="button" class="btn btn-success">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Sim
                        </button>--%>
                        <asp:LinkButton runat="server" ID="btn_desativar_conta" OnClick="DesativarUsuario" Text="Sim" CssClass="btn btn-success" />
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Não
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_finalizar_emprestimo" tabindex="-1" role="dialog"
            aria-labelledby="edit" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×
                        </button>
                        <h4 class="modal-title custom_align">Devolução de Livro
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-warning">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;&nbsp;Você tem certeza
                        que gostaria de finalizar o empréstimo deste livro?
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <asp:LinkButton runat="server" class="btn btn-success" ID="LinkButton2141" OnClick="FinalizarEmprestimo"><span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Sim
                        </asp:LinkButton>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Não
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_alterar_prazo" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title custom_align" id="H3">Alterando o prazo...</h4>
                    </div>
                    <div class="modal-body">
                        <div runat="server" id="alert_alterar_prazo" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <span class="sr-only"></span>
                            <asp:Label runat="server" ID="lbl_alert_alterar_prazo" Text=""> </asp:Label>
                        </div>
                        <div class="form-group">
                            <%--<input class="form-control" runat="server" id="txt_antiga_data" disabled type="text">--%>
                        </div>
                        <div class="form-group">
                            <input runat="server" id="txt_nova_data_prazo" maxlength="10" class="form-control" data-mask="99/99/9999"
                                type="text" placeholder="Nova data">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton runat="server" OnClick="AlterarPrazo" ID="LinkButton21212" CssClass="btn btn-success" Style="width: 50%;">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Salvar</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton111" runat="server" class="btn btn-danger" OnClick="FecharPopup" Text="Cancelar"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
