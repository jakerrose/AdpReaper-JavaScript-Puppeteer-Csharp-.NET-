# ADP Reaper
*I will explain this solution which was used for web scraping, calling API fetches, and more in the ADP system*

This is a solution that was used as part of my job as Software Developer for an Oregon based IT startup company. We assisted the client in data migration from their old system in ADP to their new Paycom system.
I was tasked with collected documents and data of all employees, past and present, including training materials, I9 forms, W2's, 1095-C's, benefit enrollment history, pay history, and position history. 

This solution runs in Visual Studio 2022 in a .NET framework (8.0). The main programming language is C# and uses JavaScript and the JavaScript library PuppeteerSharp. When the application is run, the Run() function 
is called which calls the app.config settings and launches the Puppeteer browser and all its settings. From the Task GetBrowser you can change the browser and helpful settings like kiosk-printing which controls what 
happens when the print button is clicked in the browser. Using the app.config settings, the browser launches the specified starting url and types in the username and password and clicks the login button with Puppeteer. 
In the first try catch are the Tasks that one can select to run. If one is uncommented, it will just run that one, or else it will loop back around once the Task is complete and start the next.

## employeeFetch()
The purpose of this task is go create a JSON file of a list of all employees in the company. This information is found as an XHR fetch in the browsers' API upon loading of a page. By copying the fetch, I created this 
JavaScript fetch call. This will save a file with all employee information that the system uses including name, multiple id numbers, status, hire date, and much more. There is associate view which just has information
about an employee's current position and position view which has all historical positions. Whenever this data is needed for the rest of the solution, it can be called and loaded into the class EmployeeSearchResponse.cs.
The static async void LoadEmps() can be called before the Task is called the deserialize the JSON into the list EmployeeRecordADP so that the data is already ready to use.

## GetLMSPdf()
This collection was to get training documents for employees from a very old LMS system that did not use any API fetches. I had to rely on scraping the DOM from HTML to get the data I was after and to collect the needed 
documents. The system was designed as a series of folders, some containing links to download documents, others just more folders. I used this JavaScript to evaluation the HTML and find the links I was after. If one was 
found, it would be stored in a JSON file:

    var script = @"
            Array.from(document.querySelectorAll('a[href^=""/lms/servlet/lms/FRFILE?RID""]'))
                .map(a => a.outerHTML)";
                
    var elements = await page.EvaluateExpressionAsync<string[]>(script);


If no links to documents were found, the link to the next layer of folders would be saved. Since there was up to four layers of folders in these structures, I repeated my loop four times to save JSON files of download
and folder links four layers deep. After that, I could look for files. The links to the files in the DOM had the url and the filename and I wanted both so I used this JavaScript:

			// Get all path and filename pairs from the page
			var pairs = await page.EvaluateFunctionAsync<List<Dictionary<string, string>>>(@"
        () => {
            const pairs = [];
            const pathInputs = document.querySelectorAll('input[name^=PATH]');
            pathInputs.forEach(input => {
                const pathValue = input.value;
                const index = input.name.slice(4);
                const filenameInput = document.querySelector(`input[name=FILENAME${index}]`);
                if (filenameInput) {
                    const filenameValue = filenameInput.value;
                    pairs.push({ pathValue, filenameValue });
                }
            });
            return pairs;
        }
    ");

    
For each pair, I could now use the pathValue to define the URL of the file and download with this code:

    var downloadUrl = $"https://tms.adp.com{pathValue}";
    
    var pdfData = await page.EvaluateFunctionAsync<string>(@"
    async (url) => {
        const response = await fetch(url);
        const blob = await response.blob();
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.onloadend = () => resolve(reader.result);
            reader.onerror = reject;
            reader.readAsDataURL(blob);
        });
    }", downloadUrl);




