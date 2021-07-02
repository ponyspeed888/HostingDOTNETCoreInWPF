This project demonstrate how to host dot net core web app in .net core WPF.

Steps
1. Create Wpf Core Project
2. Add the following packages

Microsoft.Extensions.Hosting
Microsoft.AspNetCore

3. Modify the code in App.xaml.cs. please note these two line is required, and please modify according to your project.  Not sure when they are execute in standard asp.net core project, but in WPF host the webroot default to null 

            .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
            .UseWebRoot(WEBROOT)         





4. Create a .NET CORE WEB project and add as project reference as Wpf project

5. Go to localhost:5000 to see the hosted web site


