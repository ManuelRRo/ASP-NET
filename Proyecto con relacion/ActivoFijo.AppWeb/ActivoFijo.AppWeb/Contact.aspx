<%@ Page Async="true" Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ActivoFijo.AppWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <!--Formulario para guardar y actualizar registros-->
        <div class="card mb-4">
            <div class="card-body">
                <asp:Panel ID="Pnl_TituloModal" runat="server" CssClass="modal-header">
                    <h5 class="modal-tittle mx-3">Clasificacion de Activo Fijo</h5>
                    <asp:HiddenField ID="Hdn_IdClasificacion" runat="server"/>
                </asp:Panel>
                <!-- Un selector para elegir el EspecificoGasto -->
                <div class="col-md-6">
                    <label for="<%=Ddl_EspecificoGasto.ClientID %>">Nombre Especifico
                    <asp:DropDownList ID="Ddl_EspecificoGasto" runat="server" CssClass="form-control" DataSourceID="Lnqs_Especifico"
                        DataTextField="NombreEspecifico" DataValueField="IdEspecifico" AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Text="- SELECCIONE -" Value=""></asp:ListItem>
                    </asp:DropDownList></label>
                    <asp:LinqDataSource ID="Lnqs_Especifico" runat="server" ContextTypeName="ActivoFijo.Data.DataContext.ActivoFijoModel"
                        EntityTypeName="" OrderBy="CodigoEspecifico"
                        Select="new (CodigoEspecifico + &quot; &quot; + NombreEspecifico as NombreEspecifico, IdEspecifico)" TableName="TBL_EspecificoGasto">
                    </asp:LinqDataSource>
                </div>
                <!-- Fin -->
                <div class="row">
                    <div class="col-md-3">
                        <label for="<%=TxTCodigo.ClientID %>">Código de Clasificacion</label>
                        <asp:TextBox ID="TxTCodigo" runat="server" CssClass="form-control" ValidationGroup="GuardarActualizar"
                            TabIndex="1" placeholder="Código Clasificacion ..." MaxLength="10" required=true></asp:TextBox>
                    </div>
                    <div class="col-md-9">
                        <label for="<%=TxtDescripcion.ClientID %>">Descripcion de Clasificacion</label>
                        <asp:TextBox ID="TxtDescripcion" runat="server" CssClass="form-control" ValidationGroup="GuardarActualizar"
                            TabIndex="2" placeholder="Descripcion de Clasificacion ..." MaxLength="50" required=true>
                        </asp:TextBox>
                    </div>                                
                </div>                
                <div class="my-3">
                    <asp:LinkButton ID="LnkBtn_Nuevo" runat="server" CssClass="btn btn-primary" OnClick="BtnGuardarActualizar_Click" >
                        Agregar nuevo <span class="fas fa-plus" aria-hidden="true"/>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <!-- Fin del formulario -->
        <div class="row table-responsive">
            <asp:GridView ID="Gv_Clasificacion" runat="server" CssClass="table table-striped table-hover table-bordered"
                HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False" DataSourceID="Lqs_Clasificacion" Width="100%"
                AllowSorting="True" AllowPaging="True" PagerSettings-Position="TopAndBottom"
                PagerStyle-HorizontalAlign="Right"
                PagerStyle-CssClass="pager-style">
                <Columns>
                    <asp:BoundField DataField="IdEspecifico" HeaderText="IdEspecifico" SortExpression="IdEspecifico" />
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lnk_Editar" runat="server" ToolTip="Editar"
                                OnCommand="Lnk_Editar_Command" CommandArgument='<%#Eval("IdClasificacionActivoFijo") %>'>
                                <span>Editar</span>
                            </asp:LinkButton>

                            <asp:LinkButton ID="Lnk_Eliminar" runat="server" ToolTip="Eliminar"
                                OnCommand="Lnk_Eliminar_Command" CommandArgument='<%#Eval("IdClasificacionActivoFijo") %>'>
                                <span>Eliminar</span>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="table-light" />

                <PagerSettings Position="TopAndBottom" />

                <PagerStyle HorizontalAlign="Right" CssClass="pager-style" />
            </asp:GridView>
            <asp:LinqDataSource ID="Lqs_Clasificacion" runat="server" ContextTypeName="ActivoFijo.Data.DataContext.ActivoFijoModel" EntityTypeName="" OrderBy="Codigo" TableName="TBL_ClasificacionActivoFijo">
            </asp:LinqDataSource>
        </div>
    </main>
</asp:Content>
