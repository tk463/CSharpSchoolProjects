<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SmartVigilance.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Main.aspx<br />
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSourceRepertoire" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="IDUtilisateur" HeaderText="IDUtilisateur" SortExpression="IDUtilisateur" ReadOnly="True" />
                <asp:BoundField DataField="IDContact" HeaderText="IDContact" SortExpression="IDContact" ReadOnly="True" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
                <asp:BoundField DataField="Adresse" HeaderText="Adresse" SortExpression="Adresse" />
                <asp:BoundField DataField="NTel" HeaderText="NTel" SortExpression="NTel" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Priorite" HeaderText="Priorite" SortExpression="Priorite" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceRepertoire" runat="server" DataObjectTypeName="BLL.RepertoireDto" SelectMethod="GetRepertoire" TypeName="SmartVigilance.WCFLib" UpdateMethod="UpdateRepertoire">
            <SelectParameters>
                <asp:SessionParameter Name="IDUtilisateur" SessionField="IDUtilisateur" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <br /><br />

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSourceInterv" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="IDUtilisateur" HeaderText="IDUtilisateur" SortExpression="IDUtilisateur" />
                <asp:BoundField DataField="IDContact" HeaderText="IDContact" SortExpression="IDContact" />
                <asp:BoundField DataField="DateHeure" HeaderText="DateHeure" SortExpression="DateHeure" />
                <asp:BoundField DataField="UrgenceLevel" HeaderText="UrgenceLevel" SortExpression="UrgenceLevel" />
                <asp:BoundField DataField="GPSLocation" HeaderText="GPSLocation" SortExpression="GPSLocation" />
                <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceInterv" runat="server" SelectMethod="GetInterventions" TypeName="SmartVigilance.WCFLib">
            <SelectParameters>
                <asp:SessionParameter Name="IDUtilisateur" SessionField="IDUtilisateur" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
