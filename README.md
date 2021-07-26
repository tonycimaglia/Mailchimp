# Hey Y'all!

This document is intended for Carolyn, Nic, Tonee, Talmadge, and anyone else at Mailchimp.

There are already two sample files in the SampleInputs directory which are converted to html and printed to the console when the program is run. Once the project is on your machine, feel free to add other markdown files to the Mailchimp/Markdown.Converter/SampleInputs directory.

## Instructions for running the project:

- First, make sure you have the [.NET 5.0](https://dotnet.microsoft.com/download) SDK downloaded.
- Clone the repo to your machine.

#### On Windows:

- Open up the project in Visual Studio.
- Clean and build the solution.
- You should now be able to run the Markdown.Converter project and see the results of the conversion printed to the console. 
- You can also run the test project to see the results of the tests for the application. 

#### On Mac / Linux

- Navigate into the Markdown.Converter directory (Mailchimp/Markdown.Converter).
- Run the following command: ```dotnet build --configuration Release```
- Once the project builds run: ```dotnet run```
- Change directories into Markdown.Converter.Tests  (Mailchimp/Markdown.Converter.Tests).
- Run the following command: ```dotnet test Markdown.Converter.Tests.csproj```

Please reach out to me if you have any issues running through everything. I'm excited to speak to everyone Tuesday!

Tony
