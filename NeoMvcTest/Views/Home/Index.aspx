<%@ Page Language="C#" %>

<%
    var model = this.Model as ArrayList;
    
%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <div>
        <h1><%=System.Web.HttpContext.Current.Items["Name"] %></h1>
        <table>
            <%for (int i = 0; i < model.Count; i++)
              {
                  System.Web.UI.WebControls.ListItem item = model[i] as System.Web.UI.WebControls.ListItem;
            %>
            <tr>
                <td>
                    <%=item.Text %>
                </td>
                <td>
                    <%=item.Value %>
                </td>
            </tr>
            <%} %>
        </table>
    </div>
</body>
</html>
