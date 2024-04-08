<%@ Page Title="Home Page" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ActivoFijo.AppWeb._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <!--La pagina debe llevar Async="true"-->
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
        </section>
        <!--Formulario para guardar y actualizar registros-->
        <div class="card mb-4">
            <div class="card-body">
                <div class="row">
                    <asp:Panel ID="Pnl_TituloModal" runat="server" CssClass="modal-header">
                        <h5 class="modal-tittle mx-3">Especifico de Gasto</h5>
                        <asp:HiddenField ID="Hdn_IdEspecifico" runat="server"/>
                    </asp:Panel>
                    <div class="col-md-3">
                        <label for="<%=TxTCodigo.ClientID %>">Código Especifico Gasto</label>
                        <asp:TextBox ID="TxTCodigo" runat="server" CssClass="form-control" ValidationGroup="GuardarActualizar"
                            TabIndex="1" placeholder="Código Especifico ..." MaxLength="10" required=true></asp:TextBox>
                    </div>
                    <div class="col-md-9">
                        <label for="<%=TxtNombre.ClientID %>">Nombre Especifico Gasto</label>
                        <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" ValidationGroup="GuardarActualizar"
                            TabIndex="2" placeholder="Nombre Especifico ..." MaxLength="100" required=true>
                        </asp:TextBox>
                    </div>                                
                </div>
                <div class="my-3">
                    <asp:LinkButton ID="LnkBtn_Nuevo" runat="server" CssClass="btn btn-primary" OnClick="BtnGuardarActualizar_Click">
                        Agregar nuevo <span class="fas fa-plus" aria-hidden="true"/>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <!--Fin de formulario para guardar y actualizar registros-->
        <div class="row table-responsive">
            <asp:GridView ID="Gv_EspecificoGastos" runat="server" CssClass="table table-striped table-hover table-bordered"
                HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False" DataSourceID="Lqs_EspecificoGasto" Width="100%"
                AllowSorting="True" AllowPaging="True" PagerSettings-Position="TopAndBottom"
                PagerStyle-HorizontalAlign="Right"
                PagerStyle-CssClass="pager-style">
                <Columns>
                    <asp:BoundField DataField="IdEspecifico" HeaderText="IdEspecifico" SortExpression="IdEspecifico" />
                    <asp:BoundField DataField="CodigoEspecifico" HeaderText="CodigoEspecifico" SortExpression="CodigoEspecifico" />
                    <asp:BoundField DataField="NombreEspecifico" HeaderText="NombreEspecifico" SortExpression="NombreEspecifico" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_Editar" runat="server" ToolTip="Editar"
                                OnCommand="Lnk_Editar_Command" CommandArgument='<%#Eval("IdEspecifico") %>'>
                        <span>Editar</span>
                            </asp:LinkButton>

                            <asp:LinkButton ID="Lnk_Eliminar" runat="server" ToolTip="Eliminar"
                                OnCommand="Lnk_Eliminar_Command" CommandArgument='<%#Eval("IdEspecifico") %>'>
                        <span>Eliminar</span>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="table-light" />

                <PagerSettings Position="TopAndBottom" />

                <PagerStyle HorizontalAlign="Right" CssClass="pager-style" />
            </asp:GridView>
            <asp:LinqDataSource ID="Lqs_EspecificoGasto" runat="server" ContextTypeName="ActivoFijo.Data.DataContext.ActivoFijoModel" EntityTypeName="" OrderBy="CodigoEspecifico" TableName="TBL_EspecificoGasto">
            </asp:LinqDataSource>
        </div>
    </main>

</asp:Content>
