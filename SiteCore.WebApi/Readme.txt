--DB first
Scaffold-DbContext "Data Source=(local)\sql14;Initial Catalog=SiteCore;User ID=sa;Password=Qwerty88!" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models\DB -force
or
dotnet ef dbcontext scaffold "Data Source=.\sql14;Initial Catalog=CMT;User ID=sa;Password=Qwerty88!" Microsoft.EntityFrameworkCore.SqlServer -o Models -f

--Code Generation tool for ASP.NET Core. Contains the dotnet-aspnet-codegenerator command used for generating controllers and views.
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design  

-- You can run bellow command If you encountered a issue like this 'No executable found matching command "dotnet-aspnet-codegenerator"' 
-- you used command 'dotnet-aspnet-codegenerator' after you have been runneed above command
dotnet tool install --global dotnet-aspnet-codegenerator

dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc CMTContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

--Code first
dotnet ef migrations add InitialCreate
dotnet ef database update


--EF
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design
Install-Package Microsoft.EntityFrameworkCore.Tools

add connectionstring into Startup()
 "Configuration.GetConnectionString("Data Source=.\sql14;Initial Catalog=SiteCore;User ID=sa;Password=Qwerty88!");"

.net download
 https://www.microsoft.com/net/download
 
--swagger
Install-Package Swashbuckle.AspNetCore 
Install-Package Swashbuckle.AspNetCore.Filters 

--view Intellisense 
Install-Package Microsoft.AspNetCore.Razor.Tools


Q:A network-related or instance-specific error occurred while establishing a connection to SQL Server. 
The server was not found or was not accessible. Verify that the instance name is correct and 
that SQL Server is configured to allow remote connections. 
(provider: SQL Network Interfaces, error: 50 - Local Database Runtime error occurred. The specified LocalDB instance does not exist.
A:To configure the remote access option
In Object Explorer, right-click a server and select Properties.
Click the Connections node.
Under Remote server connections, select or clear the Allow remote connections to this server check box.
